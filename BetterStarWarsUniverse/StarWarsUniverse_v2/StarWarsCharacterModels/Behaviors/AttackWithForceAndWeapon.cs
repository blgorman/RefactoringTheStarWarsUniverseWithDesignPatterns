using StarWarsCharacterModels.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsCharacterModels.Behaviors
{
    public class AttackWithForceAndWeapon : IAttackBehavior
    {
        public string Attack(bool hasForcePower, IWeapon weapon)
        {
            var sb = new StringBuilder();
            if (hasForcePower)
            {
                sb.AppendLine("Using the force to aid in battle!");
            }
            
            if (weapon != null)
            {
                if (weapon.successfulWield())
                {
                    sb.AppendLine($"Successfully attacked with {weapon.Description()} and caused " +
                                $"{weapon.calculateDamageOnHit()} points damage!");
                }
                else
                {
                    sb.AppendLine($"Attempted to attack with {weapon.Description()} and failed! No damage inflicted!");
                }
            }

            return sb.ToString();
        }
    }
}
