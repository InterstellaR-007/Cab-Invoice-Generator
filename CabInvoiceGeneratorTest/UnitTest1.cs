using CabInvoiceGenerator;
using NUnit.Framework;

namespace CabInvoiceGeneratorTest
{
    public class Tests
    {
        CabInvoiceGenerator.InvoiceGenerator invoiceGenerator = null;
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void GivenDistanceAndTime_WhenPassed_ShoulRetrunFare()
        {
            invoiceGenerator = new CabInvoiceGenerator.InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;

            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected_Fare = 25;
            Assert.AreEqual(expected_Fare,fare);
        }

        [Test]
        public void GivenMultipleRides_WhenPassed_ShouldReturnAggregateTotal()
        {
            invoiceGenerator = new CabInvoiceGenerator.InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            double total_Fare = summary.total_Fare;
            double expected_Total_Fare = 30;
            Assert.AreEqual(expected_Total_Fare, total_Fare);
        }

    }
}