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

namespace DBLab1
{
    public partial class MainForm : Form
    {
        BindingSource parentSource = new BindingSource();
        BindingSource childSource = new BindingSource();
        String cstring;
        SqlConnection connect;
        DataSet ds;
        SqlDataAdapter cda, pda;
        DataRelation dr;
        SqlCommandBuilder br;


        public MainForm()
        {

            InitializeComponent();
           

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            NameValueCollection sAll;
            sAll = ConfigurationManager.AppSettings;
            cstring = ConfigurationManager.AppSettings.Get("ConString");
            connect = new SqlConnection(cstring);
            ds = new DataSet();
            pda = new SqlDataAdapter(ConfigurationManager.AppSettings.Get("ParentQuery"), connect);
            cda = new SqlDataAdapter(ConfigurationManager.AppSettings.Get("ChildQuery"), connect);
            pda.Fill(ds, ConfigurationManager.AppSettings.Get("ParentTable"));
            cda.Fill(ds, ConfigurationManager.AppSettings.Get("ChildTable"));
            dr = new DataRelation("ClanPlayersRel", ds.Tables[sAll.Get("ParentTable")].Columns[sAll.Get("ParentRelColumn")], ds.Tables[sAll.Get("ChildTable")].Columns[sAll.Get("ChildRelColumn")]);
            ds.Relations.Add(dr);
            parentSource.DataSource = ds;
            parentSource.DataMember = sAll.Get("ParentTable");
            childSource.DataSource = ds;
            childSource.DataMember = "ClanPlayersRel";
        }
    }
}
