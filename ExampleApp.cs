using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace ExampleApp
{
    public partial class ExampleApp : Form
    {
        private System.Timers.Timer CheckAppTimer;
        private string HomeDir;
        private bool Running;

        public ExampleApp()
        {
            InitializeComponent();

            WindowState = FormWindowState.Minimized;

            System.Reflection.Assembly currentExe = System.Reflection.Assembly.GetExecutingAssembly();
            HomeDir = Path.GetDirectoryName(currentExe.Location);

            LoadConfig();
            Running = true;

            CheckAppTimer = new System.Timers.Timer(500);
            CheckAppTimer.Elapsed += new System.Timers.ElapsedEventHandler(CheckAppTimer_Elapsed);
            CheckAppTimer.Start();
        }
                
        void CheckAppTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            CheckProcess();
        }

        /// <summary>
        /// Select application to watch
        /// </summary>
        private void SelectApplication() 
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (DialogResult.OK == ofd.ShowDialog())
            {
                textBox_application.Text = ofd.FileName;
                SaveConfig(ofd.FileName);
            }
        }

        /// <summary>
        /// Checks for process indicated in textbox is running if the global variable Running is set to true
        /// </summary>
        private void CheckProcess() 
        {
            // if Running is set to true, check for process
            if (Running)
            {
                if (!String.IsNullOrEmpty(textBox_application.Text))
                {
                    string fullPath = textBox_application.Text;
                    // get the name of the application to check for from the filepath
                    string app = Path.GetFileNameWithoutExtension(fullPath);
                    // get a list of processes that match the application name and attempt to start
                    // if none found
                    if (Process.GetProcessesByName(app).Length < 1)
                    {
                        UpdateLogAsync("process missing, attempting to start");
                        try
                        {
                            Process proc = new Process();
                            proc.StartInfo.FileName = fullPath;
                            proc.StartInfo.WorkingDirectory = Path.GetDirectoryName(fullPath);
                            proc.Start();
                            UpdateLogAsync("process successfully restarted");
                        }
                        catch (Exception ex)
                        {
                            UpdateLogAsync("error restarting application: " + ex.Message);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Toggle the global vairable Running, then change the text on the button
        /// </summary>
        private void ToggleStop() 
        {
            if (Running)
            {
                UpdateLogAsync("stopping process check");
                Running = false;
                button_stop.Text = "start";
            }
            else 
            {
                UpdateLogAsync("starting process check");
                Running = true;
                button_stop.Text = "stop";
            }
        }
        
        private void ClearApp() 
        {
            textBox_application.Clear();
        }
        
        #region config file
        
        /// <summary>
        /// Attempt to load configuration file from working directory
        /// </summary>
        private void LoadConfig() 
        {            
            try
            {
                TextReader sr = new StreamReader(HomeDir + "//config");
                textBox_application.Text = sr.ReadToEnd();
                sr.Close();
                UpdateLogAsync("config file found");
            }
            catch { UpdateLogAsync("config file not found"); }
            
        }

        /// <summary>
        /// Attempt to save config file to working directory
        /// </summary>
        /// <param name="text">File path of application to check</param>
        private void SaveConfig(string text)
        {
            try
            {
                TextWriter tr = new StreamWriter(HomeDir + "/config");
                tr.Write(text);
                tr.Close();
                UpdateLogAsync("saved config");
            }
            catch { UpdateLogAsync("error saving config"); }
 
        }

        #endregion config file

        #region log window code

        /// <summary>
        /// Delegate for adding text item to listbox
        /// </summary>
        /// <param name="text">Text to add to listbox at position 0</param>
        delegate void UpdateLogDelegate(string text);

        /// <summary>
        /// Add a text item to first position of listbox
        /// </summary>
        /// <param name="text">Text to add to listbox</param>
        private void UpdateLog(string text)
        {
            listBox_log.Items.Insert(0, text);
        }

        /// <summary>
        /// Threadsafe function to add a text item to the first position of listbox
        /// </summary>
        /// <param name="text">Text to add to listbox</param>
        private void UpdateLogAsync(string text)
        {
            // if attemping to access the listbox form a separate thread, use delegate
            if (InvokeRequired)
            {
                // catch any errors that may occur while attempting to update listbox 
                // (ex. ObjectDisplosedException)
                try
                {
                    UpdateLogDelegate uld = new UpdateLogDelegate(UpdateLog);
                    Invoke(uld, text);
                }
                catch { }
            }
            // else, update listbox directly
            else
                UpdateLog(text); 
        }

        #endregion log window code

        /* GUI hooks code below */

        private void button_select_Click(object sender, EventArgs e)
        {
            SelectApplication();
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            ClearApp();
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            ToggleStop();
        }
    }
}
