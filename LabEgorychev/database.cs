using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;


namespace LabEgorychev
{
    class database
    {
        MySqlConnection Connection;
        MySqlConnectionStringBuilder Connect = new MySqlConnectionStringBuilder();

        public database(string server, string user, string pass, string database)
        {
            Connect.Server = server;
            Connect.UserID = user;
            Connect.Password = pass;
            Connect.Port = 3306;
            Connect.Database = database;
            Connect.CharacterSet = "utf8";
            Connection = new MySqlConnection(Connect.ConnectionString);
        }
        public long download(string name, string telephone, string work, DateTime date, int staj, string information)
        {
            MySqlCommand command = Connection.CreateCommand();
            command.CommandText = "INSERT INTO mis(name, telephone, work, date, staj, information) VALUES(?name, ?telephone, ?work, ?date, ?staj, ?information)";
            command.Parameters.Add("?name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("?telephone", MySqlDbType.VarChar).Value = telephone;
            command.Parameters.Add("?work", MySqlDbType.VarChar).Value = work;
            command.Parameters.Add("?date", MySqlDbType.DateTime).Value = date;
            command.Parameters.Add("?staj", MySqlDbType.Int32).Value = staj;
            command.Parameters.Add("?information", MySqlDbType.VarChar).Value = information;
            try
            {
                Connection.Open();
                command.ExecuteNonQuery();
                return command.LastInsertedId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Connection.Close();
            }
            return -1;
        }
    }
}
