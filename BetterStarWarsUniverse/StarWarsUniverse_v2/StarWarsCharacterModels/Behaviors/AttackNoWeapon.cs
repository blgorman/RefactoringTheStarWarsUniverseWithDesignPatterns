using StarWarsCharacterModels.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsCharacterModels.Behaviors
{
    public class AttackNoWeapon : IAttackBehavior
    {
        public string Attack(bool hasForcePower, IWeapon weapon)
        {
            var sb = new StringBuilder();
            //implement fighting strategy
            if (hasForcePower)
            {
                sb.AppendLine("Using the force to aid in battle!");
            }
            else 
            {
                sb.AppendLine("Unable to attack: No available weapon or ability to attack with!");
            }
            
            return sb.ToString();
        }
    }
}
