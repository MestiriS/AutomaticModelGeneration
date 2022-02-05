using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelGenerator
{
    public class Project: SQLObject
    {
        List<SQLObject> _listSimulationData;
        public Project(MySqlDataReader parentReader) : base(parentReader)
        {
            //Establish connection
            OpenConnection();

            //Get Simulation Data
            ReadListProperties(ref _listSimulationData, typeof(Simulationdata), "Select * From simulationdata");
        }

        public List<SQLObject> ListSimulationData
        {
            get { return _listSimulationData; }
            set { _listSimulationData = value; }
        }
    }
}
