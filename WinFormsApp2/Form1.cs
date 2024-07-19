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
            // Инициализация PerformanceCounter для мониторинга CPU и памяти

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer(); // Запуск таймера для обновления данных
            timer.Interval = 500; // Интервал обновления данных в миллисекундах
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Получение данных о CPU и RAM
            float cpuUsage = cpuCounter.NextValue();
            float availableRAM = ramCounter.NextValue();

            // Отображение данных на форме
            cpuLabel.Text = $"Загрузка процессора: {cpuUsage}%";
            ramLabel.Text = $"Доступная оперативная память: {availableRAM} MB";

            // Получение информации о дисках
            UpdateDiskInformation();
        }

        private void UpdateDiskInformation()
        {
            diskListBox.Items.Clear();

            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady) // Проверка готовности диска к использованию
                {
                    string freeSpace = $"{drive.TotalFreeSpace / (1024 * 1024 * 1024)} GB свободно";
                    string totalSpace = $"{drive.TotalSize / (1024 * 1024 * 1024)} GB всего";
                    string driveInfo = $"{drive.Name} - {drive.DriveFormat} - {freeSpace} / {totalSpace}";

                    diskListBox.Items.Add(driveInfo);
                }
            }
        }
    }
}
