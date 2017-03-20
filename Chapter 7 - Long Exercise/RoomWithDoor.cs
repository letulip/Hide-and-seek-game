using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_7___Long_Exercise
{
    class RoomWithDoor : InsideHiding, IHasExteriorDoor
    {
        //private string decor;
        private string doorDescription;

        public RoomWithDoor(string name, string decor, string hidingPlace, string doorDescription) : base(name, decor, hidingPlace)
        {
            //this.decor = decor;
            this.doorDescription = doorDescription;
        }
        
        public string DoorDescription
        {
            get
            {
                return doorDescription;
            }
        }

        public Location DoorLocation { get; set; }
    }
}
