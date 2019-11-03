using NUnit.Framework;
using BakeryLibrary;
using System;

namespace BakeryTests
{
    public class Tests
    {

        [Test]
        public void TestIfAddingBakersWork()
        {
            Bakery bakery = new Bakery();
            DateTime test = DateTime.Now;
            bakery.HireBaker(test);
            Assert.AreEqual(1, bakery.listOfBakers.Count);
        }

        [Test]
        public void TestIfPayingBakersWork()
        {
            Payment payments = new Payment();
            Bakery bakery = new Bakery();
            DateTime test = DateTime.Now;
            bakery.HireBaker(test);
            bakery.HireApprentice(test);
            Assert.AreEqual(3700, payments.PayBakers(5000, bakery.listOfBakers));
        }

        [Test]
        public void TestIfPayingRentWorks()
        {
            Payment payments = new Payment();
            Assert.AreEqual(7000, payments.PayRent(8000));
        }

        [Test]
        public void TestIfUpgradingBakersWork()
        {
            Bakery bakery = new Bakery();
            DateTime test = DateTime.Now;
            bakery.HireApprentice(test);
            test = test.AddDays(7);
            bakery.UpgradeApprentice(test);
            Assert.AreEqual("Baker", bakery.listOfBakers[0].WorkTitle);
        }

        [Test]
        public void TestIfOrderCompleteCheckerWorks()
        {
            Bakery bakery = new Bakery();
            DateTime test = DateTime.Now;
            Payment payments = new Payment();
            Order order = new Order(test, new Baker(test), new Customer());
            bakery.listOfOrders.Add(order);
            test = test.AddDays(1);
            //passes if string isn't empty
            Assert.AreNotEqual("", bakery.CheckIfOrderIsComplete(test, payments));
        }

        [Test]
        public void CheckIfAcceptingPaymentWorks()
        {
            Payment payment = new Payment();
            Assert.AreEqual(5000, payment.AcceptPayment(4000, 1000));
        }

        [Test]
        public void CheckThatCustomersGetAName()
        {
            Customer c = new Customer();
            Assert.AreNotEqual(null, c.Name);
        }
        [Test]
        public void CheckThatWorkersGetAName()
        {
            DateTime temp = DateTime.Now;
            BakerApprentice apprentice = new BakerApprentice(temp);
            Baker baker = new Baker(temp);
            Assert.AreNotEqual(null, apprentice.Name);
            Assert.AreNotEqual(null, baker.Name);
        }

        [Test]
        public void CheckThatSalaryIsCalculatedCorreclty()
        {

            DateTime temp = DateTime.Now;
            BakerApprentice apprentice = new BakerApprentice(temp);
            Baker baker = new Baker(temp);
            Assert.AreEqual(300, apprentice.CalculateSalary(1));
            Assert.AreEqual(1000, baker.CalculateSalary(2));
        }

        [Test]
        public void TestThatGenerateOrderDoesNotGenerateEmptyOrder()
        {
            DateTime test = DateTime.Now;
            Order order = new Order(test, new Baker(test), new Customer());
            Assert.AreNotEqual(0, order.GenerateOrder().Count);
        }

    }
}