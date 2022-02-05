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
        protected List<SQLObject> _machines;
        #endregion
        #region Constructors
        public Manufacturingsystem(MySqlDataReader parentReader) : base(parentReader)
        {
            //Set connection
            OpenConnection();

            //Get Machines
            ReadListProperties(ref _machines, typeof(Machine), "SELECT * FROM machine WHERE idManufacturingSystem = " + _idManufacturingSystem);

            CloseConnection();
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
        public List<SQLObject> Machines
        {
            get { return _machines; }
            set { _machines = value; }
        }
        #endregion
    }
}
