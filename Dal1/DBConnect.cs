using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace Dal1
{
    public class DBConnect
    {
        MySqlConnectionStringBuilder connectionString;
        MySqlConnection connection;
        public DBConnect()
        {
            Initialize();
        }
        public void Initialize()
        {
            connectionString = new MySqlConnectionStringBuilder
            {
                Server = "35.204.48.1",
                UserID = "root",
                Password = "heartbot1234",
                Database = "heartbotdata",
                CertificateFile =Directory.GetCurrentDirectory()+ @"\client.pfx",
                SslCa = Directory.GetCurrentDirectory() + @"\server-ca.pem",
                SslMode = MySqlSslMode.None,
            };
            connection = new MySqlConnection(connectionString.ConnectionString);
        }
        public List<userWeb> getAllNames()
        {
            List<userWeb>  users= new List<userWeb>();
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM user";
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read() == true)
                {
                    userWeb u = new userWeb();
                    u.id = int.Parse(dataReader["id"].ToString());
                    u.idUser = dataReader["userid"].ToString();
                    u.name = dataReader["name"].ToString();
                    u.url = dataReader["url"].ToString();
                    u.@checked = bool.Parse(dataReader["checked"].ToString());
                    u.date = dataReader["date"].ToString();
                    u.score = int.Parse(dataReader["score"].ToString());
                    users.Add(u);
                }
                users.GroupBy(x => x.idUser).Select(x => x.First()).OrderBy(x => x.name).ToList();
                return users;
            }
            catch (Exception e) { throw e; }
        }
        public List<userWeb> getpdfByname(string iduser)
        {
            List<userWeb> users = new List<userWeb>();
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            try
            {
                cmd.CommandText = "SELECT * FROM USER WHERE userid=" + iduser;
                MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read() == true)
            {
                userWeb u = new userWeb();
                u.id = int.Parse(dataReader["id"].ToString());
                u.idUser = dataReader["userid"].ToString();
                u.name = dataReader["name"].ToString();
                u.url = dataReader["url"].ToString();
                u.@checked = bool.Parse(dataReader["checked"].ToString());
                u.date = dataReader["date"].ToString();
                u.score = int.Parse(dataReader["score"].ToString());
                users.Add(u);
            }
                connection.Close();
                return users;
            }
            catch (Exception e)
            { throw e; }
           
        }
        public List<userWeb> getAllNotChecked()
        {
            List<userWeb> users = new List<userWeb>();
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            try
            {
                cmd.CommandText = "SELECT * FROM USER WHERE checked=false";
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read() == true)
                {
                    userWeb u = new userWeb();
                    u.id = int.Parse(dataReader["id"].ToString());
                    u.idUser = dataReader["userid"].ToString();
                    u.name = dataReader["name"].ToString();
                    u.url = dataReader["url"].ToString();
                    u.@checked = bool.Parse(dataReader["checked"].ToString());
                    u.date = dataReader["date"].ToString();
                    u.score = int.Parse(dataReader["score"].ToString());
                    users.Add(u);
                }
                connection.Close();
                return users;
            }
            catch (Exception e)
            {
                throw e; }
         
        }
        public bool updateCheckedUser(int id)
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            try
            {
                cmd.CommandText = "update user set checked=true where id=" + id + ";";
                MySqlDataReader dataReader = cmd.ExecuteReader();
                connection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
    
        }
        public void Post(userWeb user)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO user(id,iduser,name,date,score,url,checked) VALUES(" + user.id + "," + user.idUser + "," + user.name + "," + user.date + "," + user.score + "," + user.url + "," + user.@checked + "," + ")";
                MySqlDataReader dataReader = cmd.ExecuteReader();
                connection.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
