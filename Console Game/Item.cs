using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Game
{
    public class Item
    {
        public string name { get; set; }
        public int id { get; set; }
        public int itemValue { get; set; }
    }

    public class Weapon : Item
    {
        public double damage { get; set; }
        public Weapon(string name, int id,double damage,int itemValue)
        {
            this.name = name;
            this.id = id;
            this.damage = damage;
            this.itemValue = itemValue;
        }
    }
    public class Armor : Item
    {
        public double armor { get; set; }
        public Armor(string name, int id, double armor,int itemValue)
        {
            this.name = name;
            this.id = id;
            this.armor = armor;
            this.itemValue = itemValue;
        }
    }
}
