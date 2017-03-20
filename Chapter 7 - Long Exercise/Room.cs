using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_7___Long_Exercise
{
    class Room : Location
    {
        private string decor { get; }

        public Room(string name, string decor) : base(name)
        {
            this.decor = decor;
        }

        public override string Description
        {
            get
            {
                return base.Description + " You see " + decor;
            }
        }
    }
}
