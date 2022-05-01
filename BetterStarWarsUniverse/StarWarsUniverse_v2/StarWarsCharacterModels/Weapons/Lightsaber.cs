using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsCharacterModels.Weapons
{
    public class Lightsaber : Weapon
    {
        public override string Description()
        {
            return "Light Saber";
        }

        public override double baseDamage()
        {
            return 15.3;
        }

        public override double hitProbability()
        {
            return .93;
        }

        public override string ToString()
        {
            return $"{Description()} | {baseDamage()} | {hitProbability()}";
        }
    }
}
