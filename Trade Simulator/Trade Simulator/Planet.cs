using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Trade_Simulator
{
    // Any 'usable' planet - colony/mine/etc. - anything that can trade goods
    public class Planet 
    {
        // Name of the planet - randomly generated/picked from a namelist
        public String Name { get; set; }

        // Type of planet randomly picked from a fixed number of presets
        public String PlanetType { get; set; }

        // Planet size - constricted by PlanetType
        public float Size { get; set; }    
        
        // Climate randomly generated with constraints according to the PlanetType and PlanetSize
        public String Climate { get; set; }

        // The usable area on the planet surface - can be changed through events etc. | maximum defined by PlanetType & PlanetSize | ?km²?
        public float UsableArea { get; set; }        
        
        // How easy it is for humanoids to live on the planet - can change through events/buildings etc..
        public float Habitability { get; set; }

        // temporary value for testing growth/decline - the goal is for planets to have individual continents/cities that grow/shrink depending on trade/events etc.
        public float Wealth { get; set; }

        // the available goods on the planet - initial ones are defined by planet type/climate etc.
        public Goods[] Goods { get; set; }
    }


    
}
