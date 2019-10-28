using NUnit.Framework;
using Bakery;

namespace BakeryTests
{
    public class Tests
    {

        [Test]
        public void TestIfAddingBakersWork()
        {
            Bakery.Bakery bakery = new Bakery.Bakery();
            bakery.HireBaker();
            Assert.AreEqual(1,bakery.ReturnBakers().Count);
        }

        [Test]
        public void TestIfPayingBakersWork() {
            Payments payments = new Payments();
            Bakery.Bakery bakery = new Bakery.Bakery();
            bakery.HireBaker();
            bakery.HireApprentice();
            Assert.AreEqual(3500,payments.PayBakers(5000, bakery.ReturnBakers()));
        }
    }
}