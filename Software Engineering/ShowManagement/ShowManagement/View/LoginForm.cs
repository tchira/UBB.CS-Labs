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

namespace ShowManagement
{
    public partial class LoginForm : Form
    {
        private Controller cont;
        private User user;

        public LoginForm(Controller c)
        {
            InitializeComponent();
            this.cont = c;
        }

        public User getUser()
        {
            return this.user;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username = textBox1.Text;
            String password = textBox2.Text;
            bool found=false;
            foreach (User client in cont.getUsers())
            {
                
                if (client.name == username)
                {
                    found = true;
                    if (password == client.password)
                    {
                        this.user = client;
                        this.Close();
                    }

                    else
                    {
                        MessageBox.Show("Wrong password");
                    }
                }
            }

                if (found==false)
                    MessageBox.Show("User not found in database");
        }

        private void button2_Click(object sender, EventArgs e)
        {
       

        }

                

            

        
    }
}
