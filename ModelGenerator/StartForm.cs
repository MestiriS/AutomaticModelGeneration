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
using System.Data;

namespace ModelGenerator
{
    public partial class StartForm : Form
    {
        DataSet Dataset;
        MySqlDataAdapter DataAdapter;
        MySqlConnection Connection;
        public StartForm()
        {
            InitializeComponent();
            ReadData();
        }
        private void ReadData()
        {
            //Establish connection
            Connection = new MySqlConnection("server=sql11.freesqldatabase.com;port=3306;database=sql11470136;Uid=sql11470136;Pwd=gZHghibljB");
            try
            {
                Connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Test
            DataAdapter = new MySqlDataAdapter("select * from queue", Connection);
            Dataset = new DataSet();
            DataAdapter.Fill(Dataset);
            DGView.DataSource = Dataset.Tables[0];

            MySqlCommand command = new MySqlCommand("Select * From simulationdata", Connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<Simulationdata> ListSimulationData = new List<Simulationdata>();
            while (reader.Read())
                ListSimulationData.Add(new Simulationdata(reader));
            
        }
    }
}
