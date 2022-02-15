using MySql.Data.MySqlClient;
using SimioAPI.Extensions;
using SimioAPI;
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
        protected string _XLocation;
        protected string _YLocation;
        protected List<SQLObject> _queues;
        #endregion
        #region Constructors
        public Machine(Project project, MySqlDataReader parentReader):base(project, parentReader)
        {
            //Set Connection
            OpenConnection();

            //Get Queues
            _queues = new List<SQLObject>();
            command = new MySqlCommand("SELECT * FROM queue WHERE Machine_idMachine = " + _idMachine, connection);
            reader = command.ExecuteReader();
            while (reader.Read())
                _queues.Add(new Queue(project, reader));
            reader.Close();
            CloseConnection();

            //Get Object


            /*int dummyCounter = 0;
            command = new MySqlCommand("SELECT * FROM travelingpoint WHERE idTravelingPoint = " + _TravelingPoint_idTravelingPoint, connection) ;
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (dummyCounter > 0)
                    throw new Exception("Erreur Commande SQL");
                _TravelingPoint = new Travelingpoint(project, reader);
                dummyCounter++;
            }
            reader.Close(); */


           

            project.ListPhysicalObject.Add(this);
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
        public string XLocation
        {
            get { return _XLocation; }
            set { _XLocation = value; }
        }
        public string YLocation
        {
            get { return _YLocation; }
            set { _YLocation = value; }
        }

        internal void CreateSimioObject(IDesignContext context)
        {
            context.ActiveModel.Facility.IntelligentObjects.CreateObject("Source", new FacilityLocation(double.Parse(XLocation), 0, double.Parse(YLocation)));
        }

       /* public string TravelingPoint_idTravelingPoint
        {
            get { return _TravelingPoint_idTravelingPoint; }
            set { _TravelingPoint_idTravelingPoint = value; }
        } */
        public List<SQLObject> Queues
        {
            get { return _queues; }
            set { _queues = value; }
        }
       /* public SQLObject TravelingPoint
        {
            get { return _TravelingPoint; }
            set { _TravelingPoint = value; }
        } */
        #endregion
    }
}
