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
        protected List<Materialhandlingequipment> _materialhandlingequipments;
        protected List<Routenetwork> _routenetworks;
        #endregion
        #region Constructors
        public Materialhandlingsystem(MySqlDataReader parentReader)
        {
            //Get local properties
            _idMaterialHandlingSystem = GetString(parentReader, "idMaterialHandlingSystem");
            _SimulationData_idSimulationData = GetString(parentReader, "" + "SimulationData_idSimulationData");

            //Set Connection
            SetConnection();

            //Get material handling equipments
            _materialhandlingequipments = new List<Materialhandlingequipment>();
            command = new MySqlCommand("SELECT * FROM materialhandlingequipment WHERE MaterialHandlingSystem_SimulationData_idSimulationData= " + _SimulationData_idSimulationData + " AND MaterialHandlingSystem_idMaterialHandlingSystem = " + _idMaterialHandlingSystem, connection);
            reader = command.ExecuteReader();
            while (reader.Read())
                _materialhandlingequipments.Add(new Materialhandlingequipment(reader));
            reader.Close();

            //Get route networks
            _routenetworks = new List<Routenetwork>();
            command = new MySqlCommand("SELECT * FROM materialhandlingequipment WHERE MaterialHandlingSystem_SimulationData_idSimulationData= " + _SimulationData_idSimulationData + " AND MaterialHandlingSystem_idMaterialHandlingSystem = " + _idMaterialHandlingSystem, connection);
            reader = command.ExecuteReader();
            while (reader.Read())
                _routenetworks.Add(new Routenetwork(reader));
            reader.Close();
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
        public List<Materialhandlingequipment> Materialhandlingequipments
        {
            get { return _materialhandlingequipments; }
            set { _materialhandlingequipments = value; }
        }
        public List<Routenetwork> Routenetworks
        {
            get { return _routenetworks; }
            set { _routenetworks = value; }
        }
        #endregion
    }
}
