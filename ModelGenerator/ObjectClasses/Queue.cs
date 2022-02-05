﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelGenerator
{
    public class Queue : SQLObject
    {
        #region Member Variables
        protected string _idQueue;
        protected string _Capacity;
        protected string _Type;
        protected string _Machine_idMachine;
        #endregion
        #region Constructors
        public Queue(MySqlDataReader parentReader)
        {
            //Get local properties
            _idQueue = GetString(parentReader, "idQueue");
            _Capacity = GetString(parentReader, "Capacity");
            _Type = GetString(parentReader, "Type");
            _Machine_idMachine = GetString(parentReader, "Machine_idMachine");
        }
        public Queue(string Capacity,string Type)
        {
            this._Capacity = Capacity;
            this._Type = Type;
        }
        #endregion
        #region Public Properties
        public virtual string IdQueue
        {
            get { return _idQueue; }
            set { _idQueue = value; }
        }
        public virtual string Capacity
        {
            get { return _Capacity; }
            set { _Capacity = value; }
        }
        public virtual string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        public virtual string Machine_idMachine
        {
            get { return _Machine_idMachine; }
            set { _Machine_idMachine = value; }
        }
        #endregion
    }
}
