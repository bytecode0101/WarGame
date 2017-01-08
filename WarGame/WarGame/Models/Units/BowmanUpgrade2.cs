﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGame.Models.Units;

namespace WarGame.Models.Units
{
    class BowmanUpgrade2<T>:DecoratorUnit<T> where T: BowmanUpgrade1<Farmer>
    {
        public BowmanUpgrade2(int x,int y,int life):base(x,y,life)
        {

        }

        public override void Attack()
        {
            throw new NotImplementedException();
        }

        public override void GatherResource(Tile argTile)
        {
            throw new NotImplementedException();
        }

        public override void Move(Point destination)
        {
            throw new NotImplementedException();
        }
    }
}
