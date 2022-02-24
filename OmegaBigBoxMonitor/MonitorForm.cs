using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OmegaBigBoxMonitor
{
    public partial class MonitorForm : Form
    {
        String LaunchBoxPath;

        public MonitorForm()
        {
            InitializeComponent();
        }

        private void MonitorForm_Load(object sender, EventArgs e)
        {
            {
                int MonitorsRunning = 0;
                Process[] Processes = System.Diagnostics.Process.GetProcesses();
                for (int i = 0; i < Processes.Length; i++)
                {
                    if (Processes[i].ProcessName.StartsWith("OmegaBigBoxMonitor"))
                    {
                        MonitorsRunning++;
                    }
                }

                if(MonitorsRunning > 1)
                {
                    Application.Exit();
                }
            }

            LaunchBoxPath = Path.GetDirectoryName(Application.ExecutablePath).ToString();
            Log("Monitor started at " + DateTime.Now);
            Log("---------------------------");
            this.subscribe();
        }
        private void MonitorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (confirm_kill() == false)
                {
                    e.Cancel = true;
                    return;
                }
            }
            Log("Monitor closed at " + DateTime.Now);
            Log("---------------------------");
        }
        private bool confirm_kill()
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to close the monitor? If you do, BigBox will not be automitically restarted in the event of a crash.", "Kill Omega BigBox Monitor?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void MonitorForm_Shown(object sender, EventArgs e)
        {
            //Start in system tray by default. 
            this.Hide();
        }

        private void ShowMonitorMenuItem_Click(object sender, EventArgs e)
        {
            //Show form on right-click->show from system tray.
            this.Show();
            WindowState = FormWindowState.Normal;
        }

        private void MonitorForm_Resize(object sender, EventArgs e)
        {
            //On minimize, switch back to system tray
            if (FormWindowState.Minimized == WindowState)
                this.Hide();
        }

        private void hide_button_Click(object sender, EventArgs e)
        {
            //Switch to system tray when user clicks the hide button
            this.Hide();
        }

        private void kill_button_Click(object sender, EventArgs e)
        {
            //Close the monitor (we will prompt for confirmation in the close event).
            this.Close();
        }


        public void subscribe()
        {
            EventLogWatcher watcher = null;
            try
            {
                EventLogQuery subscriptionQuery =
                    new EventLogQuery("Application", PathType.LogName, "*[System/Provider/@Name=\"Application Error\"]");

                watcher = new EventLogWatcher(subscriptionQuery);

                // Make the watcher listen to the EventRecordWritten
                // events.  When this event happens, the callback method
                // (EventLogEventRead) is called.
                watcher.EventRecordWritten +=
                    new EventHandler<EventRecordWrittenEventArgs>(
                        EventLogEventRead);

                // Activate the subscription
                watcher.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Error subscribing to the event log.");
                this.Close();
            }
        }

        
        // Callback method that gets executed when an event is
        // reported to the subscription.
        public void EventLogEventRead(object obj,
            EventRecordWrittenEventArgs arg)
        {
            // Make sure there was no error reading the event.
            if (arg.EventRecord != null)
            {
                String eventDescription = arg.EventRecord.FormatDescription();

                if (eventDescription.Contains("BigBox"))
                {
                    Log("BigBox crash and recovery at " + DateTime.Now);
                    Log(eventDescription);
                    Log("---------------------------");

                    //Start external program which kills and restarts BigBox.
                    Process ps_bigbox = null;
                    ps_bigbox = new Process();
                    ps_bigbox.StartInfo.UseShellExecute = false;
                    ps_bigbox.StartInfo.RedirectStandardInput = false;
                    ps_bigbox.StartInfo.RedirectStandardOutput = false;
                    ps_bigbox.StartInfo.CreateNoWindow = true;
                    ps_bigbox.StartInfo.UserName = null;
                    ps_bigbox.StartInfo.Password = null;
                    ps_bigbox.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                    ps_bigbox.StartInfo.Arguments = "\"(Restarting BigBox)\"";
                    ps_bigbox.StartInfo.FileName = LaunchBoxPath + "/RebootBigBox.exe";

                    if (File.Exists(ps_bigbox.StartInfo.FileName))
                    {
                        bool result = ps_bigbox.Start();
                    }
                    else
                    {
                        MessageBox.Show("Missing " + ps_bigbox.StartInfo.FileName);
                    }

                }
            }
        }
        public void Log(String info)
        {
            String LogFileName = LaunchBoxPath + "/Logs/BigBoxMonitorLog.txt";
            StreamWriter sw = null;

            if (!Directory.Exists(Path.GetDirectoryName(LogFileName)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(LogFileName));
            }

            if (!File.Exists(LogFileName))
            {
                // Create a file to write to.
                sw = File.CreateText(LogFileName);
            }
            else
            {
                sw = File.AppendText(LogFileName);
            }

            if (sw != null)
            {
                sw.WriteLine(info);
                sw.Flush();
                sw.Close();
            }

            TextBox_Events.AppendText(info);
            TextBox_Events.AppendText("\r\n");
        }

    }
}
