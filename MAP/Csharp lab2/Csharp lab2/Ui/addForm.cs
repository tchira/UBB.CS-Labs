using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Csharp_lab2.Domain;

namespace Csharp_lab2.Ui
{
    public partial class addForm : Form
    {
        public Student newStudent { get; set; }
        public addForm()
        {
            InitializeComponent();
        }

        private void addForm_Load(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls.OfType<TextBox>())
                c.Enabled = false;

            foreach (RadioButton c in this.Controls.OfType<RadioButton>())
                c.Checked = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.idbox.Enabled = true;
            namebox.Enabled = true;
            thesisbox.Enabled = false;
            supbox.Enabled = false;
            gradebox1.Enabled = true;
            gradebox2.Enabled = false;
            gradebox3.Enabled = false;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.idbox.Enabled = true;
            namebox.Enabled = true;
            thesisbox.Enabled = false;
            supbox.Enabled = true;
            gradebox1.Enabled = true;
            gradebox2.Enabled = true;
            gradebox3.Enabled = true;

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            this.idbox.Enabled = true;
            namebox.Enabled = true;
            thesisbox.Enabled = false;
            supbox.Enabled = false;
            gradebox1.Enabled = true;
            gradebox2.Enabled = true;
            gradebox3.Enabled = false;

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            this.idbox.Enabled = true;
            namebox.Enabled = true;
            thesisbox.Enabled = true;
            supbox.Enabled = true;
            gradebox1.Enabled = true;
            gradebox2.Enabled = true;
            gradebox3.Enabled = true;
        }

        public Student getCreatedStudent()
        {
            return this.newStudent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked == true)
                {
                    newStudent = new Student(Convert.ToInt32(idbox.Text), namebox.Text, Convert.ToInt32(gradebox1.Text));
                }

                if (radioButton2.Checked == true)
                {
                    newStudent = new GraduateStudent(Convert.ToInt32(idbox.Text), namebox.Text, supbox.Text, Convert.ToInt32(gradebox1.Text), Convert.ToInt32(gradebox2.Text), Convert.ToInt32(gradebox3.Text));
                }

                if (radioButton3.Checked == true)
                {
                    newStudent = new UndergraduateStudent(Convert.ToInt32(idbox.Text), namebox.Text, Convert.ToInt32(gradebox1.Text), Convert.ToInt32(gradebox2.Text));
                }

                if (radioButton4.Checked == true)
                {
                    newStudent = new PhdStudent(Convert.ToInt32(idbox.Text), namebox.Text, supbox.Text, thesisbox.Text, Convert.ToInt32(gradebox1.Text), Convert.ToInt32(gradebox2.Text), Convert.ToInt32(gradebox3.Text));
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            this.Close();
            
        }
            

         
        
    }
}
