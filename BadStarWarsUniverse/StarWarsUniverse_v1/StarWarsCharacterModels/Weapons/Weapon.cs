namespace StarWarsCharacterModels.Weapons
{
    public abstract class Weapon : IWeapon
    {
        public bool successfulWield()
        {
            Random rnd = new Random();
            return (rnd.Next(100) / 100) < hitProbability();
        }

        public double calculateDamageOnHit()
        {
            Random rnd = new Random();
            return (baseDamage() + (rnd.Next(1000) / 100));
        }

        public abstract string Description();

        public abstract double baseDamage();

        public abstract double hitProbability();
    }
}
