using NUnit.Framework;
using BakeryLibrary;

namespace BakeryTests
{
    public class Tests
    {

        [Test]
        public void TestIfAddingBakersWork()
        {
            BakeryLibrary.Bakery bakery = new BakeryLibrary.Bakery();
            bakery.HireBaker();
            Assert.AreEqual(1,bakery.listOfBakers().Count);
        }

        [Test]
        public void TestIfPayingBakersWork() {
            Payments payments = new Payments();
            BakeryLibrary.Bakery bakery = new BakeryLibrary.Bakery();
            bakery.HireBaker();
            bakery.HireApprentice();
            Assert.AreEqual(3500,payments.PayBakers(5000, bakery.listOfBakers()));
        }
    }
}