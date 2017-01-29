using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Timers;
using WarGame.Models.Buildings;
using WarGame.Models.Events;
using WarGame.Models.Resources;
using WarGame.Models.Units;

namespace WarGame.Models
{
    public class Game
    {

        #region Events

        public event NewTurn NewTurnEvent;

        #endregion

        #region Private Fields
        private List<Player> players;
        private Map map;
        private int currentTurn;
        private Timer timer;
        private int turnNumber = 0;

        private static Game instance;
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
                foreach (var item in players)
                {
                    item.Map = map;
                }
            }
        }

        public List<Player> Players
        {
            get
            {
                return players;
            }

            set
            {
                players = value;
            }
        }

        public int CurrentTurn
        {
            get
            {
                return currentTurn;
            }
            set
            {
                currentTurn = value;
            }
        }

        public static Game Instance
        {
            get
            {
                if (instance == null)
                    instance = new Game();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        #endregion

        #region Constructors
        private Game()
        {
            Players = new List<Player>();
            timer = new Timer();
            timer.Interval = 200;
            timer.AutoReset = true;
            timer.Elapsed += OnNewTurn;
            timer.Start();
        }

        private void OnNewTurn(object sender, ElapsedEventArgs e)
        {
            turnNumber++;
            NewTurnEvent?.Invoke(this, new NewTurnArgs() { TurnNumber = turnNumber }); 
           
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

        public void NewTurn()
        {
            foreach (var item in Players)
            {
                item.NewTurn();
            }
        }
        #endregion

        #region Private Methods
        private string SerializeGame()
        {
            StringBuilder res = new StringBuilder();
            res.Append(Map.Serialize());
            foreach (var item in Players)
            {
                res.AppendLine(item.Units.Count.ToString());
                for (int i = 0; i < item.Units.Count; i++)
                {
                    res.AppendLine(string.Format("{0},{1},{2},{3}",
                        item.Units[i].GetType().Name, item.Units[i].Position.Y, item.Units[i].Position.X, item.Units[i].Life));
                }
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
                            map.AddResource(Resource.Food, y, x);
                            break;
                        case "S":
                            map.AddResource(Resource.Stone, y, x);
                            break;
                        case "G":
                            map.AddResource(Resource.Gold, y, x);
                            break;
                        case "I":
                            map.AddResource(Resource.Iron, y, x);
                            break;
                        case "W":
                            map.AddResource(Resource.Wood, y, x);
                            break;
                        default:
                            //TODO: log error 
                            break;
                    }
                    x++;
                }
            }

            //var noOfUnits = int.Parse(tr.ReadLine());
            //for (int i = 0; i < noOfUnits; i++)
            //{
            //    var row = tr.ReadLine();
            //    var cells = row.Split(',');
            //    switch (cells[0])
            //    {
            //        case "Farmer":
            //            {
            //                int y = int.Parse(cells[1]);
            //                int x = int.Parse(cells[2]);
            //                int life = int.Parse(cells[3]);
            //                var farmer = new Farmer(y, x, life);
            //                Player _player = new Player();
            //                _player.AddUnit(farmer);
            //                Players.Add(_player);
            //            }
            //            break;
            //        case "Swordman":
            //            {
            //                int y = int.Parse(cells[1]);
            //                int x = int.Parse(cells[2]);
            //                int life = int.Parse(cells[3]);
            //                var farmer = new Farmer(y, x, life);
            //              //TODO: upgrade the farmer, update the player
            //            }
            //            break;
            //        default:
            //            break;
            //    }
            //}

            var noOfBuildings = int.Parse(tr.ReadLine());
            for (int i = 0; i <noOfBuildings; i++)
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
                            //Players.AddBuilding(farm);
                        }
                        break;
                    case "Barrack":
                        {
                            int y = int.Parse(cells[1]);
                            int x = int.Parse(cells[2]);
                            int life = int.Parse(cells[3]);
                            var barrack = new Barrack(y, x, life);
                            //Players.AddBuilding(barrack);
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
