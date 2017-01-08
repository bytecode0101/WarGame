using System;

namespace WarGame.Models.Units
{
    internal class Soldier : AbstractUnit
    {
        public Soldier(int y, int x, int life) : base(y, x, life)
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

        public override AbstractUnit Upgrade()
        {
            throw new NotImplementedException();
        }
    }
}