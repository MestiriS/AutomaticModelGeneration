using SimioAPI;
using SimioAPI.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModelGenerator
{
    class AddInClass : IDesignAddIn
    {
        public string Name
        {
            get { return "AddInClass"; }
        }

        /// <summary>
        /// Property returning a short description of what the add-in does.
        /// </summary>
        public string Description
        {
            get { return "I am trying to make this shit work so please fucking work."; }
        }

        /// <summary>
        /// Property returning an icon to display for the add-in in the UI.
        /// </summary>
        public System.Drawing.Image Icon
        {
            get { return null; }
        }

        /// <summary>
        /// Method called when the add-in is run.
        /// </summary>



        public void Execute(IDesignContext context)
        {
            Project p = new Project(null, null);

            if (context.ActiveModel != null)
            {
                context.ActiveModel.BulkUpdate((IModel model) => {            

                    foreach (SQLObject obj in p.TravelingPoints)
                        ((Travelingpoint)obj).CreateSimioObject(context); 

                    foreach (SQLObject obj in p.StorageEquipments)
                        ((Storageequipment)obj).CreateSimioObject(context);

                    foreach(SQLObject obj in p.MovingEquipments)
                        ((Movingequipment)obj).CreateSimioObject(context);

                    foreach (SQLObject obj in p.Machines)
                        ((Machine)obj).CreateSimioObject(context);

                    foreach (SQLObject obj in p.Route_has_TravelingPoint)
                        ((Route_has_travelingpoint)obj).CreateSimioObject(context, p);

                });

            }
        }


    }
}
