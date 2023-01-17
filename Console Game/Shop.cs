using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Game
{
    public class Shop
    {
        public static Weapon WeaponShop(Player player)
        {
            Console.Clear();
            Console.WriteLine("Which weapon would You like to buy?:");
            Console.WriteLine("1.Wooden Sword");
            Console.WriteLine("2.Stone Sword");
            Console.WriteLine("3.Iron Sword");
            Console.WriteLine("4.Bones and Gold Sword");

            Weapon WoodenSword = new Weapon("Wooden Sword", 1, 3, 5);
            Weapon StoneSword = new Weapon("Stone Sword", 2, 6, 100);
            Weapon IronSword = new Weapon("Iron Sword", 3, 10, 200);
            Weapon BonesAndGoldSword = new Weapon("Bones and Gold Sword", 4, 17, 300);

            Weapon none = new Weapon("none", 0, 0, 0);

            int choice = int.Parse(Console.ReadLine());
            switch(choice)
            {
                case 1:
                    if(MoneyCalc(player,WoodenSword.name,WoodenSword.itemValue))
                    {
                        return WoodenSword;
                    }
                    else
                    {
                        return none;
                    }
                case 2:
                    if (MoneyCalc(player, StoneSword.name, StoneSword.itemValue))
                    {
                        return StoneSword;
                    }
                    else
                    {
                        return none;
                    }
                case 3:
                    if (MoneyCalc(player, IronSword.name, IronSword.itemValue))
                    {
                        return IronSword;
                    }
                    else
                    {
                        return none;
                    }
                case 4:
                    if (MoneyCalc(player, BonesAndGoldSword.name, BonesAndGoldSword.itemValue))
                    {
                        return BonesAndGoldSword;
                    }
                    else
                    {
                        return none;
                    }
                default:                  
                    return none;
            }
        }
        public static bool MoneyCalc(Player player,string itemName,int itemValue)
        {
            if(player.money >= itemValue)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                player.money = player.money - itemValue;
                Console.WriteLine(itemName + " bought!");
                System.Threading.Thread.Sleep(2000);
                Console.ForegroundColor = ConsoleColor.Yellow;
                return true;
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Not enugh money!");
                Console.WriteLine(itemName + " costs " + itemValue + "$, while you have " + player.money + "$.");
                System.Threading.Thread.Sleep(2000);
                Console.ForegroundColor = ConsoleColor.Yellow;
                return false;
            }
        }
        public static Weapon BuyingMethod(Weapon playerWeapon, Player player)
        {
            playerWeapon = WeaponShop(player);
            return playerWeapon;
        }
    }
}
