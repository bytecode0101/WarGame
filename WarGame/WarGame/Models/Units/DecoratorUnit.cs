using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Models.Units
{
    public abstract class DecoratorUnit<T>:AbstractUnit
    {
        AbstractUnit unit;

        public AbstractUnit Unit
        {
            get
            {
                return unit;
            }

            set
            {
                unit = value;
            }
        }

        public virtual AbstractUnit Upgrade(AbstractUnit unit)
        {
            this.Unit = unit;
            return this;
        }
    }
}
