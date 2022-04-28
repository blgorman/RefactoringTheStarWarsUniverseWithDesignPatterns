using System.Text;

namespace StarWarsCharacterModels.Characters
{
    public class JediKnight : Character
    {
        public JediKnight(string name, int age, double height, double weight, int classificationChoice, int speciesChoice, int weaponChoice) :
            base(name, age, height, weight, classificationChoice, speciesChoice, weaponChoice)
        {

        }

        public override string Attack()
        {
            var sb = new StringBuilder();
            //implement fighting strategy
            if (HasForcePower)
            {
                sb.AppendLine("Using the force to aid in battle!");
            }
            if (this.Weapon != null)
            {
                if (this.Weapon.successfulWield())
                {
                    sb.AppendLine($"Successfully attacked with {Weapon.Description()} and caused " +
                                $"{Weapon.calculateDamageOnHit()} points damage!");
                }
                else
                {

                    sb.AppendLine($"Attempted to attack with {Weapon.Description()} and failed! No damage inflicted!");
                }
            }
            return sb.ToString();
        }

        public override string Defend()
        {
            var sb = new StringBuilder();
            if (HasForcePower)
            {
                sb.AppendLine("Using the force to aid in battle!");
            }
            if (Weapon != null)
            {
                sb.AppendLine($"Defending with {Weapon.Description()}");
            }
            else
            {
                sb.AppendLine("Running away");
            }
            return sb.ToString();
        }
    }
}
