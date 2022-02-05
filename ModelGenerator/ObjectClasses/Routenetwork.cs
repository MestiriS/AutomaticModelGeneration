using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelGenerator
{
    public class Routenetwork : SQLObject
    {
        #region Member Variables
        protected string _MaterialHandlingSystem_idMaterialHandlingSystem;
        protected string _idRouteNetworkcol;
        protected string _Width;
        protected string _Length;
        protected List<SQLObject> _routes;
        #endregion
        #region Constructors
        public Routenetwork(MySqlDataReader parentReader) : base(parentReader)
        {
            //SetConnection
            OpenConnection();

            //Get Routes
            ReadListProperties(ref _routes, typeof(Route), "SELECT * FROM route WHERE RouteNetwork_MaterialHandlingSystem_idMaterialHandlingSystem = " + _MaterialHandlingSystem_idMaterialHandlingSystem + " AND RouteNetwork_idRouteNetworkcol = " + _idRouteNetworkcol);

            CloseConnection();
        }
        #endregion
        #region Public Properties
        public string MaterialHandlingSystem_idMaterialHandlingSystem
        {
            get { return _MaterialHandlingSystem_idMaterialHandlingSystem; }
            set { _MaterialHandlingSystem_idMaterialHandlingSystem = value; }
        }
        public string IdRouteNetworkcol
        {
            get { return _idRouteNetworkcol; }
            set { _idRouteNetworkcol = value; }
        }
        public string Width
        {
            get { return _Width; }
            set { _Width = value; }
        }
        public string Length
        {
            get { return _Length; }
            set { _Length = value; }
        }
        public List<SQLObject> Routes
        {
            get { return _routes; }
            set { _routes = value; }
        }
        #endregion
    }
}
