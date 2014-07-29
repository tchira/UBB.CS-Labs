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
    public partial class registerForm : Form
    {
        private Controller cont;

        public registerForm(Controller c)
        {
            this.cont = c;
           
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {   bool isManager=false;
            if(radioButton2.Checked==true)
                isManager=true;
            if (cont.findUserByName(textBox1.Text) == null){
                cont.addClient(textBox1.Text, textBox2.Text, textBox3.Text, isManager);
                this.Close();
            }
            else MessageBox.Show("Username taken");
            
        }

        private void registerForm_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
