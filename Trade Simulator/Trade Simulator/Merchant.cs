using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade_Simulator
{
    //NPC Händler deren Ziel es ist so reich wie möglich zu werden
    public class Merchant
    {
        public string Name { get; set; }
        public float Wealth { get; set; }
        public int Age { get; private set; }
    }
}
