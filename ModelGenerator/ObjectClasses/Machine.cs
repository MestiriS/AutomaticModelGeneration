using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelGenerator
{
    public class Machine : SQLObject
    {
        #region Member Variables
        protected string _idMachine;
        protected string _Capacity;
        protected string _Type;
        protected string _ProcessingTime;
        protected string _idManufacturingSystem;
        protected string _TravelingPoint_idTravelingPoint;
        protected List<Queue> _queues;
        #endregion
        #region Constructors
        public Machine(MySqlDataReader parentReader)
        {
            //Get local properties
            _idMachine = GetString(parentReader, "idMachine");
            _Capacity = GetString(parentReader, "Capacity");
            _Type = GetString(parentReader, "Type");
            _ProcessingTime = GetString(parentReader, "ProcessingTime");
            _idManufacturingSystem = GetString(parentReader, "idManufacturingSystem");
            _TravelingPoint_idTravelingPoint = GetString(parentReader, "TravelingPoint_idTravelingPoint");
            
            //Set Connection
            SetConnection();

            //Get Queues
            _queues = new List<Queue>();
            command = new MySqlCommand("SELECT * FROM queue WHERE Machine_idMachine = " + _idMachine, connection);
            reader = command.ExecuteReader();
            while (reader.Read())
                _queues.Add(new Queue(reader));
            reader.Close();
        }
        public Machine(string Capacity, string Type, string ProcessingTime)
        {
            this._Capacity = Capacity;
            this._Type = Type;
            this._ProcessingTime = ProcessingTime;
        }
        #endregion
        #region Public Properties
        public string IdMachine
        {
            get { return _idMachine; }
            set { _idMachine = value; }
        }
        public string Capacity
        {
            get { return _Capacity; }
            set { _Capacity = value; }
        }
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        public string ProcessingTime
        {
            get { return _ProcessingTime; }
            set { _ProcessingTime = value; }
        }
        public string IdManufacturingSystem
        {
            get { return _idManufacturingSystem; }
            set { _idManufacturingSystem = value; }
        }
        public string TravelingPoint_idTravelingPoint
        {
            get { return _TravelingPoint_idTravelingPoint; }
            set { _TravelingPoint_idTravelingPoint = value; }
        }
        public List<Queue> Queues
        {
            get { return _queues; }
            set { _queues = value; }
        }
        #endregion
    }
}
