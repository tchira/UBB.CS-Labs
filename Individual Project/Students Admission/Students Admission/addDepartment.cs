using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Students_Admission
{
    public partial class addDepartment : Form
    {
        private Department newDpt;

        public addDepartment()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            String name = textBox2.Text;
            int places = Convert.ToInt32(textBox3.Text);
            this.newDpt = new Department(id, name, places);
            this.Close();
        }

        public Department getCreatedDepartment()
        {
            return this.newDpt;
        }
    }
}
