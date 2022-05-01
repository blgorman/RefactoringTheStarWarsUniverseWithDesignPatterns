using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsCharacterModels.Weapons
{
    public class BlasterCannon : Weapon
    {
        public override string Description()
        {
            return "Blaster Cannon";
        }

        public override double baseDamage()
        {
            return 10.0;
        }

        public override double hitProbability()
        {
            return .87;
        }
        public override string ToString()
        {
            return $"{Description()} | {baseDamage()} | {hitProbability()}";
        }
    }
}
