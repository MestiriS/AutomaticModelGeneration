using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelGenerator
{
    public class Manufacturingsystem : SQLObject
    {
        #region Member Variables
        protected string _idManufacturingSystem;
        protected string _SimulationData_idSimulationData;
        protected List<Machine> _machines;
        #endregion
        #region Constructors
        public Manufacturingsystem(MySqlDataReader parentReader)
        {
            //Get local properties
            _idManufacturingSystem = GetString(parentReader, "idManufacturingSystem");
            _SimulationData_idSimulationData = GetString(parentReader, "SimulationData_idSimulationData");

            //Set connection
            SetConnection();

            //Get Machines
            _machines = new List<Machine>();
            command = new MySqlCommand("SELECT * FROM machine WHERE idManufacturingSystem = " + _idManufacturingSystem, connection);
            reader = command.ExecuteReader();
            while (reader.Read())
                _machines.Add(new Machine(reader));
            reader.Close();
        }
        #endregion
        #region Public Properties
        public string IdManufacturingSystem
        {
            get { return _idManufacturingSystem; }
            set { _idManufacturingSystem = value; }
        }
        public string SimulationData_idSimulationData
        {
            get { return _SimulationData_idSimulationData; }
            set { _SimulationData_idSimulationData = value; }
        }
        public List<Machine> Machines
        {
            get { return _machines; }
            set { _machines = value; }
        }
        #endregion
    }
}
