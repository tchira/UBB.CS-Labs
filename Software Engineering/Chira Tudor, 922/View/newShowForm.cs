using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShowManagement
{
    public partial class newShowForm : Form
    {
        private Controller cont;
        public newShowForm(Controller c)
        {
            this.cont = c;
            InitializeComponent();
        }

      

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String showName = textBox1.Text;
            DateTime date = dateTimePicker1.Value.Date;
            cont.addShow(showName, date);
            this.Close();
        }
    }
}
