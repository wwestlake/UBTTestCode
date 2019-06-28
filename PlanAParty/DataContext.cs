using Newtonsoft.Json;
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
        private IQueryable<Attendee> _attendees;


        public IQueryable<Attendee> Attendees
        {
            get
            {
                if (_attendees != null) return _attendees;
                using (var file = File.OpenText("dataset.json"))
                {
                    var serializer = JsonSerializer.Create();
                    var reader = new JsonTextReader(file);
                    _attendees = serializer.Deserialize<List<Attendee>>(reader).AsQueryable();
                }
                return _attendees;
            }
        }

        // Private Methods (used only to generate database


        private async Task<IList<string>> Names()
        {
            return await ParseFileAsync("FirstNames.txt");
        }

        private async Task<IEnumerable<string>> RandomNames(int qty)
        {
            var names = await Names();
            var max = names.Count;
            return names.OrderBy(x => _rand.Next(max)).Take(qty);
        }


        private T RandomEnum<T>()
        {
            Array values = Enum.GetValues(typeof(T));
            return (T)values.GetValue(_rand.Next(values.Length));
        }

        private async Task<List<string>> ParseFileAsync(string filename)
        {
            var content = await ReadFile(filename);
            return await ParseFile(content);
        }

        private Task<List<string>> ParseFile(string text)
        {
            var lines = text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            return Task.FromResult(lines.ToList());
        }

        private async Task<string> ReadFile(string filename)
        {
            using (var file = File.Open(filename, FileMode.Open, FileAccess.Read))
            {
                var reader = new StreamReader(file);
                return await reader.ReadToEndAsync();
            }
        }
   }
}
