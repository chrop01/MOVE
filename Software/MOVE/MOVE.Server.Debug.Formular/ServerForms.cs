﻿using MOVE.AudioLayer;
using MOVE.Core;
using MOVE.Shared;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Threading;
using System.Windows.Forms;

namespace MOVE.Server.Debug.Formular
{

    public partial class ServerForms : Form, IServiceLogger
    {
        #region Klasseninstanzvariablen
        TcpService ts;
        Client c;
        FrequenzInput fi = new FrequenzInput();
        SpeechRecognitionEngine _recognizerservergerman = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("de-DE"));
        SpeechRecognitionEngine _recognizerserverenglish = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-GB"));
        SpeechSynthesizer com = new SpeechSynthesizer();
        FirewallSettings fs = new FirewallSettings();
        NetworkDiscovery nd = new NetworkDiscovery();
        ServerSettings ss = new ServerSettings();
        ErrorLogWriter elw = new ErrorLogWriter();
        #endregion
        #region Variablen
        Thread t1; //Start Server
        Thread t2; //Connect Client
        Action<string> logRequestInformation;
        Action<string> logServiceInformation;
        int WertXlocal = 15;
        int WertXnetwork = 15;
        int pointsClient = 0;
        int pointsServer = 0;
        int counterstartserver;
        int counterconnectserver;
        int counterstartgame;
        private static double soundValueOne = 0;
        private static double soundValueTwo = 0;
        private static int audioCount = 0;
        private static int samplingRate = 44100;
        private static int bufferSize = 2048;
        const int yValue = 703;
        List<int> savedValues = new List<int>();
        int positionValue = 0;
        int wertGlaettung = 3;
        int average;
        int mod;
        int summe = 0;
        public int speed_left = 5;
        public int speed_top = 5;
        int counter = 0;
        List<int> auswertungsWerte = new List<int>();
        double player = 0;
        int speechmodulevalue = 1;
        int speechvalue;
        #endregion
        #region klassengenerierte Methoden
        public ServerForms()
        {
            InitializeComponent();
            logRequestInformation = new Action<string>(LogRequestInformation);
            logServiceInformation = new Action<string>(LogServiceinformation);
            string screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
            int s = Convert.ToInt32(screenHeight);
            double zahl = (7000 / 1080) * s;
            player = zahl / 10;
            Control.CheckForIllegalCrossThreadCalls = false;
            var waveIn = new WaveInEvent();
            waveIn.DeviceNumber = 0;
            waveIn.WaveFormat = new NAudio.Wave.WaveFormat(samplingRate, 1);
            waveIn.DataAvailable += GetSoundValues;
            waveIn.BufferMilliseconds = (int)((double)bufferSize / (double)samplingRate * 1000.0);
            waveIn.StartRecording();
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            fi.Start();
            string language = ConfigurationManager.AppSettings["language"];
            speechvalue = Convert.ToInt32(language);
            string speechmodule = ConfigurationManager.AppSettings["speechmodule"];
            speechmodulevalue = Convert.ToInt32(speechmodule);
            if (speechmodulevalue == 1)
            {
                if (speechvalue == 0)
                {
                    DefaultListenerGerman();
                    DesignChangesGerman();
                }
                if (speechvalue == 1)
                {
                    DefaultListenerEnglish();
                    DesignChangesEnglish();
                }
            }
            else
            {
                if (speechvalue == 0)
                {
                    DesignChangesGerman();
                }
                if (speechvalue == 1)
                {
                    DesignChangesEnglish();
                }
            }

        }
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            int s = dgv_playfieldclient.Bottom;
            yourcomputerheightvalue = s - 10;
            Connect();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            timer2.Enabled = true;

           
        }
        
        /*/
        private void cbAusblenden_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAusblenden.Checked == true)
            {

                lblFineTuning.Visible = false;
                lblGlaettung.Visible = false;
                btnSettings.Visible = false;
                lsb_Information.Visible = false;
                lblSchwierigkeit.Visible = false;
                btn_Start.Visible = false;
                btn_Connect.Visible = false;
                lblSchrittEins.Visible = false;
                lblSchrittZwei.Visible = false;
                lblSchrittDrei.Visible = false;
                lblBallSpeed.Visible = false;

                btnStart.Visible = false;
            }
            if (cbAusblenden.Checked == false)
            {
                lblFineTuning.Visible = true;
                lblGlaettung.Visible = true;
                lsb_Information.Visible = true;
                lblSchwierigkeit.Visible = true;
                btn_Start.Visible = true;
                btn_Connect.Visible = true;
                btnSettings.Visible = true;
                lblBallSpeed.Visible = true;
                btnStart.Visible = true;
                lblSchrittEins.Visible = true;
                lblSchrittZwei.Visible = true;
                lblSchrittDrei.Visible = true;
            }
        }
        /*/
        private void btn_Start_Click_1(object sender, EventArgs e)
        {
            Start();
            panel1.BackColor = Color.Yellow;
            panel2.BackColor = Color.Yellow;
            panel3.BackColor = Color.Yellow;
            panel4.BackColor = Color.Yellow;
            panel5.BackColor = Color.Yellow;
            panel6.BackColor = Color.Yellow;
            panel7.BackColor = Color.Yellow;
            panel8.BackColor = Color.Yellow;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            GetNewPanelLocation();
            StartGame();
            panel1.BackColor = Color.Blue;
            panel2.BackColor = Color.Purple;
            panel3.BackColor = Color.Pink;
            panel4.BackColor = Color.Blue;
            panel5.BackColor = Color.Blue;
            panel6.BackColor = Color.Purple;
            panel7.BackColor = Color.Pink;
            panel8.BackColor = Color.Pink;
            cbSprachmodul.Checked = false;
        }
        private void btn_Connect_Click_1(object sender, EventArgs e)
        {
            Connect();
            panel1.BackColor = Color.Green;
            panel2.BackColor = Color.Green;
            panel3.BackColor = Color.Green;
            panel4.BackColor = Color.Green;
            panel5.BackColor = Color.Green;
            panel6.BackColor = Color.Green;
            panel7.BackColor = Color.Green;
            panel8.BackColor = Color.Green;
        }
        private void ServerForms_Activated(object sender, EventArgs e)
        {
            if (speechmodulevalue == 1)
            {
                if (speechvalue == 0)
                {
                    ActivateDefaultGermanListener();
                }
                else if(speechvalue==1)
                {
                    ActivateDefaultEnglishListener();
                }
            }
            else
            {
            }
        }
        private void ServerForms_Deactivate(object sender, EventArgs e)
        {
            if (speechmodulevalue == 1)
            {
                if (speechvalue == 0)
                {
                    CancelDefaultGermanListener();
                }
                else if( speechvalue==1 )
                {
                    CancelDefaultEnglishListener();
                }
            }
            else
            {
            }
        }
        private void btnSettings_Click(object sender, EventArgs e)
        {
            ss.Visible = false;
            ss.ShowDialog();
            if (panel1.BackColor == Color.Red && panel2.BackColor == Color.Red)
            {
                panel1.BackColor = Color.Orange;
                panel2.BackColor = Color.Orange;
                panel3.BackColor = Color.Orange;
                panel4.BackColor = Color.Orange;
                panel5.BackColor = Color.Orange;
                panel6.BackColor = Color.Orange;
                panel7.BackColor = Color.Orange;
                panel8.BackColor = Color.Orange;
            }
            if (panel1.BackColor == Color.Blue && panel2.BackColor == Color.Purple)
            {
                panel1.BackColor = Color.Blue;
                panel2.BackColor = Color.Purple;
                panel3.BackColor = Color.Pink;
                panel4.BackColor = Color.Blue;
                panel5.BackColor = Color.Blue;
                panel6.BackColor = Color.Purple;
                panel7.BackColor = Color.Pink;
                panel8.BackColor = Color.Pink;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                if (rBFrequenz.Checked == true)
                {
                    fi.CalculateData(ss.GetCalSate());

                    positionValue = fi.CalculatePaddleLocationX(ss.FrequenzSetting(), ss.FrequenzThreshold());

                    if (positionValue < 0)
                    {
                        positionValue = 0;
                    }
                    if (positionValue > 1350)
                    {
                        positionValue = 1350;
                    }

                    if (ss.tbSmoothing.Value == 0)
                    {
                        pbx_downlocal.Location = new Point(positionValue + 60, (int)player);
                    }
                    if (ss.tbSmoothing.Value == 1)
                    {
                        savedValues.Add(positionValue);
                        Glaettung(2);
                    }
                    if (ss.tbSmoothing.Value == 2)
                    {
                        savedValues.Add(positionValue);
                        Glaettung(4);
                    }
                    if (ss.tbSmoothing.Value == 3)
                    {
                        savedValues.Add(positionValue);
                        Glaettung(6);
                    }
                }
                if (rBSound.Checked == true)
                {
                    double fractionValue = soundValueTwo / soundValueOne;
                    if (ss.tbempfindlichkeit.Value == 1)
                    {
                        positionValue = (int)(((fractionValue * 3) * 668)) - 2;
                      //  lblFineTuning.Text = "Empfindlichkeit: wenig";

                    }
                    if (ss.tbempfindlichkeit.Value == 2)
                    {
                        positionValue = (int)(((fractionValue * 5) * 668)) - 3;
                        //lblFineTuning.Text = "Empfindlichkeit: mittel";

                    }
                    if (ss.tbempfindlichkeit.Value == 3)
                    {
                        positionValue = (int)(((fractionValue * 8) * 668)) - 5;
                       // lblFineTuning.Text = "Empfindlichkeit: hoch";

                    }

                    if (ss.tbGlättung.Value == 1)
                    {
                        wertGlaettung = 3;
                        Glaettung(wertGlaettung);
                       // lblGlaettung.Text = "Glättungsstufe: 1";
                    }
                    if (ss.tbGlättung.Value == 2)
                    {
                        wertGlaettung = 4;
                        Glaettung(wertGlaettung);
                      //  lblGlaettung.Text = "Glättungsstufe: 2";
                    }
                    if (ss.tbGlättung.Value == 3)
                    {
                        wertGlaettung = 6;
                        Glaettung(wertGlaettung);
                       // lblGlaettung.Text = "Glättungsstufe: 3";
                    }

                    if (positionValue < 0)
                    {
                        positionValue = 0;
                    }
                    if (positionValue > 1350)
                    {
                        positionValue = 1350;
                    }
                    savedValues.Add(positionValue);

                    Glaettung(wertGlaettung);

                }

                counter++;
                auswertungsWerte.Add(pbx_downlocal.Location.X);

                c.Send("move:\\" + "lb" + "|" + Convert.ToString(Ball.Location.X) + "|" + Convert.ToString(Ball.Location.Y) + "|" + Convert.ToString(pbx_downlocal.Location.X) + "|" + Convert.ToString(pointsClient) + "|" + Convert.ToString(pointsServer));

            }
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.ToString());
            }
        }
        private void dgv_playfieldclient_KeyDown(object sender, KeyEventArgs e)
        {
            rbKeyboard.Checked = true;
            if (e.KeyCode == Keys.Right)
            {
                WertXlocal += 25;
                if (WertXlocal > 1350)
                {
                    WertXlocal = 1350;
                }
                pbx_downlocal.Location = new Point(WertXlocal, (int)player);

            }
            if (e.KeyCode == Keys.Left)
            {
                WertXlocal -= 25;
                if (WertXlocal < 70)
                {
                    WertXlocal = 70;
                }
                pbx_downlocal.Location = new Point(WertXlocal, (int)player);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            Ball.Left += speed_left;
            Ball.Top += speed_top;


            if (pbx_downlocal.Bounds.IntersectsWith(Ball.Bounds))
            {
                Ball.Location = new Point(Ball.Location.X, Ball.Location.Y - 13);
                speed_top -= 0;
                speed_left -= 0;
                speed_top = -speed_top;
            }

            if (pbx_upnetwork.Bounds.IntersectsWith(Ball.Bounds))
            {
                Ball.Location = new Point(Ball.Location.X, Ball.Location.Y + 13);
                speed_top -= 0;
                speed_left -= 0;
                speed_top = -speed_top;
            }
            if (Ball.Left < dgv_playfieldclient.Left)
            {
                speed_left = -speed_left;
            }
            if (Ball.Right > dgv_playfieldclient.Right - 200)
            {
                speed_left = -speed_left;
            }
            if (Ball.Top < dgv_playfieldclient.Top)
            {
                speed_top = -speed_top * (-1);
            }
            if (Ball.Bottom > dgv_playfieldclient.Bottom)
            {
                Ball.Visible = false;
                timer1.Enabled = false;
                Ball.Location = new Point(179, 134);
                Ball.Visible = true;
                timer1.Enabled = true;
                pointsClient++;
                points1.Text = pointsClient.ToString();
            }
            if (Ball.Top <= dgv_playfieldclient.Top)
            {
                Ball.Visible = false;
                timer1.Enabled = false;
                Ball.Location = new Point(179, 334);
                Ball.Visible = true;
                timer1.Enabled = true;
                pointsServer++;
                points2.Text = pointsServer.ToString();
            }
            counter++;

        }
        private void btnWerteAufzeichnen_Click(object sender, EventArgs e)
        {
            SaveFunction("savePong.txt");
        }
        #region Service/Request
        public void LogServiceinformation(string message)
        {
            if (message.Contains("Waiting for connection"))
            {
                lblSchrittEins.Text = "Korrektes IP-Netzwerk ausgewählt: ✓";
            }
            if (message.Contains("wird gesendet an"))
            {
                lblSchrittZwei.Text = "Verbindung zu Client hergestellt: ✓";
            }
        }

        public void LogRequestInformation(string message)
        {
                string[] msg = message.Split('|');
                string x = msg[1];
                if (message.Contains("l|"))
                {
                    lblSchrittDrei.Text = "Übertragung der Schlägerkoordinaten: ✓";
                }
                if (pbx_downlocal.InvokeRequired)
                {
                    pbx_upnetwork.Invoke(logRequestInformation, message);
                    WertXnetwork = Convert.ToInt32(msg[1]);
                }
                else
                {
                    pbx_upnetwork.Location = new Point(WertXnetwork, 65);
                }
            }
        #endregion
        #endregion
        #region Speech Recognition
        public void DefaultListenerGerman()
        {
            try
            {
                _recognizerservergerman.SetInputToDefaultAudioDevice();
                GrammarBuilder gb = new GrammarBuilder(new Choices(File.ReadAllLines(@"SpeechRecognitionEngineGerman\commandsserver.txt")));
                gb.Culture = new CultureInfo("de-DE");
                Grammar g = new Grammar(gb);
                _recognizerservergerman.LoadGrammar(g);
                _recognizerservergerman.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(DefaultServerGerman_SpeechRecognized);
                _recognizerservergerman.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.Message);
            }
        }

        public void DefaultListenerEnglish()
        {
            try
            {
                _recognizerserverenglish.SetInputToDefaultAudioDevice();
                GrammarBuilder gb = new GrammarBuilder(new Choices(File.ReadAllLines(@"SpeechRecognitionEngineEnglish\commandsserver.txt")));
                gb.Culture = new CultureInfo("en-GB");
                Grammar g = new Grammar(gb);
                _recognizerserverenglish.LoadGrammar(g);
                _recognizerserverenglish.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(DefaultServerEnglish_SpeechRecognized);
                _recognizerserverenglish.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.Message);
            }
        }
        private void DefaultServerGerman_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;
            if (cbSprachmodul.Checked == true)
            {
                if (speech == "Starte Server")
                {
                    if (counterstartserver < 1)
                    {
                        Start();
                        com.SpeakAsync("Server wurde gestartet");
                        counterstartserver++;
                    }
                    else
                    {
                        com.SpeakAsync("Server wurde bereits gestartet");
                    }
                }

                if (speech == "Verbinde zum Server")
                {
                    if (counterconnectserver < 1)
                    {
                        Connect();
                        com.SpeakAsync("Verbindung zum Server wurde hergestellt");
                        counterconnectserver++;
                    }
                    else
                    {
                        com.SpeakAsync("Verbindung zum Server wurde bereits hergestellt");
                    }
                }

                if (speech == "Starte das Spiel")
                {
                    if (counterstartgame < 1)
                    {
                        StartGame();
                        counterstartgame++;
                        cbSprachmodul.Checked = false;
                    }
                    else
                    {
                        com.SpeakAsync("Spiel wurde bereits gestartet");
                    }
                }

                if (speech == "Einstellungen")
                {
                    Settings();
                }
                if (speech == "Sound")
                {
                    EnableSound();
                }
                if (speech == "Tonfrequenz")
                {
                    EnableFrequenz();
                }
                if (speech == "Tastatur")
                {
                    EnableTastatur();
                    dgv_playfieldclient.Focus();
                }

                if (speech == "Menü ausblenden")
                {
                    Disablemenu();
                }
                if (speech == "Menü einblenden")
                {
                    Enablemenu();
                }
                if (speech == "Schließe das Spiel")
                {
                    CloseWindow();
                }
                if (speech == "Pause")
                {
                    Pause();
                }
                if (speech == "Fortfahren")
                {
                    Continue();
                }
                if (speech == "Welche Befehle gibt es?")
                {
                    MOVE.Shared.Help h = new MOVE.Shared.Help();
                    h.FillHelpResults("SpeechRecognitionEngineGerman\\commandsserver.txt");
                    h.ShowDialog();
                }
            }
        }
     
        private void DefaultServerEnglish_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;
            if (cbSprachmodul.Checked == true)
            {
                if (speech == "start server")
                {
                    if (counterstartserver < 1)
                    {
                        Start();
                        com.SelectVoice("Microsoft Hazel Desktop");
                        com.SpeakAsync("Server starting");
                        counterstartserver++;
                    }
                    else
                    {
                        com.SelectVoice("Microsoft Hazel Desktop");
                        com.SpeakAsync("Server has already been started");
                    }
                }

                if (speech == "connect to server")
                {
                    if (counterconnectserver < 1)
                    {
                        Connect();
                        com.SelectVoice("Microsoft Hazel Desktop");
                        com.SpeakAsync("Connection to the server has been established");
                        counterconnectserver++;
                    }
                    else
                    {
                        com.SelectVoice("Microsoft Hazel Desktop");
                        com.SpeakAsync("Connection to the server has already been established");
                    }
                }

                if (speech == "move it")
                {
                    if (counterstartgame < 1)
                    {
                        StartGame();
                        counterstartgame++;
                        cbSprachmodul.Checked = false;

                    }
                    else
                    {
                        com.SelectVoice("Microsoft Hazel Desktop");
                        com.SpeakAsync("Game has already been started");
                    }
                }
                if (speech == "settings")
                {
                    Settings();
                }
                if (speech == "sound")
                {
                    EnableSound();
                }
                if (speech == "frequency")
                {
                    EnableFrequenz();
                }
                if (speech == "keyboard")
                {
                    EnableTastatur();
                    dgv_playfieldclient.Focus();
                }

                if (speech == "disable menu")
                {
                    Disablemenu();
                }
                if (speech == "activate menu")
                {
                    Enablemenu();
                }
                if (speech == "exit the window")
                {
                    CloseWindow();
                }
                if (speech == "pause")
                {
                    Pause();
                }
                if (speech == "continue")
                {
                    Continue();
                }
                if (speech == "Which commands are avaiable?")
                {
                    MOVE.Shared.Help h = new MOVE.Shared.Help();
                    h.FillHelpResults("SpeechRecognitionEngineEnglish\\commandsserver.txt");
                    h.ShowDialog();
                }
            }
        }
        public void CancelDefaultGermanListener()
        {
            try
            {
                _recognizerservergerman.RecognizeAsyncStop();
            }
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.ToString());
            }
        }

        public void ActivateDefaultGermanListener()
        {
            try
            {
                _recognizerservergerman.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.ToString());
            }
        }
        public void CancelDefaultEnglishListener()
        {
            try
            {
                _recognizerserverenglish.RecognizeAsyncStop();
            }
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.ToString());
            }
        }

        public void ActivateDefaultEnglishListener()
        {
            try
            {
                _recognizerserverenglish.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.ToString());
            }
        }
        #endregion
        #region Methoden
        double screenheightvalue;
        double yourcomputerheightvalue;
        double yourcomputerheightvalue2;


        public void Start()
        {
            int port = Convert.ToInt32(ss.tbx_PortServer.Text);
            IPAddress ipaddress = IPAddress.Parse(ss.tbx_IPServer.Text);
            ts = new TcpService(port, this, ipaddress);
            t1 = new Thread(ts.Start)
            {
                IsBackground = true
            };
            t1.Start();
            btn_Start.Enabled = false;
        }
        public void Connect()
        {
            try
            {
                int port = Convert.ToInt32(ss.tbx_PortClient.Text);
                IPAddress ipaddress = IPAddress.Parse(ss.tbx_IPClient.Text);
                c = new Client(port, ipaddress);
                t2 = new Thread(c.Start)
                {
                    IsBackground = true
                };
                t2.Start();
                btn_Connect.Enabled = false;
            }
            catch (Exception ex)
            {

                elw.WriteErrorLog(ex.ToString());
            }
        }
        private void GetNewPanelLocation()
        {
            int bottomvaluedgv = dgv_playfieldclient.Bottom;
            yourcomputerheightvalue = bottomvaluedgv - 35;
        }

        private void DesignChangesGerman()
        {

        }

        private void DesignChangesEnglish()
        {
            btnSettings.Text = "Settings";
            btn_Connect.Text = "Connect";
            rBSound.Text = "Sound";
            rBFrequenz.Text = "Frequency";
            rbKeyboard.Text = "Keyboard";
            if (cbSprachmodul.Checked == true)
            {
                cbSprachmodul.Text = "Speech module activated";

            }
            if (cbSprachmodul.Checked == false)
            {
                cbSprachmodul.Text = "Speech module deactivated";
            }
            lblSchrittDrei.Text = "Transmission of the panel coordinates:";
            lblSchrittZwei.Text = "Connection to client established:";
            lblSchrittEins.Text = "Correct IP network selected:";
        }
      
        private void Settings()
        {
            ss.ShowDialog();
        }
        private void EnableSound()
        {
            rBSound.Checked = true;
            rBFrequenz.Checked = false;
            rbKeyboard.Checked = false;
        }
        private void EnableFrequenz()
        {
            rBSound.Checked = false;
            rBFrequenz.Checked = true;
            rbKeyboard.Checked = false;
        }
        private void EnableTastatur()
        {
            rBSound.Checked = false;
            rBFrequenz.Checked = false;
            rbKeyboard.Checked = true;
        }
        private void Disablemenu()
        {
           // cbAusblenden.Checked = true;
        }
        private void Enablemenu()
        {
            //cbAusblenden.Checked = false;
        }
        private void CloseWindow()
        {
            this.Close();
        }
        public void SaveFunction(string pfad)
        {
            FileStream fs = null;
            StreamWriter sw = null;
            try
            {
                fs = new FileStream(pfad, FileMode.Open);
                sw = new StreamWriter(fs);

                // Jede dieser Zeilen repräsentiert einen Eintrag in die .txt Datei
                for (int i = 0; i < auswertungsWerte.Count; i++)
                    sw.WriteLine(Convert.ToString(auswertungsWerte[i]));

                auswertungsWerte.Clear();

            }
            // Exceptions werden mit dieser MessageBox umgangen
            catch (IOException ex)
            {
                elw.WriteErrorLog(ex.ToString());
                MessageBox.Show("Hier ist ein Fehler entstanden!");
            }
            // Anschließend werden streamwriter und fiilestream geschlossen
            finally
            {
                sw.Close();
                fs.Close();
            }
        }

        private void GetSoundValues(object sender, WaveInEventArgs args)
        {

            float tempSoundValue = 0;

            // interpret as 16 bit audio
            for (int index = 0; index < args.BytesRecorded; index += 2)
            {
                short sample = (short)((args.Buffer[index + 1] << 8) |
                                        args.Buffer[index + 0]);
                var audioSample = sample / 32768f; // to floating point
                if (audioSample < 0) audioSample = -audioSample; // absolute value 
                if (audioSample > tempSoundValue) tempSoundValue = audioSample; // is this the max value?
            }

            // calculate what fraction this peak is of previous peaks
            if (tempSoundValue > soundValueOne)
            {
                soundValueOne = (double)tempSoundValue;
            }
            soundValueTwo = tempSoundValue;
            audioCount += 1;
        }
        public void Glaettung(int anzahl)
        {
            summe = 0;
            if (savedValues.Count == anzahl)
            {
                for (int i = 0; i < anzahl; i++)
                {
                    summe += savedValues[i];
                }
                average = summe / anzahl;
                mod = (average % anzahl);
                pbx_downlocal.Location = new Point((average - mod) + 75, (int)player);
                savedValues.Clear();
            }
        }
        private void StartGame()
        {
            timer2.Enabled = true;
            timer1.Enabled = true;
        }
        #endregion
        #region funktionslose Methoden
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void lsb_discover_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void dgv_playfieldclient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_Discover_Click(object sender, EventArgs e)
        {

        }

        private void lblGlaettung_Click(object sender, EventArgs e)
        {

        }

        private void tbGlaettung_Scroll(object sender, EventArgs e)
        {

        }

        private void Connection_Click(object sender, EventArgs e)
        {
        }

        private void dgv_playfieldclient_Click(object sender, EventArgs e)
        {

        }

        private void lblFineTuning_Click(object sender, EventArgs e)
        {

        }

        private void lblBallSpeed_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rBFrequenz_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lbl_Client_Click(object sender, EventArgs e)
        {
            if (lbl_Client.ForeColor == System.Drawing.Color.Lime)
            {
                Pause();
                return;
            }
            if (lbl_Client.ForeColor == System.Drawing.Color.Gray)
            {
                Continue();
                return;
            }
        }
        private void Pause()
        {
            try
            {

                lbl_Client.ForeColor = Color.Gray;
            panel1.BackColor = Color.Gray;
            panel2.BackColor = Color.Gray;
            panel3.BackColor = Color.Gray;
            panel4.BackColor = Color.Gray;
            panel5.BackColor = Color.Gray;
            panel6.BackColor = Color.Gray;
            panel7.BackColor = Color.Gray;
            panel8.BackColor = Color.Gray;
            c.Send("move:\\" + "s" + "|" + "Pause");
            timer1.Stop();
            }
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.Message);
            }
        }
        private void Continue()
        {
            try
            {

            lbl_Client.ForeColor = Color.Lime;
            panel1.BackColor = Color.Blue;
            panel2.BackColor = Color.Purple;
            panel3.BackColor = Color.Pink;
            panel4.BackColor = Color.Blue;
            panel5.BackColor = Color.Blue;
            panel6.BackColor = Color.Purple;
            panel7.BackColor = Color.Pink;
            panel8.BackColor = Color.Pink;
            c.Send("move:\\" + "s" + "|" + "Fortsetzen");
            timer1.Start();
        }
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.Message);
            }
        }

        private void rBFrequenz_Click(object sender, EventArgs e)
        {
            savedValues.Clear();
        }

        private void cbSprachmodul_CheckedChanged(object sender, EventArgs e)
        {
            if(cbSprachmodul.Checked == true)
            {
                cbSprachmodul.Text = "Sprachmodul aktiviert";

            }
            if (cbSprachmodul.Checked == false)
            {
                cbSprachmodul.Text = "Sprachmodul deaktiviert";
            }
        }
    }
}
#endregion
