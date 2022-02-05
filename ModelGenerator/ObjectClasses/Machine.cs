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
        protected List<SQLObject> _queues;
        #endregion
        #region Constructors
        public Machine(MySqlDataReader parentReader):base(parentReader)
        {
            //Set Connection
            OpenConnection();

            //Get Queues
            ReadListProperties(ref _queues, typeof(Queue), "SELECT * FROM queue WHERE Machine_idMachine = " + _idMachine);
           
            CloseConnection();
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
        public List<SQLObject> Queues
        {
            get { return _queues; }
            set { _queues = value; }
        }
        #endregion
    }
}
