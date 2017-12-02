using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MySql.Data.MySqlClient; //Добавить
using System.Data;


namespace Oleg
{
    class SQL
    {
        public DataTable GetComments()
        {
            DataTable dt = new DataTable();

            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = "localhost";
            mysqlCSB.Database = "oleg";
            mysqlCSB.UserID = "root";
            mysqlCSB.Password = "";

            string queryString = @"select * from document";

            using (MySqlConnection con = new MySqlConnection())
            {
                con.ConnectionString = mysqlCSB.ConnectionString;

                MySqlCommand com = new MySqlCommand(queryString, con);

                try
                {
                    con.Open();

                    using (MySqlDataReader dr = com.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dt.Load(dr);
                        }
                    }
                }

                catch
                {

                }
            }
            return dt;
        }
    }
}
