namespace WinFormsApp2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cpuLabel = new System.Windows.Forms.Label();
            this.ramLabel = new System.Windows.Forms.Label();
            this.diskListBox = new System.Windows.Forms.ListBox();
            this.cpuChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ramChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.cpuChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ramChart)).BeginInit();
            this.SuspendLayout();
            // 
            // cpuLabel
            // 
            this.cpuLabel.AutoSize = true;
            this.cpuLabel.Location = new System.Drawing.Point(12, 9);
            this.cpuLabel.Name = "cpuLabel";
            this.cpuLabel.Size = new System.Drawing.Size(116, 13);
            this.cpuLabel.TabIndex = 0;
            this.cpuLabel.Text = "Загрузка процессора:";
            // 
            // ramLabel
            // 
            this.ramLabel.AutoSize = true;
            this.ramLabel.Location = new System.Drawing.Point(12, 32);
            this.ramLabel.Name = "ramLabel";
            this.ramLabel.Size = new System.Drawing.Size(155, 13);
            this.ramLabel.TabIndex = 1;
            this.ramLabel.Text = "Доступная оперативная память:";
            // 
            // diskListBox
            // 
            this.diskListBox.FormattingEnabled = true;
            this.diskListBox.Location = new System.Drawing.Point(12, 58);
            this.diskListBox.Name = "diskListBox";
            this.diskListBox.Size = new System.Drawing.Size(400, 173);
            this.diskListBox.TabIndex = 2;
            // 
            // cpuChart
            // 
            this.cpuChart.Location = new System.Drawing.Point(430, 58);
            this.cpuChart.Name = "cpuChart";
            this.cpuChart.Size = new System.Drawing.Size(400, 200);
            this.cpuChart.TabIndex = 3;
            this.cpuChart.Text = "cpuChart";
            // 
            // ramChart
            // 
            this.ramChart.Location = new System.Drawing.Point(430, 270);
            this.ramChart.Name = "ramChart";
            this.ramChart.Size = new System.Drawing.Size(400, 200);
            this.ramChart.TabIndex = 4;
            this.ramChart.Text = "ramChart";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 511);
            this.Controls.Add(this.ramChart);
            this.Controls.Add(this.cpuChart);
            this.Controls.Add(this.diskListBox);
            this.Controls.Add(this.ramLabel);
            this.Controls.Add(this.cpuLabel);
            this.Name = "Form1";
            this.Text = "Монитор ресурсов";
            ((System.ComponentModel.ISupportInitialize)(this.cpuChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ramChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label cpuLabel;
        private System.Windows.Forms.Label ramLabel;
        private System.Windows.Forms.ListBox diskListBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart cpuChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart ramChart;
    }
}
