using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectDumperTests
{
    class Ufo
    {
        public int Speed { get; set; }
        public string Name { get; set; }
        public Planet Origin { get; set; }
    }

    internal class CrashedUfo : Ufo
    {
        public string ZLastProperty
        {
            get { throw new NotImplementedException(); }
        }
    }

    class Planet
    {
        public string Name { get; set; }
        public int DaysPerYear { get; set; }
    }
}
