using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Models.Units
{
    class Bowman : AbstractUnit
    {
        public Bowman(int y, int x, int life) : base(y, x, life)
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
