using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlanAParty;

namespace UBTUnitTests
{
    [TestClass]
    public class PartyPlanTests
    {
        private DataContext _context;
        private IPartyPlan _partyPlan;

        private readonly int _totalParticipants = 124;
        private readonly int _totalChildren = 100;
        private readonly int _totalAdults = 24;

        [TestInitialize]
        public void Setup()
        {
            _context = new DataContext();
            _partyPlan = new PartyPlanImpl(_context);
        }

        [TestMethod]
        public void PartyPlan_returns_total_participants()
        {
            Assert.AreEqual(_totalParticipants, _partyPlan.TotalParticipants);
        }

        [TestMethod]
        public void PartyPlan_returns_total_children()
        {
            Assert.AreEqual(_totalChildren, _partyPlan.TotalChildren);
        }

        [TestMethod]
        public void PartyPlan_returns_total_adults()
        {
            Assert.AreEqual(_totalAdults, _partyPlan.TotalAdults);
        }

    }
}
