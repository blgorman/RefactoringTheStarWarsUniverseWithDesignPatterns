using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsCharacterModels.Weapons
{
    public class Bowcaster : Weapon
    {
        public override string Description()
        {
            return "Bow Caster";
        }

        public override double baseDamage()
        {
            return 9.3;
        }

        public override double hitProbability()
        {
            return .68;
        }
        public override string ToString()
        {
            return $"{Description()} | {baseDamage()} | {hitProbability()}";
        }
    }
}
