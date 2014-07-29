using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamenMAP_C
{
    class Mainform : Form
    {

       private Controller c;
        public ListBox lbox;
        public TextBox tbox;
       
        public Mainform(Controller cont)
        {
            this.c = cont;
            Text = "Transaction management";
            Size = new Size(500, 400);
            this.CenterToScreen();
            Button but = new Button();
            but.Text = "Show all";
            but.Width = 150;
            but.Parent = this;
            but.Location=new Point(230,60);
            but.Click+=new EventHandler(OnClickButton);

            Button filt=new Button();
            filt.Text = "Filter transaction by date";
            filt.Width = 150;
            filt.Parent = this;
            filt.Location=new Point(270,20);
            filt.Click+=new EventHandler(OnClickFilter);

            lbox=new ListBox();
            lbox.Parent=this;
            lbox.Height=300;
            lbox.Width=200;
            lbox.BorderStyle=BorderStyle.FixedSingle;

            tbox = new TextBox();
            tbox.Parent = this;
            tbox.Width = 200;
            tbox.Location = new Point(230, 100);
            Label lab = new Label();
            lab.Text = "Insert data here, as :\n start month,start year,end month, end year,zone";
            lab.Width = 400;
            lab.Height = 200;
            lab.Parent = this;
            lab.Location = new Point(230, 140);
        }

        private void OnClickButton(object sender, EventArgs e)
        {
            lbox.Items.Clear();
            foreach (Transaction t in c.getAll())
                lbox.Items.Add(t.ToString());
        }

        private void OnClickFilter(object sender, EventArgs e)
        {
            lbox.Items.Clear();
            String line = tbox.Text;
            String[] tokens = line.Split(',');
            int smonth = Convert.ToInt32(tokens[0]);
            int syear = Convert.ToInt32(tokens[1]);
            int emonth = Convert.ToInt32(tokens[2]);
            int eyear = Convert.ToInt32(tokens[3]);
            String zone = tokens[4];
            foreach (Transaction t in c.getAll())

                if (t.item.zone.Equals(tokens[4]))
                {


                    if ((t.year >= syear) && (t.year < eyear) && (t.month > smonth))
                        lbox.Items.Add(t.ToString());

                    else
                        if (t.year == eyear && t.month <= emonth)
                            lbox.Items.Add(t.ToString());
                }
                    

        }
    }
}
