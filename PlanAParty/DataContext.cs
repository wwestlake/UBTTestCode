using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PlanAParty
{
    public class DataContext
    {
        readonly Random _rand = new Random(10);

        public IList<string> Names
        {
            get
            {
                return ParseFile("FirstNames.txt").Result;
            }
        }

        public IEnumerable<string> RandomNames(int qty)
        {
            var names = Names;
            var max = names.Count - 1;

            for (int i = 0; i < qty; i++)
            {
                yield return names[_rand.Next(max)];
            }

        }

        public IQueryable<Attendee> Attendees
        {
            get
            {
                return RandomNames(100).Select(x => {
                    return new Attendee
                    {
                        Name = x,
                        FavoriteColor = RandomEnum<Colors>(),
                        FavoriteIceCream = RandomEnum<IceCream>(),
                        Age = _rand.Next(3, 14),
                        Gender = RandomEnum<Gender>()
                    };
                }).AsQueryable<Attendee>();
            }
        }

        // Private Methods

        private T RandomEnum<T>()
        {
            Array values = Enum.GetValues(typeof(T));
            return (T)values.GetValue(_rand.Next(values.Length));
        }

        private async Task<string> ReadFile(string filename)
        {
            using (var file = File.Open(filename, FileMode.Open, FileAccess.Read))
            {
                var reader = new StreamReader(file);
                return await reader.ReadToEndAsync();
            }
        }

        private async Task<List<string>> ParseFile(string filename)
        {
            var content = await ReadFile(filename);
            var lines = content.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            return lines.ToList();
        }

    }
}
