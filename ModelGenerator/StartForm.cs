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

        public StartForm()
        {
            InitializeComponent();
            ReadData();
        }
        private void ReadData()
        {
            Project p = new Project(null);
        }

        private void ShowTable()
        {
            //Test
            /*DataAdapter = new MySqlDataAdapter("select * from queue", Connection);
            Dataset = new DataSet();
            DataAdapter.Fill(Dataset);
            DGView.DataSource = Dataset.Tables[0];*/
        }
    }
}
