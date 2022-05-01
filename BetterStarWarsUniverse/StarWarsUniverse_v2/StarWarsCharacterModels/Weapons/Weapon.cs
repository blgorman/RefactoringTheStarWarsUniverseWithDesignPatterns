namespace StarWarsCharacterModels.Weapons
{
    public enum WeaponChoices { 
        Blaster = 1,
        BlasterRifle = 2,
        BlasterCannon = 3,
        Bowcaster = 4,
        LightSaber = 5,
        Staff = 6
    }

    public abstract class Weapon : IWeapon
    {
        protected IWeapon _weapon;

        public Weapon()
        { 
        }

        public Weapon(IWeapon w)
        { 
            _weapon = w;
        }

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
