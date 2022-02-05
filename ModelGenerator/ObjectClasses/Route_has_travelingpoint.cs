using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelGenerator
{
    public class Route_has_travelingpoint:SQLObject
    {
        #region Member Variables
        protected string _route_idRoute;
        protected string _TravelingPoint_From;
        protected string _TravelingPoint_To;
        protected string _Direction;
        #endregion
        #region Constructors
        public Route_has_travelingpoint(MySqlDataReader parentReader) : base(parentReader)
        {
        }
        #endregion
        #region Public Properties
        public virtual string Route_idRoute
        {
            get { return _route_idRoute; }
            set { _route_idRoute = value; }
        }
        public virtual string TravelingPoint_From
        {
            get { return _TravelingPoint_From; }
            set { _TravelingPoint_From = value; }
        }
        public virtual string TravelingPoint_To
        {
            get { return _TravelingPoint_To; }
            set { _TravelingPoint_To = value; }
        }
        public virtual string Direction
        {
            get { return _Direction; }
            set { _Direction = value; }
        }
        #endregion
    }
}
