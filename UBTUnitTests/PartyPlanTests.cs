using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlanAParty;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UBTUnitTests
{
    [TestClass]
    public class PartyPlanTests
    {
        private DataContext _context;
        private IPartyPlan _partyPlan;
        private int[] _baloons = { 16, 15, 12, 12, 15, 16, 14 };
        private int[] _iceCreams = { 28, 28, 22, 22 };
        private int[] _hats = { 0, 5, 43, 15, 0, 57, 0 };

        private readonly int _totalParticipants = 120;
        private readonly int _totalChildren = 100;
        private readonly int _totalAdults = 20;

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

        [TestMethod]
        public void PartyPlan_returns_total_baloons_by_color()
        {
            var actions = new List<Action>();
            foreach (var color in BaloonColors) actions.Add( BaloonTests(color) );
            AssertAll.Execute(actions.ToArray());
        }

        private Action BaloonTests(Colors color)
        {
            return () => Assert.AreEqual(_baloons[(int)color], _partyPlan.TotalBaloonCount(color));
        }

        [TestMethod]
        public void PartyPlan_returns_total_iceCreams_by_flavor()
        {
            var actions = new List<Action>();
            foreach (var iceCream in IceCreams) actions.Add(IceCreamTests(iceCream));
            AssertAll.Execute(actions.ToArray());
        }

        private Action IceCreamTests(IceCream iceCream)
        {
            return () => Assert.AreEqual(_iceCreams[(int)iceCream], _partyPlan.TotalIceCreamScoops(iceCream));
        }


        [TestMethod]
        public void PartyPlan_returns_total_hats_by_color()
        {
            var actions = new List<Action>();
            foreach (var color in HatColors) actions.Add(HatTests(color));
            AssertAll.Execute(actions.ToArray());
        }

        private Action HatTests(Colors color)
        {
            return () => Assert.AreEqual(_hats[(int)color], _partyPlan.Hats(color));
        }

        [TestMethod]
        public void TotalHats_Matches_Total_Participants()
        {
            Assert.AreEqual(_partyPlan.TotalParticipants, _partyPlan.TotalHats);
        }
        

        // Private Methods

        private IEnumerable<Colors> BaloonColors
        {
            get
            {
                return Enumerate<Colors>();
            }
        }

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


        private IEnumerable<IceCream> IceCreams
        {
            get
            {
                return Enumerate<IceCream>();
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
