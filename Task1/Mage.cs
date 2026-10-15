namespace CharacterDemo
{
    
    /// Персонаж класса Маг.
  
    public class Mage : Character
    {
        public int Mana { get; set; }

 
        public bool IsPowerful => Mana > 100;

        public Mage(int id, string name, int health, int mana) : base(id, name, health)
        {
            Mana = mana;
        }

        public Mage(string name, int mana) : base(name)
        {
            Mana = mana;
        }

        public override void Attack()
        {
            Console.WriteLine($"{Name} casts a fireball.");
        }

        public override string ToString()
        {
            return $"[Mage] {Name}, HP={Health}, class: {Class}, mana={Mana}";
        }

        public CharacterClass Class { get; set; } = CharacterClass.Mage;
    }
}