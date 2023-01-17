namespace Console_Game
{
    public class Event
    {

    }
    public class Player
    {
        public Weapon playerWeapon { get; set; }
        public Armor playerArmor { get; set; }
        public string name { get; set; }
        public double health { get; set; }
        public double damage { get; set; }
        public double armor { get; set; }
        public int money { get; set; }

        public double sumDamage()
        {
            return damage + playerWeapon.damage;
        }
        public double sumArmor()
        {
            return armor + playerArmor.armor;
        }

        public Player(Weapon playerWeapon, Armor playerArmor, string name, double health, double damage, double armor, int money)
        {
            this.playerWeapon = playerWeapon;
            this.playerArmor = playerArmor;
            this.name = name;
            this.health = health;
            this.damage = damage;
            this.armor = armor;
            this.money = money;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int positionX = 9;
            int positionY = 0;
            Story.StoryStart(positionX, positionY);
        }
    }
}