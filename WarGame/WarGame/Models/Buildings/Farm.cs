using WarGame.Models.Units;
using WarGame.Models.Capabilities;

namespace WarGame.Models.Buildings
{
    public class Farm : AbstractBuilding
    {
        public Farm(int y, int x, int life) : base(y, x, life)
        {
            BuildCapabilities.Add(new BuildBarrackCapability());
            TrainCapabilities.Add(new TrainFarmerCapability());
        }
        public AbstractUnit CreateFarmer()
        {
            Farmer f = new Farmer(2,2,100);
            return f;
        }
        
    }
}
