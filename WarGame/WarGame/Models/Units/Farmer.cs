﻿using System;

namespace WarGame.Models.Units
{
    class Farmer : Unit
    {
        public Farmer(int y, int x, int life) : base(y, x, life)
        {
        }

        public override void Attack()
        {
            throw new NotImplementedException();
        }

        public override void Move(Point destination)
        {
            throw new NotImplementedException();
        }
    }
}