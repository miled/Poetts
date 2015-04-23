using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Configuration;
using Microsoft.Win32;

namespace poetts
{
    public partial class GUI : Form
    {
        SpeechSynthesizer speechynthesizer;

        List<string> poeXmlStrings = new List<string>();

        public enum KeyModifier
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            WinKey = 8
        }

        private static int WM_HOTKEY = 0x0312;
        private int _filesLoaded = 0;
        private int _stringsLoaded = 0;
        private int _ocrAttempts = 0;
        private int _ttsAttempts = 0;
        private bool _isTtsPaused = false;

        private string _settingHkeyExtract = "E";
        private string _settingHkeykeyRead = "R";
        private string _settingHkeykeyPause = "P";
        private string _settingHkeykeyStop = "S";
        private string _settingPoeGamePath = "";
        private string _settingPoettsPath = "";


        //////////////////////////////////////
        /// App logic
        ///////////////////////////////////////////////// 

        /// <summary>
        /// Setup custom hotkeys and stuff .. for future use, prolly.
        /// </summary>
        private void LoadAppConfig()
        {
            _settingHkeyExtract = System.Configuration.ConfigurationManager.AppSettings["hkey_extract"];
            _settingHkeykeyRead = System.Configuration.ConfigurationManager.AppSettings["hkey_read"];
            _settingHkeykeyPause = System.Configuration.ConfigurationManager.AppSettings["hkey_pause"];
            _settingHkeykeyStop = System.Configuration.ConfigurationManager.AppSettings["hkey_stop"];
            _settingPoeGamePath = System.Configuration.ConfigurationManager.AppSettings["poe_game_path"];

            _settingPoettsPath = Path.GetDirectoryName(Application.ExecutablePath);

            if (string.IsNullOrEmpty(_settingPoeGamePath))
            {
                _settingPoeGamePath = GetPOEInstallationPath();

                if (string.IsNullOrEmpty(_settingPoeGamePath))
                {
                    MessageBox.Show("Pillars of Eternity installation folder was not found. You may still use Poetts, however the program may not work as expected.", "Poetts - Game not found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY)
            {
                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                KeyModifier modifier = (KeyModifier)((int)m.LParam & 0xFFFF);
                int id = m.WParam.ToInt32();

                HandleHotKeys(modifier, id);
            }

            base.WndProc(ref m);
        }

        public void RegisterHotKeys()
        {
            User32.RegisterHotKey(this.Handle, 1, (uint)KeyModifier.Control, (uint)_settingHkeyExtract[0]);
            User32.RegisterHotKey(this.Handle, 2, (uint)KeyModifier.Control, (uint)_settingHkeykeyRead[0]);
            User32.RegisterHotKey(this.Handle, 3, (uint)KeyModifier.Control, (uint)_settingHkeykeyPause[0]);
            User32.RegisterHotKey(this.Handle, 4, (uint)KeyModifier.Control, (uint)_settingHkeykeyStop[0]);
        }

        private void UnregisterHotKeys()
        {
            User32.UnregisterHotKey(this.Handle, 1);
            User32.UnregisterHotKey(this.Handle, 2);
            User32.UnregisterHotKey(this.Handle, 3);
            User32.UnregisterHotKey(this.Handle, 4);
        }

        public void HandleHotKeys(KeyModifier modifier, int id)
        {
            // Extract
            if (id == 1)
            {
                OCRExtractText();

                SearchMatch(textOcr.Text);
            }
            // Read
            else if (id == 2)
            {
                TTSSpeak();
            }
            // Pause
            else if (id == 3)
            {
                TTSPause();
            }
            // Stop
            else if (id == 4)
            {
                TTSStop();
            }
        }

        //////////////////////////////////////
        /// OCR
        ///////////////////////////////////////////////// 

        public void CaptureScreenShot(string procName)
        {
            updateStatusBar("Capturing screen..");

            var proc = Process.GetProcessesByName(procName)[0];
            Console.WriteLine(proc);
            var rect = new User32.Rect();
            User32.GetWindowRect(proc.MainWindowHandle, ref rect);

            int width = rect.right - rect.left;
            int height = rect.bottom - rect.top;

            var bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(bmp);
            graphics.CopyFromScreen(rect.left, rect.top, 0, 0, new Size(width, height), CopyPixelOperation.SourceCopy);

            bmp.Save(_settingPoettsPath + "\\temp\\x.png", ImageFormat.Png);
        }

        public string GetTextFromBitmap()
        {
            ProcessStartInfo info = new ProcessStartInfo(_settingPoettsPath + "\\tesseract\\tesseract.exe", _settingPoettsPath + "\\temp\\x.png " + _settingPoettsPath + "\\temp\\x -l eng nobatch " + _settingPoettsPath + "\\tesseract\\char_whitelist");
            info.WindowStyle = ProcessWindowStyle.Hidden;
            Process p = Process.Start(info);
            p.WaitForExit();

            TextReader tr = new StreamReader(_settingPoettsPath + "\\temp\\x.txt");
            string res = tr.ReadToEnd();
            tr.Close();

            return res.Trim();
        }

        private void OCRExtractText()
        {
            textOcr.Text = "";
            textMatch.Text = "";

            CaptureScreenShot("PillarsOfEternity");

            updateStatusBar("Tesseract proccessing..");

            string processedtext = GetTextFromBitmap();

            textOcr.Text = processedtext.Replace("\n", Environment.NewLine);

            _ocrAttempts++;
        }

        /// <summary>
        /// I think I should patent this algorithm
        /// </summary>
        private string SearchMatch(string ocrText)
        {
            if (string.IsNullOrEmpty(_settingPoeGamePath))
            {
                textMatch.Text = "Pillars of Eternity installation folder was not found.";

                return ocrText;
            }

            updateStatusBar("Searching for matches..");

            string[] lines = ocrText.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

            string line = lines[0];

            // string[] words = line.Split(new string[] { ",", ";", ".", "!", "?", " " }, StringSplitOptions.RemoveEmptyEntries);

            string[] words = ocrText.Split(new string[] { ",", ";", ".", "!", "?", " " }, StringSplitOptions.RemoveEmptyEntries);

            string bestMatch = "";
            int bestMatchCounts = 0;
            int currentMatchCounts = 0;

            foreach (string entry in poeXmlStrings)
            {
                foreach (string word in words)
                {
                    if (word.Length > 3 && entry.Contains(word))
                    {
                        currentMatchCounts++;
                    }
                }

                if (currentMatchCounts > bestMatchCounts)
                {
                    bestMatchCounts = currentMatchCounts;
                    bestMatch = entry;
                }

                currentMatchCounts = 0;
            }

            textMatch.Text = "(" + bestMatchCounts + ") " + bestMatch.Replace("\n", Environment.NewLine);

            updateStatusBar("Match found.");

            return bestMatch;
        }

        //////////////////////////////////////
        /// Text to speech
        ///////////////////////////////////////////////// 

        private void TTSSpeak()
        {
            TTSStop();

            OCRExtractText();

            if (string.IsNullOrEmpty(textOcr.Text))
            {
                textOcr.Text = "No text found.";

                TTSSpeakAsync(textOcr.Text);
            }
            else
            {
                string bestMatch = SearchMatch(textOcr.Text);

                TTSSpeakAsync(bestMatch);
            }

            _ttsAttempts++;
        }

        private void TTSSpeakAsync(string data)
        {
            try
            {
                speechynthesizer.Rate = trackBarRate.Value;
                speechynthesizer.Volume = trackBarVolume.Value;
                speechynthesizer.SelectVoice(comboBoxVoices.Text);

                speechynthesizer.SpeakAsync(data);

                updateStatusBar("Playing text to speech..");
            }
            catch (Exception ex)
            {
                updateStatusBar("Text to speech error!");

                MessageBox.Show(ex.Message);
            }
        }

        private void TTSPause()
        {
            if (_isTtsPaused)
            {
                speechynthesizer.Resume();

                _isTtsPaused = false;

                button2.Text = "Pause (Ctrl+P)";

                updateStatusBar("Playing text to speech..");
            }
            else
            {
                speechynthesizer.Pause();

                _isTtsPaused = true;

                button2.Text = "Resume (Ctrl+P)";

                updateStatusBar("Text to speech paused.");
            }
        }

        private void TTSStop()
        {
            speechynthesizer.SpeakAsyncCancelAll();

            updateStatusBar("Text to speech stopped.");
        }

        public string GetPOEInstallationPath()
        {
            string programDisplayName = "Pillars of Eternity";

            foreach (var item in Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall").GetSubKeyNames())
            {

                object programName = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\" + item).GetValue("DisplayName");
                object programPath = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\" + item).GetValue("InstallLocation");

                if (string.Equals(programName, programDisplayName))
                {
                    return (string)programPath;
                }
            }

            return "";
        }

        //////////////////////////////////////
        /// Buttons and stuff
        ///////////////////////////////////////////////// 

        public GUI()
        {
            InitializeComponent();

            this.MaximizeBox = false;

            textOcr.Multiline = true;
            textOcr.ScrollBars = ScrollBars.Vertical;
            textOcr.AcceptsReturn = true;
            textOcr.AcceptsTab = true;
            textOcr.WordWrap = true;

            textMatch.Multiline = true;
            textMatch.ScrollBars = ScrollBars.Vertical;
            textMatch.AcceptsReturn = true;
            textMatch.AcceptsTab = true;
            textMatch.WordWrap = true;

            Console.WriteLine("Starting..");

            LoadAppConfig();

            RegisterHotKeys();

            updateStatusBar("Loading POE XML files..");

            if (!string.IsNullOrEmpty(_settingPoeGamePath))
            {
                loadXMLFiles(".stringtable", _settingPoeGamePath + "PillarsOfEternity_Data\\data\\localized\\en\\");
            }

            updateStatusBar("Ready.");
        }

        public void loadXMLFiles(string fileType, string dir)
        {
            string dirName = dir;

            try
            {
                foreach (string f in Directory.GetFiles(dirName))
                {
                    if (f.Contains(fileType))
                    {
                        var xml = XDocument.Load(f);

                        var query = from c in xml.Root.Descendants("Entry")
                                    select c.Element("DefaultText").Value;

                        foreach (string defaultText in query)
                        {
                            poeXmlStrings.Add(defaultText);

                            _stringsLoaded++;
                        }
                    }

                    _filesLoaded++;

                    updateStatusBar("Loading POE XML files..");
                }

                foreach (string d in Directory.GetDirectories(dirName))
                {
                    loadXMLFiles(fileType, d);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void updateStatusBar(string status)
        {
            toolStripStatusFiles.Text = "Files: " + _filesLoaded;
            toolStripStatusStrings.Text = "Strings: " + _stringsLoaded;
            toolStripStatusOCR.Text = "OCR: " + _ocrAttempts;
            toolStripStatusTTS.Text = "TTS: " + _ttsAttempts;
            toolStripStatusApp.Text = status;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            speechynthesizer = new SpeechSynthesizer();

            foreach (InstalledVoice voice in speechynthesizer.GetInstalledVoices())
            {
                comboBoxVoices.Items.Add(voice.VoiceInfo.Name);
            }

            comboBoxVoices.SelectedIndex = 3; // 0;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterHotKeys();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TTSSpeak();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TTSPause();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TTSStop();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OCRExtractText();

            SearchMatch(textOcr.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented.", "Poetts - Parameters");
        }
    }
}
