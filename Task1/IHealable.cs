namespace CharacterDemo
{
    /// Интерфейс для персонажей, способных исцелять себя.
    
    public interface IHealable
    {
        
        ///  Востановление здоровья (Метод)
        void Heal(int amount);
    }
}