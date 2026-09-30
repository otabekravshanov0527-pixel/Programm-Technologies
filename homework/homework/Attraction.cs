using System;

namespace homework
{
    /// <summary>Аттракцион</summary>
    public class Attraction
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int ZoneId { get; set; }
        public int OperatorId { get; set; }
        public int Capacity { get; set; }

        // ИСПРАВИЛ — теперь Price с проверкой
        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Price", "Цена не может быть отрицательной");
                _price = value;
            }
        }

        /// <summary>Пустой конструктор</summary>
        public Attraction() { }

        /// <summary>Конструктор с параметрами</summary>
        public Attraction(int id, string name, int zoneId, int operatorId, decimal price, int capacity)
        {
            Id = id;
            Name = name;
            ZoneId = zoneId;
            OperatorId = operatorId;
            Price = price;
            Capacity = capacity;
        }

        /// <summary>Экстремальный ли аттракцион (в названии есть "Экстрим")</summary>
        public bool IsExtreme => Name.Contains("Экстрим");

        /// <summary>Выручка при заданном числе посетителей. Если visitors <= 0 — 0</summary>
        public decimal GetTotalRevenue(int visitors)
        {
            if (visitors <= 0) return 0;
            return Price * visitors;
        }

        /// <summary>Краткая инфа об аттракционе</summary>
        public string GetInfo()
        {
            return Name + " (" + Price + " руб., " + Capacity + " мест)";
        }
    }
}