using System;

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
    }
}
