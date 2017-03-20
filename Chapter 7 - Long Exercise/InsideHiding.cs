using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_7___Long_Exercise
{
    class InsideHiding : Room, IHidingPlace
    {
        public InsideHiding(string name, string decor, string hidingPlace) : base(name, decor)
        {
            HidingPlaceName = hidingPlace;
        }

        public string HidingPlaceName { get; }

        public override string Description
        {
            get
            {
                return base.Description + " Someone could hide" + HidingPlaceName + ".";
            }
        }
    }
}
