﻿using System;
using System.Threading;
using System.Management;
using WindowsFormsApplication2;


namespace IntegrateOS
{
    public partial class format : MetroFramework.Forms.MetroForm
    {
        public WindowsFormsApplication2.Form11 test;
        public static bool FormatDrive(string driveLetter, string label = "", string fileSystem = "NTFS", bool quickFormat = true,
                int clusterSize = 8192, bool enableCompression = false)
        {
            if (driveLetter.Length != 2 || driveLetter[1] != ':' || !char.IsLetter(driveLetter[0]))
                return false;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"select * from Win32_Volume WHERE DriveLetter = '" + driveLetter + "'");
            foreach (ManagementObject vi in searcher.Get())
            {
                vi.InvokeMethod("Format", new object[]
              { fileSystem, quickFormat,clusterSize, label, enableCompression });
            }

            return true;

        }
        int format_type_cluster;
        string format_type_fileSystem, partition_name_type;
        bool format_type_quickformat;
        
        public format(string s, string partition_name, int clusterSize, string fileSystem, bool quickFormat)
        {
           
            InitializeComponent();
            format_type_cluster = clusterSize;
            format_type_fileSystem = fileSystem;
            format_type_quickformat = quickFormat;
            partition_name_type = partition_name;
            metroLabel2.Text = s;
            metroLabel2.Refresh();
        }

        Thread temp;
        public bool maximum;
        public bool Get()
        {
            return maximum;
        }
        private void format_Load(object sender, EventArgs e)
        {
            temp = new Thread(
                        () =>
                        {
                            if (FormatDrive(metroLabel2.Text, partition_name_type, format_type_fileSystem, format_type_quickformat, format_type_cluster) == true)
                            {
                                Invoke(new Action(() =>
                                {
                                    maximum = true;
                                    var form2 = new Form13();
                                    this.Hide();
                                    form2.Show();
                                    temp.Abort();
                                }));
                            }
                            else
                            {

                                Invoke(new Action(() =>
                                {
                                    temp.Abort();
                                }));
                            }

                        })
            {
                IsBackground = true
            };
            temp.Start();
            if(maximum == true)
            {
                this.Close();
                test.Hide();
            }
        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel3_Click(object sender, EventArgs e)
        {

        }
    }
}
