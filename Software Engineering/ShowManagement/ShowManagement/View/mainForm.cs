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
using ShowManagement.View;
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

        private void enableManagerControls()
        {
            addButton.Enabled = true;
            delButton.Enabled = true;
            modButton.Enabled = true;
        }

        private void disableManagerControls()
        {
            addButton.Enabled = false;
            delButton.Enabled = false;
            modButton.Enabled = false;
        }

        private void enableClientControls()
        {
            this.reserveBut.Enabled = true;
            this.buyButton.Enabled = true;
            this.confirmBut.Enabled = true;
        }

        private void disableClientControls()
        {
            reserveBut.Enabled = false;
            buyButton.Enabled = false;
            confirmBut.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
           cstring = "Data Source=(localdb)\\Projects;Initial Catalog=ShowManagement;Integrated Security=SSPI;";
           sqlConnection = new SqlConnection(cstring);
           dataSet=new DataSet();
           bSource =new BindingSource();
           this.disableClientControls();
           this.disableManagerControls();
         
           showGrid.ReadOnly = true;
      
         
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
            int show = cont.findShowIdByName(showGrid.CurrentRow.Cells[1].Value.ToString());

            foreach (Ticket t in cont.getTickets())
                if (t.show == Convert.ToInt32(showGrid.CurrentRow.Cells[0].Value))
                {
                    chartTickets.Add(t);
                }
            SeatingChart sChart = new SeatingChart(chartTickets,loggedUser,show,false);
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
                    this.enableClientControls();
                    

                    if (logForm.getUser().isManager)
                    {
                        this.enableManagerControls();
                    }

                }
            }

            else
            {
                this.loginBut.Text = "Log in";
                this.label1.Text = "Not logged in";
                this.loggedUser = null;
                this.disableManagerControls();
                this.disableClientControls();
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

        private void modButton_Click(object sender, EventArgs e)
        {
            if (showGrid.SelectedRows.Count != 0)
            {
                Show s = cont.findShowByID((int)showGrid.SelectedRows[0].Cells[0].Value);
                modForm mForm = new modForm(s.id, s.name, s.date, this.cont);
                mForm.ShowDialog();
                bSource.DataSource = null;
                bSource.DataSource = cont.getShows();
            }
            else
                MessageBox.Show("No show selected");

        }

        private void buyButton_Click(object sender, EventArgs e)
        {
            List<Ticket> chartTickets = new List<Ticket>();
            int show = cont.findShowIdByName(showGrid.CurrentRow.Cells[1].Value.ToString());

            foreach (Ticket t in cont.getTickets())
                if (t.show == Convert.ToInt32(showGrid.CurrentRow.Cells[0].Value))
                {
                    chartTickets.Add(t);
                }
            SeatingChart sChart = new SeatingChart(chartTickets, loggedUser, show, true);
            sChart.ShowDialog();
            foreach (Ticket t in sChart.getNewReservations())
            {
                this.tickets.Add(t);
                this.cont.addTicket(t);
            }
        }

        private void showGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (loggedUser != null)
            {
                string bought = "";
                string reserved = "";
                int id = (int)showGrid.Rows[e.RowIndex].Cells[0].Value;
               
                foreach (Ticket t in cont.getAllUserTicketsForShow(this.loggedUser, id))
                    if (t.confirmed == false)
                        reserved += t.seat + ",";
                    else
                        bought += t.seat + ",";
                this.richTextBox1.Text = " Your tickets for " + showGrid.Rows[e.RowIndex].Cells[1].Value.ToString() + ":\n";
                this.richTextBox1.Text += "Reserved: " + reserved + "\n";
                this.richTextBox1.Text += "Bought: " + bought + "\n";




            }
        }

        private void confirmBut_Click(object sender, EventArgs e)
        {
            if (loggedUser != null)
            {
                string bought = "";
                string reserved = "";
                int id = (int)showGrid.SelectedRows[0].Cells[0].Value;

                foreach (Ticket t in cont.getAllUserTicketsForShow(this.loggedUser, id))
                {
                    t.confirmed = true;
                    cont.confirmTicket(t);

                    bought += t.seat + ",";
                }
                this.richTextBox1.Text = " Your tickets for " + showGrid.SelectedRows[0].Cells[1].Value.ToString() + ":\n";
                
                this.richTextBox1.Text += "Bought: " + bought + "\n";




            }
        }

        
    }
}
