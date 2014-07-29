namespace ShowManagement
{
    partial class SeatingChart
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
            this.button31 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Stage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button31
            // 
            this.button31.Location = new System.Drawing.Point(568, 275);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(65, 25);
            this.button31.TabIndex = 1;
            this.button31.Text = "Reserve ";
            this.button31.UseVisualStyleBackColor = true;
            this.button31.Click += new System.EventHandler(this.button31_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(565, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Picked seats";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(568, 47);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(65, 212);
            this.listBox1.TabIndex = 3;
            // 
            // Stage
            // 
            this.Stage.Enabled = false;
            this.Stage.Location = new System.Drawing.Point(131, 12);
            this.Stage.Name = "Stage";
            this.Stage.Size = new System.Drawing.Size(324, 135);
            this.Stage.TabIndex = 4;
            this.Stage.Text = "Stage";
            this.Stage.UseVisualStyleBackColor = true;
            this.Stage.Click += new System.EventHandler(this.Stage_Click);
            // 
            // SeatingChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 356);
            this.Controls.Add(this.Stage);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button31);
            this.Name = "SeatingChart";
            this.Text = "SeatingChart";
            this.Load += new System.EventHandler(this.SeatingChart_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button31;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button Stage;
    }
}