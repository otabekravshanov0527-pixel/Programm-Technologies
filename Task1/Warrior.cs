namespace CharacterDemo
{
    /// Персонаж класса Воин. Может носить броню и исцеляться.
    public class Warrior : Character, IHealable
    {
        public int Armor { get; set; }

        /// Вычисляемое свойство: является ли воин танком (броня должна быть со значением больше 50).
    
        public bool IsTank => Armor >= 50;

        public Warrior(int id, string name, int health, int armor) : base(id, name, health)
        {
            Armor = armor;
        }

        public Warrior(string name, int armor) : base(name)
        {
            Armor = armor;
        }

        public override void Attack()
        {
            Console.WriteLine($"{Name} swings sword.");
        }

        public void Heal(int amount)
        {
            Health += amount;
            Console.WriteLine($"{Name} healed by {amount}.");
        }

        public override string ToString()
        {
            return $"[Warrior] {Name}, HP={Health}, class: {Class}, armor={Armor}";
        }

        public CharacterClass Class { get; set; } = CharacterClass.Warrior;
    }
}