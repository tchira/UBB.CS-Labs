using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Students_Admission
{
    public partial class CandidateForm : Form
    {
       private Candidate cand;
       private List<Department> departments;
        
        public CandidateForm(List<Department> departments)
        {
            InitializeComponent();
            this.departments = departments;
        }
        
        public Candidate getCreatedCandidate()
        {
            return cand;
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {   List<int> options=new List<int>();
           

            foreach(String dpt in listBox2.Items)
                options.Add(Convert.ToInt32(dpt.Split(':')[0]));
            try
            {   String CNP=this.textBox1.Text;
                String name=textBox2.Text;
                String adr=textBox3.Text;
                double grade1=Convert.ToDouble(textBox4.Text);
                double grade2 = Convert.ToDouble(textBox5.Text);
                if (listBox2.Items.Count == 0)
                {
                    throw new Exception("No departments selected");
                }

                Validator.validateCNP(CNP);
                Validator.validateName(name);
                Validator.validateGrade(grade1);
                Validator.validateGrade(grade2);
                cand = new Candidate(CNP,name,adr,grade1,grade2,options);
                this.Close();
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message);
            }
            
        }

        private void CandidateForm_Load(object sender, EventArgs e)
        {
            foreach (Department d in departments)
                listBox1.Items.Add(d.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                listBox2.Items.Add(listBox1.SelectedItem);
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                listBox1.Items.Add(listBox2.SelectedItem);
                listBox2.Items.Remove(listBox2.SelectedItem);
            }
        }
    }
}
