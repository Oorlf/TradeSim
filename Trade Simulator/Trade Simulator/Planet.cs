﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade_Simulator
{
    // Any 'usable' planet - colony/mine/etc. - anything that can trade goods
    class Planet
    {
        // Name of the planet - randomly generated/picked from a namelist
        public String Name { get; private set; }

        // Type of planet randomly picked from a fixed number of presets
        public String Type { get; private set; }

        // Planet size - constricted by PlanetType
        public float Size { get; private set; }    
        
        // Climate randomly generated with constraints according to the PlanetType and PlanetSize
        public String Climate { get; set; }

        // The usable area on the planet surface - can be changed through events etc. | maximum defined by PlanetType & PlanetSize | ?km²?
        public float UsableArea { get; set; }        
        
        // How easy it is for humanoids to live on the planet - can change through events/buildings etc..
        public float Habitability { get; set; }

        // temporary value for testing growth/decline - the goal is for planets to have individual continents/cities that grow/shrink depending on trade/events etc.
        public float Wealth { get; set; }
    }
}
