using WarGame.Models.Capabilities;


namespace WarGame.Models.Buildings

{
    class Barrack : AbstractBuilding
    {
        public Barrack(int y, int x, int life) : base(y, x, life)
        {
            BuildCapabilities.Add(new BuildBowWorkshopCapability());
            TrainCapabilities.Add(new TrainSwordmanCapability());
        }
    }
}
