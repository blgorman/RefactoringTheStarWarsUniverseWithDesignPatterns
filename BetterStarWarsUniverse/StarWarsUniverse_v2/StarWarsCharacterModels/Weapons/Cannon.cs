using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsCharacterModels.Weapons
{
    public class Cannon : Weapon
    {
        public Cannon(IWeapon w) : base(w)
        {
        }

        public override string Description()
        {
            if (_weapon is null)
            {
                return "Cannon";
            }
            else 
            {
                return $"{_weapon.Description()} Cannon";
            }
        }

        public override double baseDamage()
        {
            var baseAccumulator = 0.0;
            if (_weapon != null)
            {
                baseAccumulator = _weapon.baseDamage();
            }
            return 10 + baseAccumulator;
        }

        public override double hitProbability()
        {
            var probAccumulator = 0.0;
            if (_weapon != null)
            {
                probAccumulator = _weapon.hitProbability();
            }
            return .7 + (.1 * probAccumulator);
        }

        public override string ToString()
        {
            return $"{Description()} | {baseDamage()} | {hitProbability()}";
        }
    }
}
