// Домашняя работа Равшанов, 210б - 16 вариант " Парк аттракционов "

using System;
using System.Collections.Generic;

namespace homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("1 - Через InMemoryRepository");
            Console.WriteLine("2 - Через CSV");
            Console.Write("выбери как пойдем дальше дружище: ");
            string choice = Console.ReadLine();

            List<Zone> zones;
            List<Operator> operators;
            List<Attraction> attractions;

            // try/catch вокруг всего switch
            try
            {
                switch (choice)
                {
                    case "1":
                        InMemoryRepository mem = new InMemoryRepository();
                        zones = mem.GetZones();
                        operators = mem.GetOperators();
                        attractions = mem.GetAttractions();
                        break;

                    case "2":
                        CsvRepository csv = new CsvRepository("data");
                        zones = csv.GetZones();
                        operators = csv.GetOperators();
                        attractions = csv.GetAttractions();
                        break;

                    default:
                        Console.WriteLine("Неверный выбор");
                        return;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
                return;
            }

            Console.WriteLine();

            Operator op = FindOperator("Колесо обозрения", attractions, operators);
            Console.WriteLine("1. FindOperator(\"Колесо обозрения\"): " + (op == null ? "null" : op.GetInfo()));

            op = FindOperator("Неизвестный аттракцион", attractions, operators);
            Console.WriteLine("   FindOperator(\"Неизвестный аттракцион\"): " + (op == null ? "null" : op.GetInfo()));

            Zone zone = FindZone("Колесо обозрения", attractions, zones);
            Console.WriteLine("2. FindZone(attraction \"Колесо обозрения\"): " + (zone == null ? "null" : zone.GetInfo()));

            Console.WriteLine("3. GetTotalCapacity: " + GetTotalCapacity(attractions) + " человек");

            Zone maxZone = GetZoneWithMaxCapacity(zones, attractions);
            if (maxZone == null)
                Console.WriteLine("4. GetZoneWithMaxCapacity: null");
            else
                Console.WriteLine("4. GetZoneWithMaxCapacity: " + maxZone.Name + " (" + GetTotalCapacityForZone(maxZone.Id, attractions) + ")");

            Console.WriteLine("5. PrintAllAttractions:");
            PrintAllAttractions(attractions, operators, zones);
        }

        /// <summary>поиск оператора по названию аттракциона. Не найдено тогда null</summary>
        static Operator FindOperator(string attractionName, List<Attraction> attractions, List<Operator> operators)
        {
            if (attractions == null || operators == null || attractionName == null) return null;
            Attraction found = FindAttraction(attractions, attractionName);
            if (found == null) return null;
            return GetOperator(operators, found.OperatorId);
        }

        /// <summary>поиск зоны по названию аттракциона. Не найдено тогда null</summary>
        static Zone FindZone(string attractionName, List<Attraction> attractions, List<Zone> zones)
        {
            if (attractions == null || zones == null || attractionName == null) return null;
            Attraction found = FindAttraction(attractions, attractionName);
            if (found == null) return null;
            return GetZone(zones, found.ZoneId);
        }

        /// <summary>ищет аттракцион по имени. Name не уникально — возвращает первую найденную</summary>
        static Attraction FindAttraction(List<Attraction> attractions, string name)
        {
            if (attractions == null) return null;
            foreach (Attraction a in attractions)
                if (a.Name == name) return a;
            return null;
        }

        /// <summary>ищет оператора по Id</summary>
        static Operator GetOperator(List<Operator> operators, int id)
        {
            if (operators == null) return null;
            foreach (Operator o in operators)
                if (o.Id == id) return o;
            return null;
        }

        /// <summary>ищет зону по Id</summary>
        static Zone GetZone(List<Zone> zones, int id)
        {
            if (zones == null) return null;
            foreach (Zone z in zones)
                if (z.Id == id) return z;
            return null;
        }

        /// <summary>суммарная вместимость всех аттракционов. Пустой список — 0</summary>
        static int GetTotalCapacity(List<Attraction> attractions)
        {
            if (attractions == null) return 0;
            int total = 0;
            foreach (Attraction a in attractions) total = total + a.Capacity;
            return total;
        }

        /// <summary>суммарная вместимость аттракционов в одной зоне</summary>
        static int GetTotalCapacityForZone(int zoneId, List<Attraction> attractions)
        {
            if (attractions == null) return 0;
            int total = 0;
            foreach (Attraction a in attractions)
                if (a.ZoneId == zoneId) total = total + a.Capacity;
            return total;
        }

        /// <summary>зона с макс. вместимостью. При равенстве — первая. Нет аттракционов — null</summary>
        static Zone GetZoneWithMaxCapacity(List<Zone> zones, List<Attraction> attractions)
        {
            if (zones == null || attractions == null) return null;
            if (attractions.Count == 0) return null;

            Zone best = null;
            int bestCap = -1;
            foreach (Zone z in zones)
            {
                int cap = GetTotalCapacityForZone(z.Id, attractions);
                if (cap > bestCap)
                {
                    bestCap = cap;
                    best = z;
                }
            }
            return best;
        }

        /// <summary>вывод всех аттракционов с оператором и зоной. Не найдено — "—"</summary>
        static void PrintAllAttractions(List<Attraction> attractions, List<Operator> operators, List<Zone> zones)
        {
            if (attractions == null) return;
            foreach (Attraction a in attractions)
            {
                Operator op = GetOperator(operators, a.OperatorId);
                Zone z = GetZone(zones, a.ZoneId);

                string opName = (op == null) ? "—" : op.FullName;
                string zoneName = (z == null) ? "—" : z.Name;

                Console.WriteLine("   \"" + a.GetInfo() + "\" — оператор " + opName + ", зона \"" + zoneName + "\"");
            }
        }
    }
}