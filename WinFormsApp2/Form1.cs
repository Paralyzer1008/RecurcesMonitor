using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        private PerformanceCounter cpuCounter;
        private PerformanceCounter ramCounter;

        public Form1()
        {
            InitializeComponent();

           
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total", true);
            ramCounter = new PerformanceCounter("Memory", "Available MBytes", true);
            // ������������� PerformanceCounter ��� ����������� CPU � ������

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer(); // ������ ������� ��� ���������� ������
            timer.Interval = 500; // �������� ���������� ������ � �������������
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // ��������� ������ � CPU � RAM
            float cpuUsage = cpuCounter.NextValue();
            float availableRAM = ramCounter.NextValue();

            // ����������� ������ �� �����
            cpuLabel.Text = $"�������� ����������: {cpuUsage}%";
            ramLabel.Text = $"��������� ����������� ������: {availableRAM} MB";

            // ��������� ���������� � ������
            UpdateDiskInformation();
        }

        private void UpdateDiskInformation()
        {
            diskListBox.Items.Clear();

            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady) // �������� ���������� ����� � �������������
                {
                    string freeSpace = $"{drive.TotalFreeSpace / (1024 * 1024 * 1024)} GB ��������";
                    string totalSpace = $"{drive.TotalSize / (1024 * 1024 * 1024)} GB �����";
                    string driveInfo = $"{drive.Name} - {drive.DriveFormat} - {freeSpace} / {totalSpace}";

                    diskListBox.Items.Add(driveInfo);
                }
            }
        }
    }
}
