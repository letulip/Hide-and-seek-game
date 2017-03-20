using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_7___Long_Exercise
{
    class InsideHiding : Room, IHidingPlace
    {
        public InsideHiding(string name, string decor) : base(name, decor)
        {
        }

        public string HidingPlace
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
