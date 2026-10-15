namespace CharacterDemo
{
    /// <summary>
    /// Персонаж класса Лучник. Тратит стрелы и может исцеляться.
    /// </summary>
    public class Archer : Character, IHealable
    {
        public int ArrowCount { get; set; }

        /// <summary>
        /// Вычисляемое свойство: закончились ли стрелы.
        /// </summary>
        public bool IsOutOfArrows => ArrowCount == 0;

        public Archer(int id, string name, int health, int arrows) : base(id, name, health)
        {
            ArrowCount = arrows;
        }

        public Archer(string name, int arrows) : base(name)
        {
            ArrowCount = arrows;
        }

        public override void Attack()
        {
            if (IsOutOfArrows)
            {
                Console.WriteLine($"{Name} has no arrows to shoot!");
                return;
            }
            ArrowCount--;
            Console.WriteLine($"{Name} shoots an arrow.");
        }

        public void Heal(int amount)
        {
            Health += amount;
            Console.WriteLine($"{Name} healed by {amount}.");
        }

        public override string ToString()
        {
            return $"[Archer] {Name}, HP={Health}, class: {Class}, arrows={ArrowCount}";
        }

        public CharacterClass Class { get; set; } = CharacterClass.Archer;
    }
}