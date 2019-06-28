using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlanAParty;
using System.Linq;

namespace UBTUnitTests
{
    [TestClass]
    public class DatContextTests
    {
        private DataContext _context;

        [TestInitialize]
        public void Setup()
        {
            _context = new DataContext();
        }


        [TestMethod]
        public void DataContext_returns_list_of_names()
        {
            var names = _context.Attendees;
            Assert.AreEqual(100, names.Count());
        }

 
    }
}
