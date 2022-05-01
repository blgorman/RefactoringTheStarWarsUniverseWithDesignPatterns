using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsCharacterModels.Weapons
{
    public class Bowcaster : Weapon
    {
        public Bowcaster() : base() { }
        public Bowcaster(IWeapon w) : base(w)
        {
        }

        public override string Description()
        {
            if (_weapon is null)
            {
                return "Bow Caster";
            }
            else
            {
                return $"{_weapon.Description()} Bow Caster";
            }

        }

        public override double baseDamage()
        {
            var baseAccumulator = 0.0;
            if (_weapon != null)
            {
                baseAccumulator = _weapon.baseDamage();
            }
            return 9.3 + baseAccumulator;
        }

        public override double hitProbability()
        {
            var probAccumulator = 0.0;
            if (_weapon != null)
            {
                probAccumulator = _weapon.hitProbability();
            }
            return .68 + (.1 * probAccumulator);
        }

        public override string ToString()
        {
            return $"{Description()} | {baseDamage()} | {hitProbability()}";
        }
    }
}
