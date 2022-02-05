using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelGenerator
{
    public class Materialhandlingsystem : SQLObject
    {
        #region Member Variables
        protected string _idMaterialHandlingSystem;
        protected string _SimulationData_idSimulationData;
        protected List<SQLObject> _materialhandlingequipments;
        protected List<SQLObject> _routenetworks;
        #endregion
        #region Constructors
        public Materialhandlingsystem(MySqlDataReader parentReader) : base(parentReader)
        {
            //Set Connection
            OpenConnection();

            //Get material handling equipments
            ReadListProperties(ref _materialhandlingequipments, typeof(Materialhandlingequipment), "SELECT * FROM materialhandlingequipment WHERE MaterialHandlingSystem_SimulationData_idSimulationData= " + _SimulationData_idSimulationData + " AND MaterialHandlingSystem_idMaterialHandlingSystem = " + _idMaterialHandlingSystem);

            //Get route networks
            ReadListProperties(ref _routenetworks, typeof(Routenetwork), "SELECT * FROM routenetwork WHERE MaterialHandlingSystem_idMaterialHandlingSystem = " + _idMaterialHandlingSystem);

            CloseConnection();
        }
        #endregion
            #region Public Properties
        public string IdMaterialHandlingSystem
        {
            get { return _idMaterialHandlingSystem; }
            set { _idMaterialHandlingSystem = value; }
        }
        public string SimulationData_idSimulationData
        {
            get { return _SimulationData_idSimulationData; }
            set { _SimulationData_idSimulationData = value; }
        }
        public List<SQLObject> Materialhandlingequipments
        {
            get { return _materialhandlingequipments; }
            set { _materialhandlingequipments = value; }
        }
        public List<SQLObject> Routenetworks
        {
            get { return _routenetworks; }
            set { _routenetworks = value; }
        }
        #endregion
    }
}
