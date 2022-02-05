using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelGenerator
{
    public class Loadunloadactivity : SQLObject
    {
        #region Member Variables
        protected string _ProcessingTime;
        protected string _idTravelingPoint;
        protected string _TravelingPoint_Route_idRoute;
        protected string _MovingEquipment_idMovingEquipment;
        #endregion
        #region Constructors
        public Loadunloadactivity(MySqlDataReader parentReader) : base(parentReader)
        {
        }
        #endregion
        #region Public Properties
        public virtual string ProcessingTime
        {
            get { return _ProcessingTime; }
            set { _ProcessingTime = value; }
        }
        public virtual string IdTravelingPoint
        {
            get { return _idTravelingPoint; }
            set { _idTravelingPoint = value; }
        }
        public virtual string TravelingPoint_Route_idRoute
        {
            get { return _TravelingPoint_Route_idRoute; }
            set { _TravelingPoint_Route_idRoute = value; }
        }
        public virtual string MovingEquipment_idMovingEquipment
        {
            get { return _MovingEquipment_idMovingEquipment; }
            set { _MovingEquipment_idMovingEquipment = value; }
        }
        #endregion
    }
}
