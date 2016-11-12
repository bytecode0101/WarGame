using WarGame.Models.Resources;

namespace WarGame.Models
{
    public class Tile
    {
        private Resource resource;

        public Resource Resource
        {
            get
            {
                return resource;
            }

            set
            {
                resource = value;
            }
        }
    }
}