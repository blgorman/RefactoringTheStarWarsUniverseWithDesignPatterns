using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsCharacterModels.Weapons
{
    public class Staff : Weapon
    {
        public override string Description()
        {
            return "Staff";
        }

        public override double baseDamage()
        {
            return 2.6;
        }

        public override double hitProbability()
        {
            return .98;
        }

        public override string ToString()
        {
            return $"{Description()} | {baseDamage()} | {hitProbability()}";
        }
    }
}
