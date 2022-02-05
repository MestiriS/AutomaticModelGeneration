using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace ModelGenerator
{
    public class Simulationdata: SQLObject
    {
        #region Member Variables
        protected string _idSimulationData;
        protected List<SQLObject> _handlingunits;
        protected List<SQLObject> _manufacturingsystems;
        protected List<SQLObject> _materialhandlingsystems;

        #endregion
        #region Constructors
        public Simulationdata(MySqlDataReader parentReader) : base(parentReader)
        {
            //Set connection
            OpenConnection();

            //Get handling units
            ReadListProperties(ref _handlingunits, typeof(Handlingunit), "SELECT * FROM handlingunit WHERE SimulationData_idSimulationData = " + _idSimulationData);

            //Get manufacturing systems 
            ReadListProperties(ref _manufacturingsystems, typeof(Manufacturingsystem), "SELECT * FROM manufacturingsystem WHERE SimulationData_idSimulationData = " + _idSimulationData);

            //Get materialhandling systems 
            ReadListProperties(ref _materialhandlingsystems, typeof(Materialhandlingsystem), "SELECT * FROM materialhandlingsystem WHERE SimulationData_idSimulationData = " + _idSimulationData);

            CloseConnection();
        }
        #endregion
        #region Public Properties
        public string IdSimulationData
        {
            get { return _idSimulationData; }
            set { _idSimulationData = value; }
        }

        public List<SQLObject> Handlingunits
        {
            get { return _handlingunits; }
            set { _handlingunits = value; }
        }
        public List<SQLObject> Manufacturingsystems
        {
            get { return _manufacturingsystems; }
            set { _manufacturingsystems = value; }
        }
        public List<SQLObject> Materialhandlingsystems
        {
            get { return _materialhandlingsystems; }
            set { _materialhandlingsystems = value; }
        }
        #endregion
    }
}
