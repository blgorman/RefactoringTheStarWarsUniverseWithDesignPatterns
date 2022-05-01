using StarWarsCharacterModels.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsCharacterModels.Behaviors
{
    public interface IDefendBehavior
    {
        string Defend(bool hasForcePower, IWeapon weapon);
    }
}
