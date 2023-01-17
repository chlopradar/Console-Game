namespace Console_Game
{
    public class Map
    {
        public static void CheckIfEnemy(int positionX, int positionY, List<int> ePositionsX, List<int> ePositionsY, string[,] mapArray, Player player)
        {
            for (int i = 0; i < ePositionsX.Count(); i++)
            {
                if (positionX == ePositionsX[i] && positionY == ePositionsY[i])
                {
                    Enemy hobo = new Enemy("hobo", 10, 1,1,5);
                    Enemy bandit = new Enemy("Bandit", 20, 2,2,15);
                    Enemy undead = new Enemy("Undead", 5, 4,3,20);
                    Enemy goblin = new Enemy("Goblin", 20, 1,4,30);

                    Random rnd = new Random();
                    int enemyType = rnd.Next(20);
                    switch (enemyType)
                    {
                        case < 9:

                            Fight.FightSequence(player, hobo, i, positionX, positionY,ePositionsX, ePositionsY);
                            break;
                        case < 13:

                            Fight.FightSequence(player, bandit, i, positionX, positionY, ePositionsX, ePositionsY);
                            break;
                        case < 16:

                            Fight.FightSequence(player, undead, i, positionX, positionY, ePositionsX, ePositionsY);
                            break;
                        case < 20:

                            Fight.FightSequence(player, goblin, i, positionX, positionY, ePositionsX, ePositionsY);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        public static void GenerateEnemies(int positionX, int positionY, List<int> ePositionsX, List<int> ePositionsY, string[,] mapArray, Player player)
        {
            for (int i = 0; i < mapArray.GetLength(0); i++)
            {
                for (int j = 0; j < mapArray.GetLength(1); j++)
                {
                    for (int k = 0; k < ePositionsX.Count(); k++)
                    {
                        if (i == ePositionsX[k] && j == ePositionsY[k])
                        {

                            Console.SetCursorPosition(j * 6, i);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(mapArray[i, j] + i + " " + j);
                            Console.ForegroundColor = ConsoleColor.White;

                        }
                    }
                }
            }
            Console.SetCursorPosition(0, 11);
        }
        public static void MapView(Player player, int positionX, int positionY)
        {
            string[,] mapArray = new string[10, 10] { { "[#]", "[#]", "[#]", "[#]", "[#]", "[#]", "[#]", "[#]", "[#]", "[#]" }, { "[#]", "[#]", "[#]", "[#]", "[#]", "[#]", "[#]", "[#]", "[#]", "[#]" }, { "[#]", "[#]", "[#]", "[#]", "[#]", "[#]", "[#]", "[#]", "[#]", "[#]" }, { "[#]", "[#]", "[#]", "[#]", "[#]", "[#]", "[#]", "[#]", "[#]", "[#]" }, { "[#]", "[#]", "[#]", "[#]", "[#]", "[#]", "[#]", "[#]", "[#]", "[#]" }, { "[#]", "[#]", "[#]", "[#]", "[#]", "[#]", "[#]", "[#]", "[#]", "[#]" }, { "[#]", "[#]", "[#]", "[#]", "[#]", "[#]", "[#]", "[#]", "[#]", "[#]" }, { "[#]", "[#]", "[#]", "[#]", "[#]", "[#]", "[#]", "[#]", "[#]", "[#]" }, { "[#]", "[#]", "[#]", "[#]", "[#]", "[#]", "[#]", "[#]", "[#]", "[#]" }, { "[#]", "[#]", "[#]", "[#]", "[#]", "[#]", "[#]", "[#]", "[#]", "[#]" } };
            List<int> ePositionsX = new List<int>();
            List<int> ePositionsY = new List<int>();

            bool viewMap;
            do
            {
                Random rnd = new Random();
                if (rnd.Next(21) == 4)
                {
                    int xRand = rnd.Next(10);
                    int yRand = rnd.Next(10);
                    if (xRand != positionX || yRand != positionY)
                    {
                        ePositionsX.Add(xRand);
                        ePositionsY.Add(yRand);
                    }
                }


                Console.Clear();
                viewMap = true;
                for (int i = 0; i < mapArray.GetLength(0); i++)
                {
                    for (int j = 0; j < mapArray.GetLength(1); j++)
                    {
                        if (positionX >= mapArray.GetLength(0))
                        {
                            positionX = positionX - 1;
                        }
                        if (positionY >= mapArray.GetLength(1))
                        {
                            positionY = positionY - 1;
                        }
                        if (positionX < 0)
                        {
                            positionX = positionX + 1;
                        }
                        if (positionY < 0)
                        {
                            positionY = positionY + 1;
                        }
                        else
                        {
                            if (i == positionX && j == positionY)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(mapArray[i, j] + i + " " + j);
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            if (i != positionX || j != positionY)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(mapArray[i, j] + i + " " + j);
                            }
                        }
                    }
                    Console.WriteLine(""); //next line
                }

                GenerateEnemies(positionX, positionY, ePositionsX, ePositionsY, mapArray, player);
                CheckIfEnemy(positionX, positionY, ePositionsX, ePositionsY, mapArray, player);


                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Enemies count: " + ePositionsX.Count());                
                Console.WriteLine("Name: " + player.name);
                Console.WriteLine("");
                if (player.health == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(player.name + "'s HP: BRUTALLY WOUNDED");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(player.name + "'s HP(" + player.health + "):[" + Menu.playerHealthBar(player) + "]");
                }
                Console.WriteLine(player.name + "'s Money: " + player.money + "$");
                Console.WriteLine(player.name + "'s Damage: " + player.sumDamage());
                Console.WriteLine(player.name + "'s Armor: " + player.sumArmor());
                Console.ForegroundColor = ConsoleColor.White;
                ConsoleKeyInfo _Key = Console.ReadKey();
                switch (_Key.Key)
                {
                    case ConsoleKey.RightArrow:
                        positionY = positionY + 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        positionY = positionY - 1;
                        if (positionY < 0)
                        {
                            positionY = 0;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        positionX = positionX - 1;
                        if (positionX < 0)
                        {
                            positionX = 0;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        positionX = positionX + 1;
                        break;
                    case ConsoleKey.Escape:
                        Menu.GoToPrompt(player, positionX, positionY);
                        break;
                    default:
                        break;
                }
            } while (viewMap);
        }
    }
}
