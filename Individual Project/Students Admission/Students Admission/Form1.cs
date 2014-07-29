using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Students_Admission
{
    public partial class Form1 : Form
    {
        private Repository mod;
        private Controller cont;
        private Results res;
        private BindingSource candSource, dptSource;
        private List<Candidate> candidates;
        private List<Department> departments;

        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            mod = new Repository();
            cont = new Controller(mod,"candidates.txt","departments.txt");
            candidates = cont.getCandidates();
            departments = cont.getDepartments();

            dataGridView1.DataSource = candidates;
            dataGridView2.DataSource = departments;
            dataGridView1.Columns["CNP"].ReadOnly = true;
            dataGridView2.Columns["id"].ReadOnly = true;
            dataGridView1.Columns["gradeFinal"].ReadOnly = true;
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
         
            this.res= cont.getResults();
   
                //listBox1.Items.Add(name + " => " + res.admitted[name]);
            System.IO.StreamWriter outfile=new System.IO.StreamWriter("admitted.txt");
            
                            outfile.WriteLine("Admitted students:\n");
                            foreach (String name in res.admitted.Keys)
                                    outfile.WriteLine(name + " admitted to "+res.admitted[name]);
                             outfile.Close();
        

            //listBox2.Items.Clear();
                            System.IO.StreamWriter outfile2 = new System.IO.StreamWriter("rejected.txt");
                            outfile2.WriteLine("Rejected students:\n");
                            foreach (Candidate c in res.rejected)
                                outfile2.WriteLine(c.name);
                             outfile2.Close();
         
               // listBox2.Items.Add(c.name);


           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Statistics stats = new Statistics(this.res.stats);
            stats.Show();
        }

        private void dptLabel_Click(object sender, EventArgs e)
        {

        }

        private void addCandidate_Click(object sender, EventArgs e)
        {
            CandidateForm cForm = new CandidateForm(this.cont.getDepartments());
            cForm.ShowDialog();
            if ((cForm.getCreatedCandidate()) != null)
            {
                try
                {
                    this.cont.addCandidate(cForm.getCreatedCandidate());
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
                
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = cont.getCandidates();
            
            
            
           
           
           
            
        }

        private void delCandidate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                String cnp = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                cont.deleteCandidatebyCnp(cnp);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = cont.getCandidates();
            }
            else MessageBox.Show("No item selected");
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count != 0)
            {
                int did = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value);
                cont.deleteDepartmentById(did);
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = cont.getDepartments();
            }
            else
                MessageBox.Show("No item selected");
        }

        private void addDepartment_Click(object sender, EventArgs e)
        {
            addDepartment dForm = new addDepartment();
            dForm.ShowDialog();
            if ((dForm.getCreatedDepartment()) != null)
            {
                try
                {
                    this.cont.addDepartment(dForm.getCreatedDepartment());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = cont.getDepartments();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
        
           if(dataGridView1.Columns[e.ColumnIndex].Name=="gradeBac"||dataGridView1.Columns[e.ColumnIndex].Name=="gradeMI")

               dataGridView1.Rows[e.RowIndex].Cells[5].Value= (Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[3].Value)+ Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[4].Value))/2;
            
            cont.printCToFile();
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            cont.printDToFile();
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "name")
                try
                {
                    Validator.validateName(e.FormattedValue.ToString());
               }
                  catch (Exception ex){
                      MessageBox.Show(ex.Message);
                        e.Cancel = true;
                
                  }

            if (dataGridView1.Columns[e.ColumnIndex].Name == "gradeBac")
            {
                try
                {
                    Validator.validateGrade(Convert.ToDouble(e.FormattedValue));

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    e.Cancel = true;

                }
            }

                 if (dataGridView1.Columns[e.ColumnIndex].Name == "gradeMI")
                {
                   try{ Validator.validateGrade(Convert.ToDouble(e.FormattedValue));}
                   
                
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    e.Cancel = true;

                }
                 }

            
                  

        }

        private void dataGridView2_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dataGridView2.Columns[e.ColumnIndex].Name == "places")
                if (Convert.ToInt32(e.FormattedValue) < 0) {
                    MessageBox.Show("Cannot have negative places");
                    e.Cancel = true;
        }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start("admitted.txt");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start("rejected.txt");
        }
    }
}
