using StarWarsCharacterModels.Weapons;

namespace StarWarsCharacterModels.Behaviors
{
    public interface IAttackBehavior
    {
        string Attack(bool hasForcePower, IWeapon weapon);
    }
}
