using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using ShowManagement.Model;
namespace ShowManagement
{
    public partial class Form1 : Form
    {
        private User loggedUser;
        private Controller cont;
        SqlConnection sqlConnection;
        String cstring;
        DataSet dataSet;
        BindingSource bSource;
       
        private List<Ticket> tickets;
       
            
        public Form1(Controller c)
        {
            this.cont = c;
            InitializeComponent();
            tickets = new List<Ticket>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            addButton.Enabled = false;
            delButton.Enabled = false;
           cstring = "Data Source=(localdb)\\Projects;Initial Catalog=ShowManagement;Integrated Security=SSPI;";
           sqlConnection = new SqlConnection(cstring);
           dataSet=new DataSet();
           bSource = new BindingSource();
           reserveBut.Enabled = false;
           showGrid.ReadOnly = true;
      
         
           //bSource.DataSource=dataSet;
           //bSource.DataMember = "Shows";
           bSource.DataSource = cont.getShows();
            showGrid.DataSource = bSource;
           this.tickets = cont.getTickets();          


        }

        private void button5_Click(object sender, EventArgs e)
        {
            int id = (int)showGrid.SelectedRows[0].Cells[0].Value;
            this.cont.deleteShowById(id);
            bSource.DataSource = null;
            bSource.DataSource = cont.getShows();
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Ticket> chartTickets = new List<Ticket>();

            foreach (Ticket t in cont.getTickets())
                if (t.show == Convert.ToInt32(showGrid.CurrentRow.Cells[0].Value))
                {
                    chartTickets.Add(t);
                }
            SeatingChart sChart = new SeatingChart(chartTickets,loggedUser);
            sChart.ShowDialog();
            foreach (Ticket t in sChart.getNewReservations())
            {
                this.tickets.Add(t);
                this.cont.addTicket(t);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.loggedUser == null)
            {

                LoginForm logForm = new LoginForm(this.cont);
                logForm.ShowDialog();
                if (logForm.getUser() != null)
                {
                    this.loggedUser = logForm.getUser();
                    this.label1.Text = "Logged in as " + loggedUser.name;
                    this.loginBut.Text = " Log out";
                    this.reserveBut.Enabled = true;

                    if (logForm.getUser().isManager)
                    {
                        delButton.Enabled = true;
                        addButton.Enabled = true;
                    }

                }
            }

            else
            {
                this.loginBut.Text = "Log in";
                this.label1.Text = "Not logged in";
                this.loggedUser = null;
                this.reserveBut.Enabled = false;
                this.addButton.Enabled = false;
                this.delButton.Enabled = false;
            }



        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            newShowForm showForm = new newShowForm(this.cont);
            showForm.ShowDialog();
            bSource.DataSource = null;
            bSource.DataSource = cont.getShows();
            
        }

        private void regButton_Click(object sender, EventArgs e)
        {
            registerForm regForm = new registerForm(this.cont);
            regForm.ShowDialog();
        }

        
    }
}
