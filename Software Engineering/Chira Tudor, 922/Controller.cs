using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ShowManagement.Model;
using ShowManagement.Repository;

namespace ShowManagement
{   
   
    public class Controller
    {       
           private String cstring;
        private SqlConnection sqlConnection;
        private ShowRepo sRepo;
        private TicketRepo tRepo;
        private UserRepo uRepo;
       

        public Controller(ShowRepo sr,TicketRepo tr, UserRepo ur)
        {
            cstring = "Data Source=(localdb)\\Projects;Initial Catalog=ShowManagement;Integrated Security=SSPI;";
            sqlConnection = new SqlConnection(cstring);
            sRepo = sr;
            tRepo = tr;
            uRepo = ur;
            this.readShows();
            this.readTickets();
            this.readUsers();
            
           
        }

        private void readTickets()
        {
            tRepo.tickets.Clear();
            sqlConnection.Open();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Tickets", sqlConnection))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int client = reader.GetInt32(0);
                    int seat = reader.GetInt32(1);
                    int show = reader.GetInt32(2);
                    DateTime date = reader.GetDateTime(3);
                    Boolean confirmed = reader.GetBoolean(4);
                    tRepo.tickets.Add(new Ticket(client, seat, show, date, confirmed));
                }
            }
            sqlConnection.Close();
        }

        private void readShows()
        {
            sqlConnection.Open();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Shows", sqlConnection))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int sID = reader.GetInt32(0);
                    String name = reader.GetString(1);
                    DateTime date = reader.GetDateTime(2);

                    sRepo.shows.Add(new Show(sID, name, date));
                }
            }
            sqlConnection.Close();
        }

       

        public void deleteShowById(int id)
        {
            int del=0;
           for (int i = 0; i < sRepo.shows.Count; i++)
               if (sRepo.shows[i].id == id)
                   del = i;
            sRepo.shows.RemoveAt(del);


            SqlCommand cmd = new SqlCommand("delete from Shows where sID = " + id.ToString(),sqlConnection);
            sqlConnection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            sqlConnection.Close();


        }

        public User findUserByName(String name)
        {
            foreach (User c in uRepo.users)
                if (c.name == name)
                    return c;
            return null;
        }
        
        public void addTicket(Ticket t) {
            this.tRepo.tickets.Add(t);
            SqlCommand cmd = new SqlCommand("InsertTicket", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@client",t.client);
            cmd.Parameters.AddWithValue("@seat", t.seat);
            cmd.Parameters.AddWithValue("@show", t.show);
            cmd.Parameters.AddWithValue("@date", t.date);
            cmd.Parameters.AddWithValue("@confirmed", t.confirmed);

         sqlConnection.Open();
            cmd.ExecuteNonQuery();
           sqlConnection.Close();
        }

        public void addShow(String showName,DateTime date)
        {
            SqlCommand cmd = new SqlCommand("insertShow", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", showName);
            cmd.Parameters.AddWithValue("@dt", date);
            sqlConnection.Open();
            int id = (int)cmd.ExecuteScalar();
            sqlConnection.Close();
            this.sRepo.shows.Add(new Show(id, showName, date));
        }
       
        public void addClient(String name,String pass,String addr,bool isManager)
        {
            SqlCommand cmd = new SqlCommand("insertClient", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@pass", pass);
            cmd.Parameters.AddWithValue("@adr", addr);
            cmd.Parameters.AddWithValue("@isManager", isManager);
            sqlConnection.Open();
            int id = (int)cmd.ExecuteScalar();
            sqlConnection.Close();
            if(isManager)
                this.uRepo.users.Add(new Manager(id, name, pass, addr, isManager));
            else
                this.uRepo.users.Add(new Client(id, name, pass, addr, isManager));

        }

     

        public void readUsers()
        {
            uRepo.users.Clear();
            sqlConnection.Open();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Users", sqlConnection))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int cid = reader.GetInt32(0);
                    String name = reader.GetString(1).Trim();
                    String pass = reader.GetString(2).Trim();
                    String adr = reader.GetString(3).Trim();
                    Boolean isManager = reader.GetBoolean(4);

                    if (isManager)
                        this.uRepo.users.Add(new Manager(cid, name, pass, adr, isManager));
                    else
                        this.uRepo.users.Add(new Client(cid, name, pass, adr, isManager));
                }
            }
            sqlConnection.Close();
            
        }

        public List<User> getUsers()
        {
            return uRepo.getUsers();
        }

        public List<Show> getShows()
        {
            return sRepo.getShows();
        }
        public List<Ticket> getTickets()
        {
            return tRepo.getTickets();
        }

       
    }
}
