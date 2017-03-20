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

        private void Move()
        {
            if(myLocation is IHasExteriorDoor)
                if(rnd.Next(2) == 1)
                {

                }
                    
        }

        private bool Check(Location location)
        {
            if (myLocation == location)
                return true;
            else
                return false;
        }
    }
}
