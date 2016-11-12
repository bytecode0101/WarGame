using Newtonsoft.Json;
using System.IO;
using System.Text;
using WarGame.Models.Buildings;
using WarGame.Models.Resources;
using WarGame.Models.Units;

namespace WarGame.Models
{
    public class Game
    {
        #region Private Fields
        private Player player;
        private Map map;
        #endregion

        #region Properties
        public Map Map
        {
            get
            {
                return map;
            }

            set
            {
                map = value;
                Player.Map = map;
            }
        }

        public Player Player
        {
            get
            {
                return player;
            }

            set
            {
                player = value;
            }
        }
        #endregion

        #region Constructors
        public Game()
        {
            Player = new Player();
        }
        #endregion

        #region Public Methods
        public void Start()
        {
        }

        public void Load(string path)
        {
            string text;
            using (var sr = new StreamReader(path))
            {
                text = sr.ReadToEnd();
            }
            DeserializeGame(text);
        }

        public void Save(string path)
        {
            var text = SerializeGame();
            using (var sw = new StreamWriter(path))
            {
                sw.Write(text);
            }
        }
        #endregion

        #region Private Methods
        private string SerializeGame()
        {
            StringBuilder res = new StringBuilder();
            res.Append(Map.Serialize());

            res.AppendLine(Player.Units.Count.ToString());
            for (int i = 0; i < Player.Units.Count; i++)
            {
                res.AppendLine(string.Format("{0},{1},{2},{3}",
                    Player.Units[i].GetType().Name, Player.Units[i].Position.Y, Player.Units[i].Position.X, Player.Units[i].Life));
            }
            return res.ToString();
        }

        public void SaveJson(string path)
        {
            JsonSerializer serializer = new JsonSerializer();
            var sw = new StreamWriter(path);
            using (JsonWriter writer = new JsonTextWriter(sw) { Formatting = Formatting.Indented })
            {
                serializer.Serialize(writer, this);
            }
        }

        private void DeserializeGame(string text)
        {
            Map = new Map();

            TextReader tr = new StringReader(text);
            var size = tr.ReadLine();
            map.NumberOfRows = int.Parse(size.Split(',')[0]);
            map.NumberOfColumns = int.Parse(size.Split(',')[1]);

            for (int y = 0; y < Map.NumberOfRows; y++)
            {
                var row = tr.ReadLine();
                var resources = row.Split(',');
                int x = 0;
                foreach (var resource in resources)
                {
                    switch (resource)
                    {
                        case "F":
                            map.AddResource(new Food(), y, x);
                            break;
                        case "S":
                            map.AddResource(new Stone(), y, x);
                            break;
                        case "G":
                            map.AddResource(new Gold(), y, x);
                            break;
                        case "I":
                            map.AddResource(new Iron(), y, x);
                            break;
                        case "W":
                            map.AddResource(new Wood(), y, x);
                            break;
                        default:
                            //TODO: log error 
                            break;
                    }
                    x++;
                }
            }

            var noOfUnits = int.Parse(tr.ReadLine());
            for (int i = 0; i < noOfUnits; i++)
            {
                var row = tr.ReadLine();
                var cells = row.Split(',');
                switch (cells[0])
                {
                    case "Farmer":
                        {
                            int y = int.Parse(cells[1]);
                            int x = int.Parse(cells[2]);
                            int life = int.Parse(cells[3]);
                            var farmer = new Farmer(y, x, life);
                            Player.AddUnit(farmer);
                        }
                        break;
                    case "Soldier":
                        {
                            int y = int.Parse(cells[1]);
                            int x = int.Parse(cells[2]);
                            int life = int.Parse(cells[3]);
                            var farmer = new Soldier(y, x, life);
                            Player.AddUnit(farmer);
                        }
                        break;
                    default:
                        break;
                }
            }

            var noOfBuildings= int.Parse(tr.ReadLine());
            for (int i = 0; i < noOfUnits; i++)
            {
                var row = tr.ReadLine();
                var cells = row.Split(',');
                switch (cells[0])
                {
                    case "Farm":
                        {
                            int y = int.Parse(cells[1]);
                            int x = int.Parse(cells[2]);
                            int life = int.Parse(cells[3]);
                            var farm = new Farm(y, x, life);
                            Player.AddBuilding(farm);
                        }
                        break;
                    case "Barrack":
                        {
                            int y = int.Parse(cells[1]);
                            int x = int.Parse(cells[2]);
                            int life = int.Parse(cells[3]);
                            var barrack = new Barrack(y, x, life);
                            Player.AddBuilding(barrack);
                        }
                        break;
                    default:
                        break;
                }
            }
            }
        #endregion
    }
}
