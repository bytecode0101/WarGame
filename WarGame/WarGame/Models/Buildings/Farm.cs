using WarGame.Models.Units;

namespace WarGame.Models.Buildings
{
    public class Farm : Building
    {
        public Farm(int y, int x, int life) : base(y, x, life)
        {

        }
        public Unit CreateFarmer()
        {
            Farmer f = new Farmer();
            return f;
        }
        
    }
}
