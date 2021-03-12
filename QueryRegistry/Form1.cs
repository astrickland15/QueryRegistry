using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.ServiceProcess;


namespace QueryRegistry
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<string> UpdatedComputers = new List<string>();
        List<string> ComputersRequringKeys = new List<string>();

        List<string> ComputerList = new List<string>()
            {
            "<pcNames>"


        };
        //Update PCs
        private void button1_Click(object sender, EventArgs e)
        {

            foreach (string computer in ComputerList)
            {
                try
                {
                    // set registry path and set it as writable
                    RegistryKey path = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, computer).OpenSubKey
                        ("SOFTWARE\\Policies\\Microsoft\\Windows", true);

                    if (path == null)
                    {
                        //create WindowsUpdate subkey
                        RegistryKey WUkey = path.CreateSubKey("WindowsUpdate");

                        // Open WindowsUpdate Key
                        WUkey.OpenSubKey("WindowsUpdate");

                        //write to remote WindowsUpdate key
                        WUkey.SetValue("WUServer", "http://<ipAddress>:8530", RegistryValueKind.String);
                        WUkey.SetValue("WUStatusServer", "http://<ipAddress>:8530", RegistryValueKind.String);
                        WUkey.SetValue("ElevateNonAdmins", 1, RegistryValueKind.DWord);
                        WUkey.SetValue("TargetGroupEnabled", 1, RegistryValueKind.DWord);

                        if (computer.ToLower() == "<pcName>")
                        {
                            WUkey.SetValue("TargetGroup", "WU Test Machine", RegistryValueKind.String);
                        }

                        else
                        {
                            WUkey.SetValue("TargetGroup", "WSUS_Win10Computers", RegistryValueKind.String);
                        }

                        // add AU subkey
                        RegistryKey AUkey = WUkey.CreateSubKey("AU");

                        // write to remote AU key
                        AUkey.SetValue("IncludeRecommendedUpdates", 1, RegistryValueKind.DWord);
                        AUkey.SetValue("UseWUServer", 1, RegistryValueKind.DWord);
                        AUkey.SetValue("DetectionFrequencyEnabled", 1, RegistryValueKind.DWord);
                        AUkey.SetValue("DetectionFrequency", 4, RegistryValueKind.DWord);
                        AUkey.SetValue("AutoInstallMinorUpdates", 1, RegistryValueKind.DWord);
                        AUkey.SetValue("RescheduleWaitTimeEnabled", 0, RegistryValueKind.DWord);
                        AUkey.SetValue("NoAutoRebootWithLoggedOnUsers", 1, RegistryValueKind.DWord);
                        AUkey.SetValue("NoAutoUpdate", 0, RegistryValueKind.DWord);
                        AUkey.SetValue("AUOptions", 4, RegistryValueKind.DWord);
                        AUkey.SetValue("ScheduledInstallDay", 4, RegistryValueKind.DWord);
                        AUkey.SetValue("ScheduledInstallTime", 16, RegistryValueKind.DWord);

                        UpdatedComputers.Add(computer);


                    }
                }

                catch
                {
                    MessageBox.Show(String.Format("hmmm, {0} is not connected to the Network!", computer), "Rut Roh");
                }
            }
            //confirmation of updated computers
            var message = DisplayListOfComputers(UpdatedComputers);
            if (message != "")
            {
                MessageBox.Show("Updated Registry for: \n\n" + message);
            }
            else
            {
                MessageBox.Show("No Updates Necessary.");
            }

        }


        //check PCs
        private void button2_Click(object sender, EventArgs e)
        {
            foreach (string computer in ComputerList)
            {
                try
                {
                    RegistryKey remotePath = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, computer).OpenSubKey
                        ("SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate", true);



                    if (remotePath == null)
                    {
                        ComputersRequringKeys.Add(computer);
                    }

                }
                catch
                {
                    MessageBox.Show("Hmmm, can't connect to " + computer);
                }
            }
            //confirmation of updated computers
            var message = DisplayListOfComputers(ComputersRequringKeys);
            if (message != "")
            {
                MessageBox.Show("Keys Missing for the Following: \n\n" + message);
            }
            else
            {
                MessageBox.Show("All Computers Up to Date");
            }

            MessageBox.Show("Check Complete");


        }


        public static String DisplayListOfComputers(List<string> testList)
        {
            return String.Join(Environment.NewLine, testList);
        }
    }
}









