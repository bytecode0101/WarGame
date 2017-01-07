﻿using System;
using WarGame.Models.Capabilities;

namespace WarGame.Models.Buildings
{
    class BowWorkshop : AbstractBuilding
    {
        public BowWorkshop(int y, int x, int life) : base(y, x, life)
        {
            TrainCapabilities.Add(new TrainBowmanCapability());
        }

        public override AbstractBuilding Upgrade()
        {
            throw new NotImplementedException();
        }
    }
}
