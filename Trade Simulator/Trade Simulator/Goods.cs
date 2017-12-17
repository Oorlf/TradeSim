using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade_Simulator
{
    // Goods and their properties
    public class Goods
    {
        // Name that should be fixed at the start, but may change depending on culture/environment of its origin
        public String Name { get; set; }

        // a general description of what the good is: look/taste/feel/importance/place in society/whatever
        // should be displayed in the main info column and maybe a shortened version as tooltip
        public String Descr { get; set; }

        // temporary value for testing - will be removed from this class
        public int Amount { get; set; }

        // temporary value for testing - will be removed from this class
        public float Price { get; set; }

        // the type of good - may affect price/availability
        //public GoodsType Category { get; set; }
    }
}
