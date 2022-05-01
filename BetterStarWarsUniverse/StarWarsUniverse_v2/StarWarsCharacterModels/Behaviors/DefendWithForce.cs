using StarWarsCharacterModels.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsCharacterModels.Behaviors
{
    public class DefendWithForce : IDefendBehavior
    {
        public string Defend(bool hasForcePower, IWeapon weapon)
        {
            var sb = new StringBuilder();
            if (hasForcePower)
            {
                sb.AppendLine("Using the force to mount your defense!");
            }
            else
            {
                sb.AppendLine($"Unable to use the force, defense fails!");
            }
            
            return sb.ToString();
        }
    }
}
