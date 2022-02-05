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
        public Loadunloadactivity(MySqlDataReader parentReader)
        {
            //Get local properties
            _ProcessingTime = GetString(parentReader, "ProcessingTime");
            _idTravelingPoint = GetString(parentReader, "idTravelingPoint");
            _TravelingPoint_Route_idRoute = GetString(parentReader, "TravelingPoint_Route_idRoute");
            _MovingEquipment_idMovingEquipment = GetString(parentReader, "MovingEquipment_idMovingEquipment");
        }
        public Loadunloadactivity(string ProcessingTime, string idTravelingPoint, string TravelingPoint_Route_idRoute, string MovingEquipment_idMovingEquipment)
        {
            this._ProcessingTime = ProcessingTime;
            this._idTravelingPoint = idTravelingPoint;
            this._TravelingPoint_Route_idRoute = TravelingPoint_Route_idRoute;
            this._MovingEquipment_idMovingEquipment = MovingEquipment_idMovingEquipment;
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
