using System.Text;

namespace StarWarsCharacterModels.Characters
{
    public class Politician : Character
    {
        public Politician(string name, int age, double height, double weight, int classificationChoice, int speciesChoice, int weaponChoice, bool canHaveTheForce, bool mustHaveTheForce, Random random) :
            base(name, age, height, weight, classificationChoice, speciesChoice, weaponChoice, canHaveTheForce, mustHaveTheForce, random)
        {

        }
    }
}
