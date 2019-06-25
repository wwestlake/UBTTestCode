using PlanAParty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanAPartyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new DataContext();
            foreach (var a in ctx.Attendees)
            {
                Console.WriteLine($"{a.Name}, {a.Age}, {a.FavoriteColor}, {a.FavoriteIceCream}, {a.Gender}");
            }

            Console.ReadKey();

        }
    }
}
