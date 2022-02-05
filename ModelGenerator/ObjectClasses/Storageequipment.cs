using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModelGenerator
{
    public class Storageequipment : SQLObject
    {
        #region Member Variables
        protected string _Type;
        protected string _idStorageEquipment;
        #endregion
        #region Constructors
        public Storageequipment(MySqlDataReader parentReader)
        {
            //Get local properties
            _Type = GetString(parentReader, "Type");
            _idStorageEquipment = GetString(parentReader, "idStorageEquipment");
        }
        public Storageequipment(string Type)
        {
            this._Type = Type;
        }
        #endregion
        #region Public Properties
        public virtual string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        public virtual string IdStorageEquipment
        {
            get { return _idStorageEquipment; }
            set { _idStorageEquipment = value; }
        }
        #endregion
    }
}
