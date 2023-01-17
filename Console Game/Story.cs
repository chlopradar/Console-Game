namespace Console_Game
{
    public class Story
    {
        public static void StoryStart(int positionX, int positionY)
        {
            Weapon noneWeapon = new Weapon("none", 0, 0,0);
            Armor noneArmor = new Armor("none", 0, 0,0);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("CREATE YOUR CHARACTER:");
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("Type your name: ");
            string name = Console.ReadLine();
            Player player = new Player(noneWeapon, noneArmor,name,50,1,1,0);
            Menu.GoToPrompt(player, positionX, positionY);

        }
    }
}
