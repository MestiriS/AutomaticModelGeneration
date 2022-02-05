using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelGenerator
{
    public class Materialhandlingequipment : SQLObject
    {
        #region Member Variables
        protected string _idMaterialHandlingEquipment;
        protected string _Capacity;
        protected string _Size;
        protected string _InitialXLocation;
        protected string _InitialYLocation;
        protected string _MaterialHandlingSystem_idMaterialHandlingSystem;
        protected string _MaterialHandlingSystem_SimulationData_idSimulationData;
        protected List<SQLObject> _packagingequipments;
        protected List<SQLObject> _movingequipments;
        protected List<SQLObject> _storageequipments;
        #endregion
        #region Constructors
        public Materialhandlingequipment(MySqlDataReader parentReader) : base(parentReader)
        {
            //set connection
            OpenConnection();

            //Get material handling equipments
            ReadListProperties(ref _packagingequipments, typeof(Packagingequipment), "SELECT * FROM packagingequipment");

            //Get moving equipments
            ReadListProperties(ref _movingequipments, typeof(Movingequipment), "SELECT * FROM movingequipment");

            //Get storage equipments
            ReadListProperties(ref _storageequipments, typeof(Storageequipment), "SELECT * FROM storageequipment");

            CloseConnection();
        }
        #endregion
        #region Public Properties
        public string IdMaterialHandlingEquipment
        {
            get { return _idMaterialHandlingEquipment; }
            set { _idMaterialHandlingEquipment = value; }
        }
        public string Capacity
        {
            get { return _Capacity; }
            set { _Capacity = value; }
        }
        public string Size
        {
            get { return _Size; }
            set { _Size = value; }
        }
        public string InitialXLocation
        {
            get { return _InitialXLocation; }
            set { _InitialXLocation = value; }
        }
        public string InitialYLocation
        {
            get { return _InitialYLocation; }
            set { _InitialYLocation = value; }
        }
        public string MaterialHandlingSystem_idMaterialHandlingSystem
        {
            get { return _MaterialHandlingSystem_idMaterialHandlingSystem; }
            set { _MaterialHandlingSystem_idMaterialHandlingSystem = value; }
        }
        public string MaterialHandlingSystem_SimulationData_idSimulationData
        {
            get { return _MaterialHandlingSystem_SimulationData_idSimulationData; }
            set { _MaterialHandlingSystem_SimulationData_idSimulationData = value; }
        }
        public List<SQLObject> Packagingequipments
        {
            get { return _packagingequipments; }
            set { _packagingequipments = value; }
        }
        public List<SQLObject> Movingequipments
        {
            get { return _movingequipments; }
            set { _movingequipments = value; }
        }
        public List<SQLObject> Storageequipments
        {
            get { return _storageequipments; }
            set { _storageequipments = value; }
        }
        #endregion
    }
}
