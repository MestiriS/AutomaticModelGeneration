using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelGenerator
{
    public class Travelingpoint : SQLObject
    {
        #region Member Variables
        protected string _idTravelingPostring;
        protected string _Level;
        protected string _XLocation;
        protected string _YLocation;
        #endregion
        #region Constructors
        public Travelingpoint(MySqlDataReader parentReader)
        {
            //Get local properties
            //...

            SetConnection();
        }
        public Travelingpoint(string Level, string XLocation, string YLocation)
        {
            this._Level = Level;
            this._XLocation = XLocation;
            this._YLocation = YLocation;
        }
        #endregion
        #region Public Properties
        public virtual string IdTravelingPostring
        {
            get { return _idTravelingPostring; }
            set { _idTravelingPostring = value; }
        }
        public virtual string Level
        {
            get { return _Level; }
            set { _Level = value; }
        }
        public virtual string XLocation
        {
            get { return _XLocation; }
            set { _XLocation = value; }
        }
        public virtual string YLocation
        {
            get { return _YLocation; }
            set { _YLocation = value; }
        }
        #endregion
    }
}
