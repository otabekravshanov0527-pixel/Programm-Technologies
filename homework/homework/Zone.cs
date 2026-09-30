using System;

namespace homework
{
    /// <summary>Зона парка (аналог Genre)</summary>
    public class Zone
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Area { get; set; }

        /// <summary>Пустой конструктор</summary>
        public Zone() { }

        /// <summary>Конструктор с параметрами</summary>
        public Zone(int id, string name, int area)
        {
            Id = id;
            Name = name;
            Area = area;
        }

        /// <summary>Семейная ли зона</summary>
        public bool IsFamily => Name == "Семейная";

        /// <summary>Краткая инфа о зоне</summary>
        public string GetInfo()
        {
            return Name + " (" + Area + " м²)";
        }
    }
}