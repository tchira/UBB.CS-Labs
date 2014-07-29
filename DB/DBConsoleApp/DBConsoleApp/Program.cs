using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace DBConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {   String cstring="Data Source=(localdb)\\Projects;Initial Catalog=Battlelog;Integrated Security=SSPI;";
            SqlConnection connect = new SqlConnection(cstring);
            String query = "select name from dbo.Roles";
           
            connect.Open();
            SqlCommand command = new SqlCommand(query, connect);
            SqlDataReader reader = command.ExecuteReader();
            Console.WriteLine("Roles\n____________");
            while (reader.Read())
            {
                Console.WriteLine(reader[0]);
            }
            reader.Close();
            connect.Close();

            DataSet ds = new DataSet();
            SqlDataAdapter da=new SqlDataAdapter("select clanname from dbo.Clans",connect);
            SqlCommandBuilder scb = new SqlCommandBuilder(da);
            da.Fill(ds,"Clans");

            foreach(DataRow row in ds.Tables[0].Rows )
            {
                Console.WriteLine("Row");
                foreach (var item in row.ItemArray)
                {
                    Console.Write(item);
                }
            }
               
           /* DataTable dtable = ds.Tables[0];
            DataRow nrow = dtable.NewRow();
            nrow["clanid"] = "Newname";
            nrow["clanname"] = "newtext";
            dtable.Rows.Add(nrow);
            da.Update(ds,"TestTable");*/

            //Data relation, Binding source, data something something

            



        }
    }
}
