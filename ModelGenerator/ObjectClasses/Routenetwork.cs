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
        protected List<Route> _routes;
        #endregion
        #region Constructors
        public Routenetwork(MySqlDataReader parentReader)
        {
            //Get local properties
            //...

            SetConnection();
        }
        public Routenetwork(string Width, string Length)
        {
            this._Width = Width;
            this._Length = Length;
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
        public List<Route> Routes
        {
            get { return _routes; }
            set { _routes = value; }
        }
        #endregion
    }
}
