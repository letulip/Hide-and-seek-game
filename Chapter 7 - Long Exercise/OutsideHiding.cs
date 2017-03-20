using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_7___Long_Exercise
{
    class OutsideHiding : Outside, IHidingPlace
    {
        public OutsideHiding(string name, bool hot, string hidingPlace) : base(name, hot)
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
