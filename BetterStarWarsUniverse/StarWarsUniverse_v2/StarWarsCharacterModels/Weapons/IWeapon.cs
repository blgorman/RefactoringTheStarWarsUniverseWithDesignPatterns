namespace StarWarsCharacterModels.Weapons
{
    public interface IWeapon
    {
        string Description();
        double baseDamage();
        double hitProbability();
        bool successfulWield();
        double calculateDamageOnHit();
    }
}
