using StarWarsCharacterModels.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsCharacterModels.Behaviors
{
    public class DefendRetreat : IDefendBehavior
    {
        public string Defend(bool hasForcePower, IWeapon weapon)
        {
            return "The best way to win the fight is: Not be there! - Retreating...";
        }
    }
}
