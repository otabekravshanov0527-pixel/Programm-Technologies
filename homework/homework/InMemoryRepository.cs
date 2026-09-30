using System;
using System.Collections.Generic;

namespace homework
{
    /// <summary>Репозиторий с данными в памяти</summary>
    public class InMemoryRepository
    {
        private List<Zone> _zones;
        private List<Operator> _operators;
        private List<Attraction> _attractions;

        public InMemoryRepository()
        {
            _zones = new List<Zone>
            {
                new Zone { Id = 1, Name = "Семейная", Area = 500 },
                new Zone { Id = 2, Name = "Экстрим", Area = 800 },
                new Zone { Id = 3, Name = "Детская", Area = 300 },
                new Zone { Id = 4, Name = "Водная", Area = 600 },
                new Zone { Id = 5, Name = "Развлекательная", Area = 700 }
            };

            _operators = new List<Operator>
            {
                new Operator { Id = 1, FullName = "Сидоров С.С.", Shift = "Дневная", Experience = 5 },
                new Operator { Id = 2, FullName = "Петров П.П.", Shift = "Вечерняя", Experience = 2 },
                new Operator { Id = 3, FullName = "Иванов И.И.", Shift = "Ночная", Experience = 4 },
                new Operator { Id = 4, FullName = "Смирнов А.А.", Shift = "Дневная", Experience = 1 },
                new Operator { Id = 5, FullName = "Кузнецов К.К.", Shift = "Вечерняя", Experience = 6 }
            };

            _attractions = new List<Attraction>
            {
                new Attraction { Id = 1, Name = "Колесо обозрения", ZoneId = 1, OperatorId = 1, Price = 300, Capacity = 50 },
                new Attraction { Id = 2, Name = "Американские горки", ZoneId = 2, OperatorId = 2, Price = 500, Capacity = 30 },
                new Attraction { Id = 3, Name = "Экстрим-прыжок", ZoneId = 2, OperatorId = 3, Price = 700, Capacity = 20 },
                new Attraction { Id = 4, Name = "Карусель", ZoneId = 3, OperatorId = 4, Price = 150, Capacity = 40 },
                new Attraction { Id = 5, Name = "Водный экстрим", ZoneId = 4, OperatorId = 5, Price = 400, Capacity = 25 }
            };
        }

        public List<Zone> GetZones() { return _zones; }
        public List<Operator> GetOperators() { return _operators; }
        public List<Attraction> GetAttractions() { return _attractions; }
    }
}