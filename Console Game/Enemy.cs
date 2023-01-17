namespace Console_Game
{
    public class Enemy
    {
        public string name { get; set; }
        public double health { get; set; }
        public double damage { get; set; }
        public double armor { get; set; }
        public int moneyDrop { get; set; }

        public Enemy(string name, double health, double damage, double armor, int moneyDrop)
        {
            this.name = name;
            this.health = health;
            this.damage = damage;
            this.armor = armor;
            this.moneyDrop = moneyDrop;
        }
    }
}




