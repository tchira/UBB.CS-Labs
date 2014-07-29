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
using System.Data.Sql;
using System.Configuration;
using System.Collections.Specialized;


namespace DB_lab1
{
    public partial class Form1 : Form
    {
        BindingSource parentSource = new BindingSource();
        BindingSource childSource = new BindingSource();
        String cstring;
        SqlConnection connect;
        DataSet ds;
        SqlDataAdapter cda, pda;
        DataRelation dr;
        SqlCommandBuilder br;

        public Form1()
        {
            InitializeComponent();
        
            NameValueCollection sAll = new NameValueCollection();
         
            sAll = ConfigurationManager.AppSettings;
            this.Text = sAll.Get("FormTitle");
            parentGrid.DataSource = parentSource;
            childGrid.DataSource = childSource; 
            this.Width = Convert.ToInt32(sAll.Get("FormWidth"));
            this.Height = Convert.ToInt32(sAll.Get("FormHeight"));
            this.button1.Text = sAll.Get("But1Text");
            this.button2.Text = sAll.Get("But2Text");



            //cstring = sAll.Get("ConString");
            cstring = "Data Source=(localdb)\\Projects;Initial Catalog=Battlelog;Integrated Security=SSPI;";
            connect = new SqlConnection(cstring);

            ds = new DataSet();

          
            pda = new SqlDataAdapter(sAll.Get("ParentQuery"), cstring);
            cda = new SqlDataAdapter(sAll.Get("ChildQuery"), cstring);
            br = new SqlCommandBuilder(cda);

            
            pda.Fill(ds,"Clans");
           cda.Fill(ds, sAll.Get("ChildTable"));
            dr = new DataRelation("CPR", ds.Tables[sAll.Get("ParentTable")].Columns[sAll.Get("ParentRelColumn")], ds.Tables[sAll.Get("ChildTable")].Columns[sAll.Get("ChildRelColumn")]);
            ds.Relations.Add(dr);
           
            parentSource.DataSource = ds;
            parentSource.DataMember = sAll.Get("ParentTable");
            childSource.DataSource = parentSource;
            childSource.DataMember = "CPR";

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cda.Update(ds, "ClanPlayers");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            childGrid.Rows.RemoveAt(childGrid.CurrentRow.Index);
            cda.Update(ds, "ClanPlayers");
        }
    }
}
