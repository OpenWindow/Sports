using NUnit.Framework;
using Scorer.Extensions;
using System;

namespace Sports.UnitTests {
    [TestFixture]
    public class ExtensionTests {
        [Test]
        [Ignore("Ignore datetimeextension test")]
        public void DateTime_Extension_Can_Return_Start_of_Weekend() {
            //arrange
            var currentDay = DateTime.Now;
            var tomorrow = DateTime.Now.AddDays(1);

            //action
            var dt = DateTime.Now.StartOfWeekend(currentDay);
            var dtTomorrow = DateTime.Now.StartOfWeekend(tomorrow);

            //assert
            Assert.AreEqual(new DateTime(2013, 07, 06), new DateTime(dt.Year, dt.Month, dt.Day));
            Assert.AreEqual(new DateTime(2013, 07, 06), new DateTime(dtTomorrow.Year, dtTomorrow.Month, dtTomorrow.Day));
        }
    }
}
