using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Csharp_lab2.controller;
using Csharp_lab2.Domain;

namespace Csharp_lab2.Ui
{
    public partial class MainformOld:Form
    {
        private Controller c;
        protected ListBox lbox;
        protected TextBox tbox;
       
        public MainformOld(Controller cont)
        {
            this.c = cont;
            Text = "Student management";
            Size = new Size(500, 400);
            this.CenterToScreen();
            Button but = new Button();
            but.Text = "Attempt to add student";
            but.Width = 150;
            but.Parent = this;
            but.Location = new Point(180, 20);
            but.Click+=new EventHandler(OnClickButton);
            
            lbox = new ListBox();
            lbox.Parent = this;
            lbox.Height = 200;
            lbox.Width = 160;
            lbox.BorderStyle = BorderStyle.FixedSingle;
            foreach (Student s in c.getAll())
                lbox.Items.Add(s.ToString());

            RadioButton l5Radio = new RadioButton();
            l5Radio.Text = "Average less than 5";
            l5Radio.Location = new Point(20, 240);
            l5Radio.Parent = this;
            l5Radio.Width = 200;
            l5Radio.Click += new EventHandler(OnSelectL5);

            RadioButton g5Radio = new RadioButton();
            g5Radio.Text="Average greater than 5";
            g5Radio.Location=new Point(20,265);
            g5Radio.Parent=this;
            g5Radio.Width = 200;
            g5Radio.Click += new EventHandler(OnSelectG5);

            RadioButton a5Radio=new RadioButton();
            a5Radio.Location = new Point(20, 290);
            a5Radio.Text="Average equals to 10";
            a5Radio.Parent = this;
            a5Radio.Width = 200;
            a5Radio.Click += new EventHandler(OnSelectA5);

            RadioButton allRadio = new RadioButton();
            allRadio.Location = new Point(20, 310);
            allRadio.Text = "Show all students";
            allRadio.Parent = this;
            allRadio.Width = 200;
            allRadio.Click += new EventHandler(OnSelectAll);

            tbox = new TextBox();
            tbox.Parent = this;
            tbox.Location = new Point(180, 60);
            tbox.Width = 250;
            Label label = new Label();
            label.Text = "Insert student data above, \ntype will be decided by number of parameters";
            label.Width = 400;
            label.Height = 200;
            label.Location = new Point(180, 90);
            label.Parent = this;

        }

        protected void OnClickButton(object sender,EventArgs e)
        {
            String line = tbox.Text;
            String[] tokens = line.Split(' ');
            int length = tokens.Length;
            try
            {
                switch (length)
                {
                    case 3:
                        Student s1 = new Student(Convert.ToInt32(tokens[0]), tokens[1], Convert.ToInt32(tokens[2]));
                        c.repo.addObject(s1);
                        break;
                    case 4:
                        UndergraduateStudent s2 = new UndergraduateStudent(Convert.ToInt32(tokens[0]), tokens[1], Convert.ToInt32(tokens[2]), Convert.ToInt32(tokens[3]));
                        c.repo.addObject(s2);
                        break;
                    case 6:
                        GraduateStudent s3 = new GraduateStudent(Convert.ToInt32(tokens[0]), tokens[1], tokens[2], Convert.ToInt32(tokens[3]), Convert.ToInt32(tokens[4]), Convert.ToInt32(tokens[5]));
                        c.repo.addObject(s3);
                        break;
                    case 7:
                        PhdStudent s4 = new PhdStudent(Convert.ToInt32(tokens[0]), tokens[1], tokens[2], tokens[3], Convert.ToInt32(tokens[4]), Convert.ToInt32(tokens[5]), Convert.ToInt32(tokens[6]));
                        c.repo.addObject(s4);
                        break;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);       
            }

            lbox.Items.Clear();
            foreach (Student s in c.getAll())
                lbox.Items.Add(s.ToString());

        }

        protected void OnSelectL5(object sender, EventArgs e)
        {   lbox.Items.Clear();
        foreach (Student s in c.getAll())
            if (s.getAverage() < 5)
                lbox.Items.Add(s.ToString());
        }

        protected void OnSelectG5(object sender, EventArgs e)
        {
            lbox.Items.Clear();
            foreach (Student s in c.getAll())
                if (s.getAverage() >= 5)
                    lbox.Items.Add(s.ToString());
        }

        protected void OnSelectA5(object sender, EventArgs e)
        {
            lbox.Items.Clear();
            foreach (Student s in c.getAll())
                if (s.getAverage() == 10)
                    lbox.Items.Add(s.ToString());
        }

        protected void OnSelectAll(object sender, EventArgs e)
        {
            lbox.Items.Clear();
            foreach (Student s in c.getAll())
                lbox.Items.Add(s.ToString());
        }

        private void MainformOld_Load(object sender, EventArgs e)
        {

        }

    }
}
