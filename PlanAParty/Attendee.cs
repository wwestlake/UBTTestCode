using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanAParty
{


    /// <summary>
    /// Contains information on each party attendee
    /// </summary>
    public class Attendee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Colors FavoriteColor { get; set; }
        public IceCream FavoriteIceCream { get; set; }
        public Gender Gender { get; set; }

    }
}
