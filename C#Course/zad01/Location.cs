using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Course.zad01
{
    class Location
    {
        public string Name { get; set; }

        public List<NonPlayerCharacter> Characters { get; set; }

        public Location (string name, params NonPlayerCharacter[] characters)
        {
            this.Name = name;
            this.Characters = new List<NonPlayerCharacter>(characters);
        }
    }
}
