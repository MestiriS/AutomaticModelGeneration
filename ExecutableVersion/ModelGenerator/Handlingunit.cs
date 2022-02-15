using MySql.Data.MySqlClient;
using SimioAPI.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UserAddIn
{
    public class Handlingunit: SQLObject
    {
        #region Member Variables
        protected string _idHandlingUnit;
        protected string _MaterialType;
        protected string _ContainerCapacity;
        protected string _ContainerSize;
        protected string _ContainerType;
        protected string _SimulationData_idSimulationData;
        #endregion
        #region Constructors
        public Handlingunit(Project project, MySqlDataReader parentReader) : base(project, parentReader)
        {
        }

        #endregion
        #region Public Properties
        public virtual string IdHandlingUnit
        {
            get { return _idHandlingUnit; }
            set { _idHandlingUnit = value; }
        }
        public virtual string MaterialType
        {
            get { return _MaterialType; }
            set { _MaterialType = value; }
        }
        public virtual string ContainerCapacity
        {
            get { return _ContainerCapacity; }
            set { _ContainerCapacity = value; }
        }
        public virtual string ContainerSize
        {
            get { return _ContainerSize; }
            set { _ContainerSize = value; }
        }
        public virtual string ContainerType
        {
            get { return _ContainerType; }
            set { _ContainerType = value; }
        }
        public virtual string SimulationData_idSimulationData
        {
            get { return _SimulationData_idSimulationData; }
            set { _SimulationData_idSimulationData = value; }
        }

        internal void CreateSimioObject(IDesignContext context)
        {
            
        }
        #endregion
    }
}
