using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelGenerator
{
    public class Route : SQLObject
    {
        #region Member Variables
        protected string _idRoute;
        protected string _Length;
        protected string _Width;
        protected string _RouteNetwork_MaterialHandlingSystem_idMaterialHandlingSystem;
        protected string _RouteNetwork_idRouteNetworkcol;
        protected List<Travelingpoint> _travelingpoints;
        #endregion
        #region Constructors
        public Route(MySqlDataReader parentReader)
        {
            //Get local properties
            //...

            SetConnection();
        }
        public Route(string Length, string Width)
        {
            this._Length = Length;
            this._Width = Width;
        }
        #endregion
        #region Public Properties
        public string IdRoute
        {
            get { return _idRoute; }
            set { _idRoute = value; }
        }
        public string Length
        {
            get { return _Length; }
            set { _Length = value; }
        }
        public string Width
        {
            get { return _Width; }
            set { _Width = value; }
        }
        public string RouteNetwork_MaterialHandlingSystem_idMaterialHandlingSystem
        {
            get { return _RouteNetwork_MaterialHandlingSystem_idMaterialHandlingSystem; }
            set { _RouteNetwork_MaterialHandlingSystem_idMaterialHandlingSystem = value; }
        }
        public string RouteNetwork_idRouteNetworkcol
        {
            get { return _RouteNetwork_idRouteNetworkcol; }
            set { _RouteNetwork_idRouteNetworkcol = value; }
        }
        public List<Travelingpoint> Travelingpoints
        {
            get { return _travelingpoints; }
            set { _travelingpoints = value; }
        }
        #endregion
    }
}
