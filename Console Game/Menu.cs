namespace Console_Game
{
    public class Menu
    {
        public static void GoToPrompt(Player player, int positionX, int positionY)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("MENU:");
            Console.WriteLine("1.Go to the Map!");
            Console.WriteLine("2.Check your inventory!");
            Console.WriteLine("3.Take a nap!");
            Console.WriteLine("4.Go to shop!");

            int menuChoice = int.Parse(Console.ReadLine());
            switch (menuChoice)
            {
                case 1:
                    Map.MapView(player, positionX, positionY);
                    break;
                case 2:
                    Console.WriteLine("~~~~~INVENTORY~~~~~");
                    GoToPrompt(player, positionX, positionY);
                    break;
                case 3:
                    Console.WriteLine("ZZzzzzz..... ");
                    GoToPrompt(player, positionX, positionY);
                    break;
                case 4:
                    player.playerWeapon = Shop.BuyingMethod(player.playerWeapon,player);
                    GoToPrompt(player, positionX, positionY);
                    break;
                default:
                    break;
            }
        }
        public static string playerHealthBar(Player player)
        {
            string playerHealthBar = "";

            for(int i = 0; i < player.health ; i++)
            {
                playerHealthBar = playerHealthBar.Insert(i, "#");
            }
            return playerHealthBar; 
        }
        public static string enemyHealthBar(Enemy enemy)
        {
            string playerHealthBar = "";

            for (int i = 0; i < enemy.health; i++)
            {
                playerHealthBar = playerHealthBar.Insert(i, "#");
            }
            return playerHealthBar;
        }
    }
}
