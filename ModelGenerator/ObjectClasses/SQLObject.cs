using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModelGenerator
{
    public abstract class SQLObject
    {
        protected MySqlConnection connection;
        protected MySqlCommand command;
        protected MySqlDataReader reader;
        public SQLObject(MySqlDataReader parentReader)
        {
            //Get local properties
            GetLocalProperties(parentReader, this);
        }

        protected void OpenConnection()
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
        protected void CloseConnection()
        {
            connection.Close();
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

        protected void GetLocalProperties(MySqlDataReader parentReader, object classObj)
        {
            //Get local properties
            foreach (PropertyInfo variable in classObj.GetType().GetProperties())
                if (variable.PropertyType.Name == "String")
                    variable.SetValue(classObj, GetString(parentReader, variable.Name));
        }

        protected void ReadListProperties(ref List<SQLObject> ObjectList, Type T, string SQLCommand)
        {
            //Get list
            ObjectList = new List<SQLObject>();
            command = new MySqlCommand(SQLCommand, connection);
            reader = command.ExecuteReader();
            while (reader.Read())
                ObjectList.Add((SQLObject)Activator.CreateInstance(T, reader));
            reader.Close();

        }
    }
}
