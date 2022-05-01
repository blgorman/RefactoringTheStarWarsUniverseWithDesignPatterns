using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsCharacterModels.Weapons
{
    public class Blaster : Weapon
    {
        public Blaster() : base() { } 
        public Blaster(IWeapon w) : base(w)
        {

        }

        public override string Description()
        {
            if (_weapon is null)
            {
                return "Blaster";
            }
            else
            {
                return $"{_weapon.Description()} Blaster";
            }
        }

        public override double baseDamage()
        {
            var baseAccumulator = 0.0;
            if (_weapon is not null)
            {
                baseAccumulator = _weapon.baseDamage();
            }
            return 5.0 + baseAccumulator;
        }

        public override double hitProbability()
        {
            var probAccumulator = 0.0;
            if (_weapon is not null)
            {
                probAccumulator = _weapon.hitProbability();
            }
            return .50 + (.1 * probAccumulator);
        }

        public override string ToString()
        {
            return $"{Description()} | {baseDamage()} | {hitProbability()}";
        }
    }
}
