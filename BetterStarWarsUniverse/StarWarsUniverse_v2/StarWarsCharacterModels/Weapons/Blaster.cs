using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsCharacterModels.Weapons
{
    public class Blaster : Weapon
    {
        public override string Description()
        {
            return "Blaster";
        }

        public override double baseDamage()
        {
            return 5.0;
        }

        public override double hitProbability()
        {
            return .78;
        }

        public override string ToString()
        {
            return $"{Description()} | {baseDamage()} | {hitProbability()}";
        }
    }
}
