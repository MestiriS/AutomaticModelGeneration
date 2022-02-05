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
        protected List<Handlingunit> _handlingunits;
        protected List<Manufacturingsystem> _manufacturingsystems;
        protected List<Materialhandlingsystem> _materialhandlingsystems;

        #endregion
        #region Constructors
        public Simulationdata() 
        { 
            
        }
        public Simulationdata(MySqlDataReader parentReader)
        {
            //Get local properties
            _idSimulationData = GetString(parentReader, "idSimulationData");
            
            //Set connection
            SetConnection();

            //Get handling units
            _handlingunits = new List<Handlingunit>();
            command = new MySqlCommand("SELECT * FROM handlingunit WHERE SimulationData_idSimulationData = " + _idSimulationData, connection);
            reader = command.ExecuteReader();
            while (reader.Read())
                _handlingunits.Add(new Handlingunit(reader));
            reader.Close();

            //Get manufacturing systems 
            _manufacturingsystems = new List<Manufacturingsystem>();
            command = new MySqlCommand("SELECT * FROM manufacturingsystem WHERE SimulationData_idSimulationData = " + _idSimulationData, connection);
            reader = command.ExecuteReader();
            while (reader.Read())
                _manufacturingsystems.Add(new Manufacturingsystem(reader));
            reader.Close();

            //Get materialhandling systems 
            _materialhandlingsystems = new List<Materialhandlingsystem>();
            command = new MySqlCommand("SELECT * FROM materialhandlingsystem WHERE SimulationData_idSimulationData = " + _idSimulationData, connection);
            reader = command.ExecuteReader();
            while (reader.Read())
                _materialhandlingsystems.Add(new Materialhandlingsystem(reader));
            reader.Close();
        }
        #endregion
        #region Public Properties
        public string IdSimulationData
        {
            get { return _idSimulationData; }
            set { _idSimulationData = value; }
        }

        public List<Handlingunit> Handlingunits
        {
            get { return _handlingunits; }
            set { _handlingunits = value; }
        }
        public List<Manufacturingsystem> Manufacturingsystems
        {
            get { return _manufacturingsystems; }
            set { _manufacturingsystems = value; }
        }
        public List<Materialhandlingsystem> Materialhandlingsystems
        {
            get { return _materialhandlingsystems; }
            set { _materialhandlingsystems = value; }
        }
        #endregion
    }
}
