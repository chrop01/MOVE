﻿using MOVE.Shared;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Start
{
    /// <summary>
    /// Interaktionslogik für Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        #region Klasseninstanzierungen
        SpeechRecognitionEngine _recognizergerman = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("de-DE"));
        SpeechRecognitionEngine _recognizerenglish = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-GB"));
        SpeechSynthesizer com = new SpeechSynthesizer();
        SpeechControl si = new SpeechControl();
        ErrorLogWriter elw = new ErrorLogWriter();
        int counter = 0;
        int speechvalue;
        int speechmodulevalue;
        #endregion
        #region klassengenerierte Methoden
        public Settings()
        {
            InitializeComponent();
            string language = ConfigurationManager.AppSettings["language"];
            speechvalue = Convert.ToInt32(language);
            string speechmodule = ConfigurationManager.AppSettings["speechmodule"];
            speechmodulevalue = Convert.ToInt32(speechmodule);
            this.Focus();
            if (speechvalue == 0)
            {
                DesignChangesGerman();
            }
            if (speechvalue == 1)
            {
                DesignChangesEnglish();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RadioButtonIsChecked();
            RadioButtonIsChecked2();
            RadioButtonIsChecked3();
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {

        }
        private void Window_Activated(object sender, EventArgs e)
        {
            if (speechmodulevalue == 1)
            {
                if (speechvalue == 0)
                {
                    ActivateDefaultListenerSettingsGerman();
                }
                else if (speechvalue == 1)
                {
                    ActivateDefaultListenerSettingsEnglish();
                }
            }
            else
            {
                //
            }
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            if (speechmodulevalue == 1)
            {
                if (speechvalue == 0)
                {
                    CancelDefaultListenerSettingsGerman();
                }
                else if (speechvalue == 1)
                {
                    CancelDefaultListenerSettingsEnglish();
                }
            }
            else
            {
                //
            }
        }
        #endregion
        #region Speech Recognition

        private void DefaultSettingsGerman_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;

            if (speech == "Empfindlichkeit leicht")
            {
                SetEmpfindlichkeitleicht();
            }

            if (speech == "Empfindlichkeit mittel")
            {
                SetEmpfindlichkeitmittel();
            }

            if (speech == "Empfindlichkeit stark")
            {
                SetEmpfindlichkeitschwer();
            }

            if (speech == "Glättung leicht")
            {
                SetGlättungleicht();
            }

            if (speech == "Glättung mittel")
            {
                SetGlättungmittel();
            }

            if (speech == "Glättung stark")
            {
                SetGlättungschwer();
            }
            if (speech == "speichern")
            {
               Save();
               
               com.SpeakAsync("Die Einstellungen wurden gespeichert");
            }
            if (speech == "Sprachmodul aktivieren")
            {
                Setspeechmoduleactive();
            }
            if (speech == "Deaktiviere Sprachmodul")
            {
                Setspeechmoduledeactive();
            }
            if (speech == "Stelle Sprache auf Deutsch")
            {
                SetLanguageGerman();
            }
            if (speech == "Stelle Sprache auf Englisch")
            {
                SetLanguageEnglish();
            }
            if (speech == "Schließe das Fenster")
            {
                CloseWindow();
                CancelDefaultListenerSettingsGerman();
            }
            if (speech == "Welche Befehle gibt es?")
            {
                MOVE.Shared.Help h = new MOVE.Shared.Help();
                h.FillHelpResults("SpeechRecognitionEngineGerman\\commandssettings.txt");
                h.ShowDialog();
            }
        }

        private void DefaultSettingsEnglish_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;

            if (speech == "sensitivity one")
            {
                SetEmpfindlichkeitleicht();
            }

            if (speech == "sensitivity two")
            {
                SetEmpfindlichkeitmittel();
            }

            if (speech == "sensitivity three")
            {
                SetEmpfindlichkeitschwer();
            }

            if (speech == "smoothing one")
            {
                SetGlättungleicht();
            }

            if (speech == "smoothing two")
            {
                SetGlättungmittel();
            }

            if (speech == "smoothing three")
            {
                SetGlättungschwer();
            }
            if (speech == "save")
            {
                Save();
                //this.Cursor = new Cursor(System.AppDomain.CurrentDomain.BaseDirectory + "\\MOVECursor.cur");
                com.SelectVoice("Microsoft Hazel Desktop");
                com.SpeakAsync("The settings were saved");
               // this.Cursor = new Cursor(System.AppDomain.CurrentDomain.BaseDirectory + "\\SuccessCursor.cur");
            }
            if (speech == "speechmodule active")
            {
                Setspeechmoduleactive();
            }
            if (speech == "deactivate speechmodule")
            {
                Setspeechmoduledeactive();
            }
            if (speech == "set language to german")
            {
                SetLanguageGerman();
            }
            if (speech == "set language to english")
            {
                SetLanguageEnglish();
            }
            if (speech == "exit")
            {
                CloseWindow();
                CancelDefaultListenerSettingsGerman();
            }
            if (speech == "Which commands are avaiable?")
            {
                MOVE.Shared.Help h = new MOVE.Shared.Help();
                h.FillHelpResults("SpeechRecognitionEngineEnglish\\commandssettings.txt");
                h.ShowDialog();
            }
        }
        #endregion
        #region Methoden
        private void CloseWindow()
        {
            this.Close();
        }
        private void DesignChangesGerman()
        {

        }
        private void DesignChangesEnglish()
        {
            rb_einfach.Content = "one";
            rb_mittel.Content = "two";
            rb_schwer.Content = "three";
            rb_modell1.Content = "one";
            rb_modell2.Content = "two";
            rb_modell3.Content = "three";
            rb_speechmoduleactivated.Content = "activate";
            rb_speechmoduledeactivated.Content = "deactivate";
            rb_speechmodulegerman.Content = "German";
            rb_speechmoduleenglish.Content = "English";
            lblemp.Content = "Sensitivity";
            lblg.Content = "Smoothinglevel";
            lbls.Content = "Language";
            lblsm.Content = "Speechmodule";
            btn_save.Content = "save";
        }
        private void Save()
        {
            RadioButtonIsChecked();
            RadioButtonIsChecked2();
            RadioButtonIsChecked3();
        }
        private void SetEmpfindlichkeitleicht()
        {
            rb_einfach.IsChecked = true;
        }
        private void SetEmpfindlichkeitmittel()
        {
            rb_mittel.IsChecked = true;
        }
        private void SetEmpfindlichkeitschwer()
        {
            rb_schwer.IsChecked = true;
        }
        private void SetGlättungleicht()
        {
            rb_modell1.IsChecked = true;
        }

        private void SetGlättungmittel()
        {
            rb_modell2.IsChecked = true;
        }

        private void SetGlättungschwer()
        {
            rb_modell3.IsChecked = true;
        }
        private void Setspeechmoduleactive()
        {
            rb_speechmoduleactivated.IsChecked= true;
        }
        private void Setspeechmoduledeactive()
        {
            rb_speechmoduledeactivated.IsChecked = true;
        }
        private void SetLanguageEnglish()
        {
            rb_speechmoduleenglish.IsChecked = true;
        }
        private void SetLanguageGerman()
        {
            rb_speechmodulegerman.IsChecked = true;
        }

        public void RadioButtonIsChecked()
        {
            if (rb_einfach.IsChecked == true)
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["sensitivity"].Value = "1";
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            if (rb_mittel.IsChecked == true)
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["sensitivity"].Value = "2";
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            if (rb_schwer.IsChecked == true)
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["sensitivity"].Value = "3";
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }
        public void RadioButtonIsChecked2()
        {
            if (rb_modell1.IsChecked == true)
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["smoothing"].Value = "1";
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            if (rb_modell2.IsChecked == true)
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["smoothing"].Value = "2";
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            if (rb_modell3.IsChecked == true)
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["smoothing"].Value = "3";
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }
        public void RadioButtonIsChecked3()
        {

            Warning w = new Warning();
            if (rb_speechmoduleactivated.IsChecked == true && speechmodulevalue==0)
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["speechmodule"].Value = "1";
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                //Application.Current.Shutdown();
                //System.Windows.Forms.Application.Restart();
                w.ShowDialog();
            }
            if (rb_speechmoduledeactivated.IsChecked == true && speechmodulevalue == 1)
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["speechmodule"].Value = "0";
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                //Application.Current.Shutdown();
                //System.Windows.Forms.Application.Restart();
                w.ShowDialog();
            }

            if (rb_speechmoduleenglish.IsChecked == true && speechvalue==0)
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["language"].Value = "1";
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                //Application.Current.Shutdown();
                //System.Windows.Forms.Application.Restart();
                w.ShowDialog();
            }
            if (rb_speechmodulegerman.IsChecked == true && speechvalue == 1)
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["language"].Value = "0";
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                //Application.Current.Shutdown();
                //System.Windows.Forms.Application.Restart();
                w.ShowDialog();
            }
        }
       
      
        public void CancelDefaultListenerSettingsGerman()
        {
            try
            {
                _recognizergerman.RecognizeAsyncStop();
            }
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.ToString());
            }
        }

        public void ActivateDefaultListenerSettingsGerman()
        {
            if (counter < 1)
            {
                counter++;
                try
                {
                    _recognizergerman.SetInputToDefaultAudioDevice();
                    GrammarBuilder gb = new GrammarBuilder(new Choices(File.ReadAllLines(@"SpeechRecognitionEngineGerman\commandssettings.txt")));
                    gb.Culture = new CultureInfo("de-DE");
                    Grammar g = new Grammar(gb);
                    _recognizergerman.LoadGrammar(g);
                    _recognizergerman.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(DefaultSettingsGerman_SpeechRecognized);
                    _recognizergerman.RecognizeAsync(RecognizeMode.Multiple);
                }
                catch (Exception ex)
                {
                    elw.WriteErrorLog(ex.ToString());
                }
            }
            else
            {


                try
                {
                    _recognizergerman.RecognizeAsync(RecognizeMode.Multiple);
                }
                catch (Exception ex)
                {
                    elw.WriteErrorLog(ex.ToString());
                }
            }
        }
        public void CancelDefaultListenerSettingsEnglish()
        {
            try
            {
                _recognizerenglish.RecognizeAsyncStop();
            }
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.ToString());
            }
        }

       public void ActivateDefaultListenerSettingsEnglish()
        {
            if (counter < 1)
            {
                counter++;
                try
                {
                    _recognizerenglish.SetInputToDefaultAudioDevice();
                    GrammarBuilder gb = new GrammarBuilder(new Choices(File.ReadAllLines(@"SpeechRecognitionEngineEnglish\commandssettings.txt")));
                    gb.Culture = new CultureInfo("en-GB");
                    Grammar g = new Grammar(gb);
                    _recognizerenglish.LoadGrammar(g);
                    _recognizerenglish.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(DefaultSettingsEnglish_SpeechRecognized);
                    _recognizerenglish.RecognizeAsync(RecognizeMode.Multiple);
                }
                catch (Exception ex)
                {
                    elw.WriteErrorLog(ex.ToString());
                }
            }
            else
            {


                try
                {
                    _recognizerenglish.RecognizeAsync(RecognizeMode.Multiple);
                }
                catch (Exception ex)
                {
                    elw.WriteErrorLog(ex.ToString());
                }
            }
        }
        #endregion


    }
}
