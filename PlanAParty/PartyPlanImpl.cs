using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanAParty
{
    public class PartyPlanImpl : IPartyPlan
    {
        private DataContext _context;
 

        public PartyPlanImpl(DataContext context)
        {
            _context = context;
        }

        public int TotalParticipants
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int TotalChildren
        {
            get
            {
                throw new NotImplementedException();
            }
        }


        public int TotalAdults
        {
            get
            {
                throw new NotImplementedException();
            }
        }


        public int TotalSandwitches
        {
            get
            {
                throw new NotImplementedException();
            }
        }


        public int Coffee
        {
            get
            {
                throw new NotImplementedException();
            }
        }


        public int TotalBaloonCount(Colors color)
        {
            throw new NotImplementedException();
        }

        public int TotalIceCreamScoops(IceCream iceCream)
        {
            throw new NotImplementedException();
        }

        public int Hats(Colors color)
        {
            throw new NotImplementedException();
        }

        public int TotalHats
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        // Private members use as needed

        private IEnumerable<Colors> HatColors
        {
            get
            {
                return Enumerate<Colors>().Where(
                    x => x == Colors.Blue
                    || x == Colors.Green
                    || x == Colors.Pink
                    || x == Colors.Yellow
                );
            }
        }

        private IEnumerable<T> Enumerate<T>()
        {
            var values = Enum.GetValues(typeof(T));
            foreach (var val in values)
            {
                yield return (T)val;
            }

        }

    }
}
