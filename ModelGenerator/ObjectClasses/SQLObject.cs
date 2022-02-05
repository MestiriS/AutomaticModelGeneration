using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelGenerator
{
    public class SQLObject
    {
        protected MySqlConnection connection;
        protected MySqlCommand command;
        protected MySqlDataReader reader;
        public SQLObject()
        {

        }

        protected void SetConnection()
        {
            connection = new MySqlConnection("server=sql11.freesqldatabase.com;port=3306;database=sql11470136;Uid=sql11470136;Pwd=gZHghibljB");
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected string GetString(MySqlDataReader Reader, string key)
        {
            try
            {
                return Reader.GetString(key);
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
