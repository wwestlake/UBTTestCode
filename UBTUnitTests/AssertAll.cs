using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UBTUnitTests
{
    public static class AssertAll
    {

        public static void Execute(params Action[] assertionsToRun)
        {
            var errorMessages = new List<Exception>();
            foreach (var action in assertionsToRun)
            {
                try
                {
                    action.Invoke();
                }
                catch (Exception exc)
                {
                    errorMessages.Add(exc);
                }
            }

            if (errorMessages.Any())
            {
                var separator = string.Format("{0}{0}", Environment.NewLine);
                string errorMessageString = string.Join(separator, errorMessages);

                Assert.Fail(string.Format("The following condtions failed:{0}{1}",
                                Environment.NewLine, errorMessageString));
            }
        }
    }
}
