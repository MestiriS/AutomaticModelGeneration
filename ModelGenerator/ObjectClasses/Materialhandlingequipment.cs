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
        protected List<Packagingequipment> _packagingequipments;
        protected List<Movingequipment> _movingequipments;
        protected List<Storageequipment> _storageequipments;
        #endregion
        #region Constructors
        public Materialhandlingequipment(MySqlDataReader parentReader)
        {
            //Get local properties
            _idMaterialHandlingEquipment = GetString(parentReader, "idMaterialHandlingEquipment");
            _Capacity = GetString(parentReader, "Capacity");
            _Size = GetString(parentReader, "Size");
            _InitialXLocation = GetString(parentReader, "InitialXLocation");
            _InitialYLocation = GetString(parentReader, "InitialYLocation");
            _MaterialHandlingSystem_idMaterialHandlingSystem = GetString(parentReader, "MaterialHandlingSystem_idMaterialHandlingSystem");
            _MaterialHandlingSystem_SimulationData_idSimulationData = GetString(parentReader, "MaterialHandlingSystem_SimulationData_idSimulationData");

            //set connection
            SetConnection();

            //Get material handling equipments
            _packagingequipments = new List<Packagingequipment>();
            command = new MySqlCommand("SELECT * FROM packagingequipment", connection);
            reader = command.ExecuteReader();
            while (reader.Read())
                _packagingequipments.Add(new Packagingequipment(reader));
            reader.Close();

            //Get moving equipments
            _movingequipments = new List<Movingequipment>();
            command = new MySqlCommand("SELECT * FROM movingequipment", connection);
            reader = command.ExecuteReader();
            while (reader.Read())
                _movingequipments.Add(new Movingequipment(reader));
            reader.Close();

            //Get storage equipments
            _storageequipments = new List<Storageequipment>();
            command = new MySqlCommand("SELECT * FROM storageequipment", connection);
            reader = command.ExecuteReader();
            while (reader.Read())
                _storageequipments.Add(new Storageequipment(reader));
            reader.Close();
        }
        public Materialhandlingequipment(string Capacity, string Size, string InitialXLocation, string InitialYLocation)
        {
            this._Capacity = Capacity;
            this._Size = Size;
            this._InitialXLocation = InitialXLocation;
            this._InitialYLocation = InitialYLocation;
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
        public List<Packagingequipment> Packagingequipments
        {
            get { return _packagingequipments; }
            set { _packagingequipments = value; }
        }
        public List<Movingequipment> Movingequipments
        {
            get { return _movingequipments; }
            set { _movingequipments = value; }
        }
        public List<Storageequipment> Storageequipments
        {
            get { return _storageequipments; }
            set { _storageequipments = value; }
        }
        #endregion
    }
}
