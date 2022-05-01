using StarWarsCharacterModels.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsCharacterModels.Behaviors
{
    public class AttackWithForce : IAttackBehavior
    {
        public string Attack(bool hasForcePower, IWeapon weapon)
        {
            var sb = new StringBuilder();
            if (hasForcePower)
            {
                sb.AppendLine("Using the force to aid in battle!");
            }
            else 
            {
                sb.AppendLine("Unable to use the force. Attack failed due to your disturbing lack of faith");
            }
            return sb.ToString();
        }
    }
}
