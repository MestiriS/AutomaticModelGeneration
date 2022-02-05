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
        protected string _idTravelingPoint;
        protected string _Level;
        protected string _XLocation;
        protected string _YLocation;
        protected List<SQLObject> _loadunloadactivities;
        #endregion
        #region Constructors
        public Travelingpoint(MySqlDataReader parentReader) : base(parentReader)
        {
            //SetConnection
            OpenConnection();

            //Get load unload activities
            ReadListProperties(ref _loadunloadactivities, typeof(Loadunloadactivity), "SELECT * FROM loadunloadactivity WHERE idTravelingPoint =" + _idTravelingPoint);

            CloseConnection();
        }
        #endregion
        #region Public Properties
        public virtual string IdTravelingPoint
        {
            get { return _idTravelingPoint; }
            set { _idTravelingPoint = value; }
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
        public List<SQLObject> Loadunloadactivities
        {
            get { return _loadunloadactivities; }
            set { _loadunloadactivities = value; }
        }
        #endregion
    }
}
