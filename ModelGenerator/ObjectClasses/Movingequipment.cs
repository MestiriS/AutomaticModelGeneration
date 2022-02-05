using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelGenerator
{
    public class Movingequipment : SQLObject
    {
        #region Member Variables
        protected string _Type;
        protected string _Speed;
        protected string _idMovingEquipment;
        protected List<SQLObject> _loadunloadactivities;
        #endregion
        #region Constructors
        public Movingequipment(MySqlDataReader parentReader) : base(parentReader)
        {
            //set Connection
            OpenConnection();

            //Get load unload activities
            ReadListProperties(ref _loadunloadactivities, typeof(Loadunloadactivity), "SELECT * FROM loadunloadactivity WHERE MovingEquipment_idMovingEquipment =" + _idMovingEquipment);

            CloseConnection();
        }
        #endregion
        #region Public Properties
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        public string Speed
        {
            get { return _Speed; }
            set { _Speed = value; }
        }
        public string IdMovingEquipment
        {
            get { return _idMovingEquipment; }
            set { _idMovingEquipment = value; }
        }
        public List<SQLObject> Loadunloadactivities
        {
            get { return _loadunloadactivities; }
            set { _loadunloadactivities = value; }
        }
        #endregion
    }
}
