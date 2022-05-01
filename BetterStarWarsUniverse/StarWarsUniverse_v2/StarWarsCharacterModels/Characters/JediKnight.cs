using System.Text;

namespace StarWarsCharacterModels.Characters
{
    public class JediKnight : Character
    {
        public JediKnight(string name, int age, double height, double weight, int classificationChoice, int speciesChoice, int weaponChoice, Random random) :
            base(name, age, height, weight, classificationChoice, speciesChoice, weaponChoice, true, true, random)
        {
        }



    }
}
