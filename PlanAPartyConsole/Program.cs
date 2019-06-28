using Newtonsoft.Json;
using PlanAParty;
using System;
using System.Collections.Generic;
using System.IO;
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
            var plan = new PartyPlanImpl(ctx);


            Console.WriteLine($"Participants: {plan.TotalParticipants}");
            Console.WriteLine($"Blue Hats   : {plan.Hats(Colors.Blue)}");
            Console.WriteLine($"Pink Hats   : {plan.Hats(Colors.Pink)}");
            Console.WriteLine($"Green Hats  : {plan.Hats(Colors.Green)}");
            Console.WriteLine($"Yellow Hats : {plan.Hats(Colors.Yellow)}");
            Console.WriteLine($"Total Hats  : {plan.TotalHats}");
            Console.ReadKey();

        }


    }
}
