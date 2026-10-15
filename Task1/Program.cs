
namespace CharacterDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var party = new List<Character>
            {
                new Warrior(1, "Conan", 200, 60),
                new Mage(2, "Merlin", 80, 150),
                new Archer(3, "Robin", 120, 0)
            };

            foreach (var member in party)
            {
                Console.WriteLine(member);
                Console.WriteLine($"  alive: {member.IsAlive}");
                Console.WriteLine($"  state: {member.State}");

                member.Attack();

                // Проверка интерфейса через pattern matching
                if (member is IHealable healable)
                {
                    healable.Heal(50);
                }
                else
                {
                    Console.WriteLine($"{member.Name} cannot be healed.");
                }

                // Проверка специфичных свойств через pattern matching
                switch (member)
                {
                    case Warrior w:
                        Console.WriteLine($"  is tank: {w.IsTank}");
                        break;
                    case Mage m:
                        Console.WriteLine($"  is powerful: {m.IsPowerful}");
                        break;
                    case Archer a:
                        Console.WriteLine($"  out of arrows: {a.IsOutOfArrows}");
                        break;
                }

                Console.WriteLine(new string('-', 40));
            }
        }
    }
}