using SimioAPI;
using SimioAPI.Extensions;
using MySql.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using MySql.Data.MySqlClient;
using System.Windows;
using System.Windows.Forms;

namespace ModelGenerator
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
            ReadData();
            
        }
        private void ReadData()
        {

            string myConnectionString;

            myConnectionString = "datasource=sql11.freesqldatabase.com;port=3306;Initial Catalog='sql11470136';username=sql11470136;password=gZHghibljB";

            MySqlConnection conn = new MySqlConnection(myConnectionString);
            MySqlCommand command = conn.CreateCommand();

            string SimulationModelElements = "Query to identify the list of objects with their type and respective X and Y location";

            string PropertiesOfTheSimulationModel = "Query to identify all the properties of the simulation model";

            command.CommandText = "Put query here";

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string NameOfTheColumn = (string)reader["NameOfTheColumn"];
                string aNameOfTheColumn1 = (string)reader["NameOfTheColumn2"];

            }
        }
        public void Execute(IDesignContext context)
        {
            

        }
    }
}
