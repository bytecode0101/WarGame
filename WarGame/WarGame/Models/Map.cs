using System.Text;
using WarGame.Models.Resources;
using WarGame.Utils;

namespace WarGame.Models
{
    public class Map : Serializable
    {
        #region Private Fields
        private int numberOfRows;
        private int numberOfColumns;
        private Tile[,] tiles;
        #endregion

        #region Properties

        public Tile[,] Tiles
        {
            get
            {
                return tiles;
            }

            set
            {
                tiles = value;
            }
        }

        public int NumberOfRows
        {
            get
            {
                return numberOfRows;
            }

            set
            {
                numberOfRows = value;
            }
        }

        public int NumberOfColumns
        {
            get
            {
                return numberOfColumns;
            }

            set
            {
                numberOfColumns = value;
            }
        }
        #endregion

        #region Constructors
        public Map()
        {
            Tiles = new Tile[10, 10];
        }

        internal void AddResource(Resource resource, int y, int x)
        {
            Tiles[y, x] = new Tile();
            Tiles[y, x].Resource = resource;
        }
        #endregion

        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            res.Append(NumberOfRows.ToString());

            res.Append(NumberOfRows.ToString());
            res.Append(",");
            res.AppendLine(NumberOfColumns.ToString());
            for (int y = 0; y < NumberOfRows; y++)
            {
                for (int x = 0; x < NumberOfColumns; x++)
                {
                    res.Append(Tiles[y, x].Resource.GetType().Name[0] + ",");
                }
                res = res.Remove(res.Length - 1, 1);
                res.AppendLine();
            }
            return res.ToString();
        }

        public Resource GetResource(Point location)
        {
            return Tiles[location.X, location.Y].Resource;
        }
    }
}