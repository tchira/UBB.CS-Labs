namespace ShowManagement
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
            this.showGrid = new System.Windows.Forms.DataGridView();
            this.reserveBut = new System.Windows.Forms.Button();
            this.loginBut = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.delButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.regButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.showGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // showGrid
            // 
            this.showGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.showGrid.Location = new System.Drawing.Point(12, 12);
            this.showGrid.Name = "showGrid";
            this.showGrid.Size = new System.Drawing.Size(415, 265);
            this.showGrid.TabIndex = 0;
            // 
            // reserveBut
            // 
            this.reserveBut.Location = new System.Drawing.Point(6, 19);
            this.reserveBut.Name = "reserveBut";
            this.reserveBut.Size = new System.Drawing.Size(123, 24);
            this.reserveBut.TabIndex = 1;
            this.reserveBut.Text = "Reserve seats";
            this.reserveBut.UseVisualStyleBackColor = true;
            this.reserveBut.Click += new System.EventHandler(this.button1_Click);
            // 
            // loginBut
            // 
            this.loginBut.Location = new System.Drawing.Point(135, 19);
            this.loginBut.Name = "loginBut";
            this.loginBut.Size = new System.Drawing.Size(114, 24);
            this.loginBut.TabIndex = 2;
            this.loginBut.Text = "Login >>";
            this.loginBut.UseVisualStyleBackColor = true;
            this.loginBut.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Controls.Add(this.loginBut);
            this.groupBox1.Controls.Add(this.reserveBut);
            this.groupBox1.Location = new System.Drawing.Point(447, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(255, 265);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User panel";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(6, 49);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(243, 210);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.addButton);
            this.groupBox2.Controls.Add(this.delButton);
            this.groupBox2.Location = new System.Drawing.Point(708, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(141, 109);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Manager controls";
            // 
            // delButton
            // 
            this.delButton.Location = new System.Drawing.Point(6, 66);
            this.delButton.Name = "delButton";
            this.delButton.Size = new System.Drawing.Size(126, 29);
            this.delButton.TabIndex = 0;
            this.delButton.Text = "Delete selected show";
            this.delButton.UseVisualStyleBackColor = true;
            this.delButton.Click += new System.EventHandler(this.button5_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(738, 232);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Not logged in";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(6, 32);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(126, 28);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add new show";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // regButton
            // 
            this.regButton.Location = new System.Drawing.Point(723, 254);
            this.regButton.Name = "regButton";
            this.regButton.Size = new System.Drawing.Size(108, 23);
            this.regButton.TabIndex = 6;
            this.regButton.Text = "Register ";
            this.regButton.UseVisualStyleBackColor = true;
            this.regButton.Click += new System.EventHandler(this.regButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 303);
            this.Controls.Add(this.regButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.showGrid);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.showGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView showGrid;
        private System.Windows.Forms.Button reserveBut;
        private System.Windows.Forms.Button loginBut;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button delButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button regButton;
    }
}

