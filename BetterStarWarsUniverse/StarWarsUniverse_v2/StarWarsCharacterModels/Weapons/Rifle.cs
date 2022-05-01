using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsCharacterModels.Weapons
{
    public class Rifle : Weapon
    {
        public Rifle(IWeapon w) : base(w)
        {
        }

        public override string Description()
        {
            if (_weapon is null)
            {
                return "Rifle";
            }
            else
            {
                return $"{_weapon.Description} Rifle";
            }
        }

        public override double baseDamage()
        {
            var baseAccumulator = 0.0;
            if (_weapon != null)
            {
                baseAccumulator = _weapon.baseDamage();
            }
            return 5 + baseAccumulator;
        }

        public override double hitProbability()
        {
            var probAccumulator = 0.0;
            if (_weapon != null)
            {
                probAccumulator = _weapon.hitProbability();
            }
            return .6 + (.1 * probAccumulator);
        }

        public override string ToString()
        {
            return $"{Description()} | {baseDamage()} | {hitProbability()}";
        }
    }
}
