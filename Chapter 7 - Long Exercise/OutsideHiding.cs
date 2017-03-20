using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_7___Long_Exercise
{
    class OutsideHiding : Outside, IHidingPlace
    {
        public OutsideHiding(string name, bool hot) : base(name, hot)
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
