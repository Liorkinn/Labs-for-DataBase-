using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data.Common;

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

        public long delete(int id)
        {
            MySqlCommand command = Connection.CreateCommand();
            command.CommandText = "DELETE FROM mis where id = ?id";
            command.Parameters.Add("?id", MySqlDbType.Int32).Value = id;
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

        public List<string> see(string name, string telephone, string work, DateTime date, int staj, string information)
        {
            MySqlCommand command = Connection.CreateCommand();
            List<string> aqua = new List<string>();
            command.CommandText = "SELECT ?name, ?telephone, ?work, ?date, ?staj, ?information FROM labsbd.mis";
            command.Parameters.Add("?name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("?telephone", MySqlDbType.VarChar).Value = telephone;
            command.Parameters.Add("?work", MySqlDbType.VarChar).Value = work;
            command.Parameters.Add("?date", MySqlDbType.DateTime).Value = date;
            command.Parameters.Add("?staj", MySqlDbType.Int32).Value = staj;
            command.Parameters.Add("?information", MySqlDbType.VarChar).Value = information;
            try
            {
                Connection.Open();
                DbDataReader reader = command.ExecuteReader(); 

                while (reader.Read())
                {
                    aqua.Add(reader.GetString(0));
                    aqua.Add(reader.GetString(1));
                    aqua.Add(reader.GetString(2));
                    aqua.Add(reader.GetString(3));
                    aqua.Add(reader.GetString(4));
                    aqua.Add(reader.GetString(5));
                }
                return aqua;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Connection.Close();
            }
            return aqua;
        }


    }
}
