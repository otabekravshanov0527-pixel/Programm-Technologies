using System;

namespace homework
{
    /// <summary>Оператор аттракциона (аналог Movie)</summary>
    public class Operator
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Shift { get; set; } = string.Empty;
        public int Experience { get; set; }

        /// <summary>Пустой конструктор</summary>
        public Operator() { }

        /// <summary>Конструктор с параметрами</summary>
        public Operator(int id, string fullName, string shift, int experience)
        {
            Id = id;
            FullName = fullName;
            Shift = shift;
            Experience = experience;
        }

        /// <summary>Опытный ли оператор (стаж > 3 лет)</summary>
        public bool IsExperienced => Experience > 3;

        /// <summary>Краткая инфа об операторе</summary>
        public string GetInfo()
        {
            return FullName + " (" + Experience + " лет опыта)";
        }
    }
}