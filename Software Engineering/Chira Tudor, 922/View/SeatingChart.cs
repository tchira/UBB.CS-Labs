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
    public partial class SeatingChart : Form
    {
       
        private List<Ticket> chartTickets;
        private List<Ticket> newReservations;
        private int show, client, reservationCount = 0;
        private DateTime date;
        public SeatingChart(List<Ticket> tickets, User c)
        {
            chartTickets = tickets;
            show = chartTickets[0].show;
            client = c.cid;
            
            newReservations = new List<Ticket>();
            date = new DateTime();
            InitializeComponent();
        }

        private void SeatingChart_Load(object sender, EventArgs e)
        {   List<Button> buttons=new List<Button>();
            int y=200;
            int x=150;

            for (int j = 0; j < 5; j++)
            {
                for (int i = 1; i <= 10; i++)
                {
                    Button but = new Button();
                    but.Parent = this;
                    but.Width = 30;
                    but.Location = new Point(x, y);
                    but.Text = ((j * 10) + i).ToString();
                    x += 30;
                    buttons.Add(but);
                    but.Click += new EventHandler(reserveSeat);

                }
                y += 30;
                x = 150;
            }

           
            foreach (Ticket t in chartTickets)
            {
               
                int i = t.seat;
                buttons[i-1].Enabled = false;
                if (t.confirmed == true)
                    buttons[i-1].BackColor = Color.Red;
                else
                    buttons[i-1].BackColor = Color.Yellow;
                
                if (t.client == this.client)
                {
                    reservationCount++;
                    buttons[i - 1].BackColor = Color.Purple;
                }
            }

          

            

        }

        private void reserveSeat(object sender, EventArgs e)
        {
            if (listBox1.Items.Count < 5-reservationCount)
            {
                Button button = (Button)sender;
                button.Enabled = false;
                button.BackColor = Color.Yellow;
                this.listBox1.Items.Add(button.Text);
            }
            else
                MessageBox.Show("Maximum seats for reservation : 5");
        }

        private void Stage_Click(object sender, EventArgs e)
        {
            
        }

        private void button31_Click(object sender, EventArgs e)
        {
            foreach(String s in this.listBox1.Items)
                newReservations.Add(new Ticket(this.client,Convert.ToInt32(s),show,DateTime.Now,false));
            this.Close();
        }

        public List<Ticket> getNewReservations()
        {
            return this.newReservations;
        }
    }
}
