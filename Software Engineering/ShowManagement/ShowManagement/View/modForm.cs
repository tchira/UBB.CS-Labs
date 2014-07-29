using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShowManagement.Model;
using ShowManagement.Control;

namespace ShowManagement.View
{
    public partial class modForm : Form
    {
     
        private int showID;
        private Controller cont;
        public modForm(int sid,string Name,DateTime Date,Controller c)
        {
            
            InitializeComponent();
            this.showID = sid;

            dateTimePicker1.Value = Date;
            this.textBox1.Text = Name;
            this.showID = sid;
            this.cont = c;
        }

        private void modForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {   
                string newName=textBox1.Text;
                DateTime newDate=dateTimePicker1.Value;
                Validator.validateString(newName);
                cont.modifyShow(this.showID, newName, newDate);
                this.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}
