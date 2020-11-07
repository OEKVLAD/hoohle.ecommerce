using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System.Xml.Serialization;
using Google.Protobuf.WellKnownTypes;

namespace adminPanel_api
{
 
    public class DataBase
    {
        private static string getConectedString()
        {
            string dbServer = "mysql3.webio.pl";
            string dbDataBase = "20534_vladysalvomelchenko";
            string dbUser = "20534_vladyslavo";
            string dbPassword = "BjB4Es43X4v*p+";

            return "server=" + dbServer + ";database=" + dbDataBase + ";userid=" + dbUser + ";password=" + dbPassword + ";";
        }


        public static List<object> GetObject(DataTable dt)
        {
            List<object> obj = new List<object>();

            foreach (DataRow dr in dt.Rows)
            {
                obj.Add(dr);
            }

            return obj;
        }
        public static DataTable GetQuery(string query)
        {
            DataTable data = null;
            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(getConectedString());
                conn.Open();

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "table_name");
                DataTable dt = ds.Tables["table_name"];

                data = dt;

                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return data;
        }

        public static bool InsertQuery(string query)
        {
            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(getConectedString());
                conn.Open();

                using var cmd = new MySqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                conn.Close();

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

        public static class CommonMethod
        {
            public static List<T> ConvertToList<T>(DataTable dt)
            {
                var columnNames = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName.ToLower()).ToList();
                var properties = typeof(T).GetProperties();
                return dt.AsEnumerable().Select(row => {
                    var objT = Activator.CreateInstance<T>();
                    foreach (var pro in properties)
                    {
                        if (columnNames.Contains(pro.Name.ToLower()))
                        {
                            try
                            {
                                pro.SetValue(objT, row[pro.Name]);
                            }
                            catch (Exception ex) { }
                        }
                    }
                    return objT;
                }).ToList();
            }
        }
    }
}
