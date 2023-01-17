using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Console_Game
{
    public class Inventory
    {
        public void displayInventory(Player player)
        {
            Console.WriteLine(player.name + "'s Weapon: " + player.playerWeapon.name);
        }
    }
}
