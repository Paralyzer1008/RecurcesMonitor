using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 500;
            timer.Tick += Timer_Tick;
            timer.Start();

            InitializeCharts();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            float cpuUsage = cpuCounter.NextValue();
            float availableRAM = ramCounter.NextValue();

            cpuLabel.Text = $"Загрузка процессора: {cpuUsage}%";
            ramLabel.Text = $"Доступная оперативная память: {availableRAM} MB";

            UpdateDiskInformation();
            UpdateCharts(cpuUsage, availableRAM);
        }

        private void UpdateDiskInformation()
        {
            diskListBox.Items.Clear();

            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady)
                {
                    string freeSpace = $"{drive.TotalFreeSpace / (1024 * 1024 * 1024)} GB свободно";
                    string totalSpace = $"{drive.TotalSize / (1024 * 1024 * 1024)} GB всего";
                    string driveInfo = $"{drive.Name} - {drive.DriveFormat} - {freeSpace} / {totalSpace}";

                    diskListBox.Items.Add(driveInfo);
                }
            }
        }

        private void InitializeCharts()
        {
            // Настройки для графика процессора
            var cpuChartArea = new ChartArea("CPUChartArea")
            {
                AxisX =
                {
                    Title = "Время",
                    LabelStyle = { Format = "HH:mm:ss" }, // Форматирование оси X для отображения времени
                    IntervalType = DateTimeIntervalType.Seconds // Интервал для оси X
                },
                AxisY =
                {
                    Title = "Загрузка процессора (%)"
                }
            };
            cpuChart.ChartAreas.Add(cpuChartArea);
            cpuChart.Series.Add(new Series("CPU Usage")
            {
                Color = System.Drawing.Color.Red,
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.DateTime
            });
            cpuChart.Titles.Add("Загрузка процессора");

            // Настройки для графика оперативной памяти
            var ramChartArea = new ChartArea("RAMChartArea")
            {
                AxisX =
                {
                    Title = "Время",
                    LabelStyle = { Format = "HH:mm:ss" }, // Форматирование оси X для отображения времени
                    IntervalType = DateTimeIntervalType.Seconds // Интервал для оси X
                },
                AxisY =
                {
                    Title = "Доступная оперативная память (MB)"
                }
            };
            ramChart.ChartAreas.Add(ramChartArea);
            ramChart.Series.Add(new Series("Available RAM")
            {
                Color = System.Drawing.Color.Blue,
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.DateTime
            });
            ramChart.Titles.Add("Доступная оперативная память");
        }

        private void UpdateCharts(float cpuUsage, float availableRAM)
        {
            DateTime now = DateTime.Now;
            cpuChart.Series["CPU Usage"].Points.AddXY(now, cpuUsage);
            ramChart.Series["Available RAM"].Points.AddXY(now, availableRAM);

            // Удаляем точки, если их больше 60
            if (cpuChart.Series["CPU Usage"].Points.Count > 60)
            {
                cpuChart.Series["CPU Usage"].Points.RemoveAt(0);
            }
            if (ramChart.Series["Available RAM"].Points.Count > 60)
            {
                ramChart.Series["Available RAM"].Points.RemoveAt(0);
            }

            cpuChart.ChartAreas[0].RecalculateAxesScale();
            ramChart.ChartAreas[0].RecalculateAxesScale();
        }
    }
}
