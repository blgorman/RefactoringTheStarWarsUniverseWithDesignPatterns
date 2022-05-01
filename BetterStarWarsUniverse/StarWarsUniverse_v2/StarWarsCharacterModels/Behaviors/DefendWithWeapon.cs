using StarWarsCharacterModels.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsCharacterModels.Behaviors
{
    public class DefendWithWeapon : IDefendBehavior
    {
        public string Defend(bool hasForcePower, IWeapon weapon)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Defending with {weapon.Description()}");
            return sb.ToString();
        }
    }
}
