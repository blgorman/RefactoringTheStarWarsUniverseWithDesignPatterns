using System.Text;

namespace StarWarsCharacterModels.Characters
{
    public class SithLord : Character
    {
        public SithLord(string name, int age, double height, double weight, int classificationChoice, int speciesChoice, int weaponChoice, Random random) :
            base(name, age, height, weight, classificationChoice, speciesChoice, weaponChoice, true, true, random)
        {

        }
    }
}
