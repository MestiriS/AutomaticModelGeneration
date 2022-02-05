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
        protected List<Loadunloadactivity> _loadunloadactivities;
        #endregion
        #region Constructors
        public Movingequipment(MySqlDataReader parentReader)
        {
            //Get local properties
            _Type = GetString(parentReader, "_Type");
            _Speed = GetString(parentReader, "_Speed");
            _idMovingEquipment = GetString(parentReader, "_idMovingEquipment");

            //set Connection
            SetConnection();

            //Get load unload activities
            _loadunloadactivities = new List<Loadunloadactivity>();
            command = new MySqlCommand("SELECT * FROM loadunloadactivity", connection);
            reader = command.ExecuteReader();
            while (reader.Read())
                _loadunloadactivities.Add(new Loadunloadactivity(reader));
            reader.Close();
        }
        public Movingequipment(string MovementType, string Speed)
        {
            this._Type = MovementType;
            this._Speed = Speed;
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
        public List<Loadunloadactivity> Loadunloadactivities
        {
            get { return _loadunloadactivities; }
            set { _loadunloadactivities = value; }
        }
        #endregion
    }
}
