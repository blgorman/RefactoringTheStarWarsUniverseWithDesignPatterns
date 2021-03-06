using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsCharacterModels.Weapons
{
    public class Lightsaber : Weapon
    {
        public Lightsaber() : base() { }
        public Lightsaber(IWeapon w) : base(w)
        {
        }

        public override string Description()
        {
            if (_weapon is null)
            {
                return "Light Saber";
            }
            else
            {
                return $"{_weapon.Description()} Light Saber";
            }
        }

        public override double baseDamage()
        {
            var baseAccumlator = 0.0;
            if (_weapon is not null)
            {
                baseAccumlator = _weapon.baseDamage();
            }
            return 15.3 + baseAccumlator;
        }

        public override double hitProbability()
        {
            var probAccumulator = 0.0;
            if (_weapon != null)
            {
                probAccumulator = _weapon.hitProbability();
            }
            return .93 + (.1 * probAccumulator);
        }

        public override string ToString()
        {
            return $"{Description()} | {baseDamage()} | {hitProbability()}";
        }
    }
}
