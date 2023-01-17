namespace Console_Game
{
    public class Fight
    {
        public static bool FightLoop(Player player, Enemy enemy)
        {
            bool didWin = false;
            if (player.health <= 0)
            {
                didWin = false;
                return didWin;
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Fighting Alert! " + enemy.name + " appears!");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();

            do
            {
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("Player Hit! " + (player.sumDamage()) + " DMG (player HP left: " + player.health + ").");
                Console.WriteLine("HP:[" + Menu.playerHealthBar(player) + "]");

                FightMathEnemy(player, enemy);


                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Enemy Hit! " + enemy.damage + " DMG (enemy HP left: " + enemy.health + ").");
                Console.WriteLine("HP:[" + Menu.enemyHealthBar(enemy) + "]");

                FightMathPlayer(player, enemy);


                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Threading.Thread.Sleep(500);
                System.Threading.Thread.Sleep(500);
                if (enemy.health <= 0)
                {
                    didWin = true;
                }
                else
                {
                    didWin = false;
                }
                Console.Clear();
            } while (enemy.health > 0 && player.health > 0);
            return didWin;
        }

        public static void FightSequence(Player player, Enemy enemy, int i,int positionX,int positionY ,List<int> ePositionsX, List<int> ePositionsY)
        {
            if (Fight.FightLoop(player, enemy) == true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("YOU WON!");
                Console.WriteLine("+" + enemy.moneyDrop + "$");
                Console.ForegroundColor = ConsoleColor.Yellow;
                ePositionsX.RemoveAt(i);
                ePositionsY.RemoveAt(i);
                System.Threading.Thread.Sleep(1000);
                player.money = player.money + enemy.moneyDrop;
                Menu.GoToPrompt(player, positionX, positionY);
            }
            if (Fight.FightLoop(player, enemy) == false)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("YOU LOST!");
                Console.ForegroundColor = ConsoleColor.Yellow;
                player.health = 0;
                System.Threading.Thread.Sleep(1000);
                Menu.GoToPrompt(player, positionX, positionY);
            }
        }

        public static double FightMathPlayer(Player player,Enemy enemy)
        {
            player.health = player.health - (enemy.damage / player.sumArmor());
            return player.health;
        }
        public static double FightMathEnemy(Player player,Enemy enemy)
        {
            enemy.health = enemy.health - (player.sumDamage() / enemy.armor);
            return enemy.health;
        }
    }

}
