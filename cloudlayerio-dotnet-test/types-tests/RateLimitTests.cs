using System;
using cloudlayerio_dotnet.responses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace cloudlayerio_dotnet_test.types_tests
{
    [TestClass]
    public class RateLimitTests
    {
        [TestMethod]
        public void RemainingTestConversion()
        {
            var timeRemaining1SecAgo = ((DateTimeOffset) DateTime.Now.AddSeconds(-1)).ToUnixTimeSeconds();

            var rateLimits = new RateLimits
            {
                Reset = timeRemaining1SecAgo
            };

            Assert.AreEqual(1, rateLimits.ResetSeconds);
        }
    }
}