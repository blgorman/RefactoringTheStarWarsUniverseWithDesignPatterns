using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsCharacterModels.Weapons
{
    public class Staff : Weapon
    {
        public Staff() : base() { }
        public Staff(IWeapon w) : base(w)
        {
        }

        public override string Description()
        {
            if (_weapon is null)
            {
                return "Staff";
            }
            else
            {
                return $"{_weapon.Description()} Staff";
            }
        }

        public override double baseDamage()
        {
            var baseAccumulator = 0.0;
            if (_weapon is not null)
            { 
                baseAccumulator = _weapon.baseDamage();
            }
            return 2.6 + baseAccumulator;
        }

        public override double hitProbability()
        {
            double probAccumulator = 0.0;
            if (_weapon != null)
            {
                probAccumulator = _weapon.hitProbability();
            }
            return .98 + (.1 * probAccumulator);
        }

        public override string ToString()
        {
            return $"{Description()} | {baseDamage()} | {hitProbability()}";
        }
    }
}
