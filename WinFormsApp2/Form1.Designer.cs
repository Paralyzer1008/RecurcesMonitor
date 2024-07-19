namespace WinFormsApp2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cpuLabel = new System.Windows.Forms.Label();
            this.ramLabel = new System.Windows.Forms.Label();
            this.diskListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // cpuLabel
            // 
            this.cpuLabel.AutoSize = true;
            this.cpuLabel.Location = new System.Drawing.Point(12, 9);
            this.cpuLabel.Name = "cpuLabel";
            this.cpuLabel.Size = new System.Drawing.Size(67, 13);
            this.cpuLabel.TabIndex = 0;
            this.cpuLabel.Text = "Загрузка процессора:";
            // 
            // ramLabel
            // 
            this.ramLabel.AutoSize = true;
            this.ramLabel.Location = new System.Drawing.Point(12, 32);
            this.ramLabel.Name = "ramLabel";
            this.ramLabel.Size = new System.Drawing.Size(85, 13);
            this.ramLabel.TabIndex = 1;
            this.ramLabel.Text = "Доступная оперативная память: ";
            // 
            // diskListBox
            // 
            this.diskListBox.FormattingEnabled = true;
            this.diskListBox.Location = new System.Drawing.Point(12, 58);
            this.diskListBox.Name = "diskListBox";
            this.diskListBox.Size = new System.Drawing.Size(400, 173);
            this.diskListBox.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 246);
            this.Controls.Add(this.diskListBox);
            this.Controls.Add(this.ramLabel);
            this.Controls.Add(this.cpuLabel);
            this.Name = "Form1";
            this.Text = "Монитор ресурсов";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label cpuLabel;
        private System.Windows.Forms.Label ramLabel;
        private System.Windows.Forms.ListBox diskListBox;
    }
}
