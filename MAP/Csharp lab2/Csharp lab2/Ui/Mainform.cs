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
    class Mainform:Form
    {
        private Controller c;
        protected ListBox lbox;
        protected TextBox tbox;
       
        public Mainform(Controller cont)
        {
            
            this.c = cont;
            Text = "Student management";
            Size = new Size(350,270);
            this.CenterToScreen();
            Button but = new Button();
            but.Text = "Attempt to add student ...";
            but.Width = 130;
            but.Parent = this;
            but.Location = new Point(180, 175);
            but.Click+=new EventHandler(OnClickButton);

            Button delBut = new Button();
            delBut.Text = "Delete selected student";
            delBut.Width = 130;
            delBut.Parent = this;
            delBut.Location = new Point(180, 146);
            delBut.Click += new EventHandler(OnClickDelete);


            Label lb = new Label();
            lb.Parent = this;
            lb.Text = "Students:";
            lb.Location = new Point(0, 0);
            lbox = new ListBox();
            lbox.Parent = this;
            lbox.Height = 200;
            lbox.Width = 160;
            lbox.Location = new Point(0, 25);
            lbox.BorderStyle = BorderStyle.FixedSingle;
            foreach (Student s in c.getAll())
                lbox.Items.Add(s.ToString());




            Label radioLabel = new Label();
            radioLabel.Text = "Show students with:";
            radioLabel.Location = new Point(180, 10);
            radioLabel.Parent = this;
            radioLabel.Width = 150;

            RadioButton l5Radio = new RadioButton();
            l5Radio.Text = "Average less than 5";
            l5Radio.Location = new Point(180, 30);
            l5Radio.Parent = this;
            l5Radio.Width = 200;
            l5Radio.Click += new EventHandler(OnSelectL5);



            RadioButton g5Radio = new RadioButton();
            g5Radio.Text="Average greater than 5";
            g5Radio.Location=new Point(180,55);
            g5Radio.Parent=this;
            g5Radio.Width = 200;
            g5Radio.Click += new EventHandler(OnSelectG5);

            RadioButton a5Radio=new RadioButton();
            a5Radio.Location = new Point(180, 80);
            a5Radio.Text="Average equals to 10";
            a5Radio.Parent = this;
            a5Radio.Width = 200;
            a5Radio.Click += new EventHandler(OnSelectA5);

            RadioButton allRadio = new RadioButton();
            allRadio.Location = new Point(180, 105);
            allRadio.Text = "Show all students";
            allRadio.Parent = this;
            allRadio.Width = 200;
            allRadio.Click += new EventHandler(OnSelectAll);

           /* tbox = new TextBox();
           tbox.Location = new Point(180, 250);
           tbox.Width = 250;
           tbox.Parent = this;
           tbox.Show();
           Label label = new Label();
           label.Text = "Insert student data above, \ntype will be decided by number of parameters";
           label.Width = 400;
           label.Height = 40;
           label.Location = new Point(180, 280);
           label.Parent = this;

           Label l1 = new Label();
           l1.Text = "Student: id name grade \n(Example: 5 Costel 10)\nGraduate student: id name supervisor grade1 grade2 grade3\n(Example: 9 Ionut Chira 10 7 9)\nPhD Student: id name supervisor thesis grade1 grade2 grade3 \nUndergraduate student: id name grade1 grade2";
           l1.Width = 400;
           l1.Height = 300;
           l1.Location = new Point(180,320);
           l1.Parent = this;*/
         
           
          
        }

        protected void OnClickDelete(object sender, EventArgs e)
        {
            if (this.lbox.SelectedItem == null)
            {
                MessageBox.Show("No item selected");
            }

            else
            {

                int id = Convert.ToInt32(lbox.SelectedItem.ToString().Split(' ')[0]);
                this.lbox.Items.Remove(lbox.SelectedItem);
                this.c.removeStudent(id);

            }
        }

        protected void OnClickButton(object sender,EventArgs e)
        {
           addForm af = new addForm();
            Student newStudent;
            af.ShowDialog();
            try
            {
                newStudent = af.getCreatedStudent();
                if(newStudent!=null)
                    c.repo.addObject(af.getCreatedStudent());
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
           
            lbox.Items.Clear();
            foreach (Student s in c.getAll())
                lbox.Items.Add(s.ToString());

          /* String line = tbox.Text;
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
                lbox.Items.Add(s.ToString());*/
            
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

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Mainform
            // 
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Name = "Mainform";
            this.Load += new System.EventHandler(this.Mainform_Load);
            this.ResumeLayout(false);

        }

        private void Mainform_Load(object sender, EventArgs e)
        {

        }

    }
}
