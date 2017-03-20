using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_7___Long_Exercise
{
    class Opponent
    {
        private Location myLocation;
        private Random rnd = new Random();

        public Opponent(Location location)
        {
            myLocation = location;
        }

        public void Move()
        {
            bool hidden = false;

            while (!hidden)
            {
                if (myLocation is IHasExteriorDoor)
                {
                    IHasExteriorDoor locWithDoor = myLocation as IHasExteriorDoor;
                    if (rnd.Next(2) == 1)
                    {
                        myLocation = locWithDoor.DoorLocation;
                    }

                }

                int randomLoc = rnd.Next(myLocation.Exits.Length);
                myLocation = myLocation.Exits[randomLoc];

                if (myLocation is IHidingPlace)
                    hidden = true;
            } 
        }

        public bool Check(Location location)
        {
            if (myLocation == location)
                return true;
            else
                return false;
        }
    }
}
