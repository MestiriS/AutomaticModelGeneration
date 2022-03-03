using MySql.Data.MySqlClient;
using SimioAPI.Extensions;
using SimioAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserAddIn
{
    public class Machine : SQLObject
    {
        #region Member Variables
        protected string _idMachine;
        protected string _Capacity;
        protected string _Type;
        protected string _ProcessingTime;
        protected string _XLocation;
        protected string _YLocation;
        protected string _idManufacturingSystem;
        protected List<SQLObject> _queues;
        protected List<SQLObject> _machinelogs;
        protected IIntelligentObject _IMachine;
        #endregion
        #region Constructors
        public Machine(Project project, MySqlDataReader parentReader):base(project, parentReader)
        {

            //Get Queues
            OpenConnection();
            _queues = new List<SQLObject>();
            command = new MySqlCommand("SELECT * FROM queue WHERE Machine_idMachine = " + _idMachine, connection);
            reader = command.ExecuteReader();
            while (reader.Read())
                _queues.Add(new Queue(project, reader));
            reader.Close();

            //Get MachineLogs

            _machinelogs = new List<SQLObject>();
            command = new MySqlCommand("SELECT * FROM machinelogs WHERE machine_idMachine = " + _idMachine, connection);
            reader = command.ExecuteReader();
            while (reader.Read())
                _machinelogs.Add(new Machinelog(project, reader));
            reader.Close();
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
        public IIntelligentObject IMachine
        {
            get { return _IMachine; }
            set { _IMachine = value; }
        }

        internal IIntelligentObject CreateSimioObject(IDesignContext context)
        {

           IIntelligentObject item;


            item = context.ActiveModel.Facility.IntelligentObjects.CreateObject("Source", new FacilityLocation(double.Parse(XLocation), 0, double.Parse(YLocation)));
            item.ObjectName= Type;

            item.Properties["EntityType"].Value = item.ObjectName + "_Logs.Container_Type";
            item.Properties["ArrivalMode"].Value = "Arrival Table";
            item.Properties["ArrivalTimeProperty"].Value = item.ObjectName + "_Logs.Date";
            return item;

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

        public List<SQLObject> MachineLogs
        {
            get { return _machinelogs; }
            set { _machinelogs = value; }
        }



        internal void CreateSimioTable(IDesignContext context, Project p)
        {
            ITable table;
            
            table = context.ActiveModel.Tables.Create(Type+"_Logs");
            table.Columns.AddIntegerColumn("idlog", 0);
            table.Columns.AddDateTimeColumn("Date", DateTime.Now);
            table.Columns.AddObjectReferenceColumn("Container_Type");
            foreach (Machinelog obj in MachineLogs)
            {
                obj.AddNewLog(context, table, Type) ;
            }

           


        }
        /* public SQLObject TravelingPoint
         {
             get { return _TravelingPoint; }
             set { _TravelingPoint = value; }
         } */
        #endregion
    }
}
