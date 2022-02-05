using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelGenerator
{
    public class Packagingequipment : SQLObject
    {
        #region Member Variables
        protected string _Type;
        protected string _ProcessingTime;
        protected string _idPackagingEquipment;
        #endregion
        #region Constructors
        public Packagingequipment(MySqlDataReader parentReader)
        {
            //Get local properties
            _Type = GetString(parentReader, "_Type");
            _ProcessingTime = GetString(parentReader, "ProcessingTime");
            _idPackagingEquipment = GetString(parentReader, "idPackagingEquipment");
        }
        public Packagingequipment(string ProcessingTime)
        {
            this._ProcessingTime = ProcessingTime;
        }
        #endregion
        #region Public Properties
        public virtual string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        public virtual string ProcessingTime
        {
            get { return _ProcessingTime; }
            set { _ProcessingTime = value; }
        }
        public virtual string IdPackagingEquipment
        {
            get { return _idPackagingEquipment; }
            set { _idPackagingEquipment = value; }
        }
        #endregion
    }
}
