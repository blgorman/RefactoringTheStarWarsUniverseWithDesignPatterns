using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsCharacterModels.Weapons
{
    public class BlasterRifle : Weapon
    {
        public override string Description()
        {
            return "Blaster Rifle";
        }

        public override double baseDamage()
        {
            return 7.5;
        }

        public override double hitProbability()
        {
            return .82;
        }
        public override string ToString()
        {
            return $"{Description()} | {baseDamage()} | {hitProbability()}";
        }
    }
}
