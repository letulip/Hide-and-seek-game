using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_7___Long_Exercise
{
    class Outside : Location
    {
        private bool hot { get; set; }

        public Outside(string name, bool hot) : base(name)
        {
            this.hot = hot;
        }

        public override string Description
        {
            get
            {
                string newDesc = base.Description;
                if (hot)
                    return newDesc += " It's hot here!";
                else
                    return newDesc += " It's fine outside!";
            }
        }
    }
}
