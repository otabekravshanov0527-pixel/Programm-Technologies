namespace CharacterDemo
{
    /// Абстрактный базовый класс для всех игровых персонажей.
   
    public abstract class Character
    {
        private readonly int _id;

        public string Name { get; set; }
        public int Health { get; set; }
        public TransportState State { get; set; } = TransportState.Parked;

        /// Вычисляемое свойство: жив ли персонаж.
        public bool IsAlive => Health > 0;

        /// Основной конструктор.
       
        public Character(int id, string name, int health)
        {
            _id = id;
            Name = name;
            Health = health;
        }
   
        /// Вспомогательный конструктор с генерацией ID по умолчанию.
 
        public Character(string name) : this(0, name, 100)
        {
        }

        public abstract void Attack();
    }
}