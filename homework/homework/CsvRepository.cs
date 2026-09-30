using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace homework
{
    /// <summary>Репозиторий, читающий данные из CSV</summary>
    public class CsvRepository
    {
        private string _basePath;

        public CsvRepository(string basePath) { _basePath = basePath; }

        public List<Zone> GetZones()
        {
            List<Zone> result = new List<Zone>();
            string path = Path.Combine(_basePath, "zones.csv");
            if (!File.Exists(path)) return result;
            string[] lines = File.ReadAllLines(path);
            if (lines.Length < 2) return result;
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                if (parts.Length < 3) continue;

                Zone z = new Zone();
                z.Id = int.Parse(parts[0]);
                z.Name = parts[1];
                z.Area = int.Parse(parts[2]);

                // правило Name зоны уникально — пропускаем дубликат
                if (NameExists(result, z.Name)) continue;

                result.Add(z);
            }
            return result;
        }

        public List<Operator> GetOperators()
        {
            List<Operator> result = new List<Operator>();
            string path = Path.Combine(_basePath, "operators.csv");
            if (!File.Exists(path)) return result;
            string[] lines = File.ReadAllLines(path);
            if (lines.Length < 2) return result;
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                if (parts.Length < 4) continue;

                Operator o = new Operator();
                o.Id = int.Parse(parts[0]);
                o.FullName = parts[1];
                o.Shift = parts[2];
                o.Experience = int.Parse(parts[3]);

                // правило FullName оператора НЕ уникально — не проверяем
                result.Add(o);
            }
            return result;
        }

        public List<Attraction> GetAttractions()
        {
            List<Attraction> result = new List<Attraction>();
            string path = Path.Combine(_basePath, "attractions.csv");
            if (!File.Exists(path)) return result;
            string[] lines = File.ReadAllLines(path);
            if (lines.Length < 2) return result;
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                if (parts.Length < 6) continue;

                decimal price = decimal.Parse(parts[4], CultureInfo.InvariantCulture);

                // правило Price >= 0 — пропускаем плохую строку
                if (price < 0)
                {
                    Console.WriteLine("Пропущен аттракцион с отрицательной ценой");
                    continue;
                }

                Attraction a = new Attraction();
                a.Id = int.Parse(parts[0]);
                a.Name = parts[1];
                a.ZoneId = int.Parse(parts[2]);
                a.OperatorId = int.Parse(parts[3]);
                a.Price = price;
                a.Capacity = int.Parse(parts[5]);

                // правило Name аттракциона НЕ уникально — не проверяем
                result.Add(a);
            }
            return result;
        }

        // хелпер для проверки уникальности Name зоны
        static bool NameExists(List<Zone> zones, string name)
        {
            foreach (Zone z in zones)
                if (z.Name == name) return true;
            return false;
        }
    }
}