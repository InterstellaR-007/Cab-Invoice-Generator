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

        [Test]
        public void GivenMultipleRides_WhenPassed_ShouldReturnInvoiceSummary()
        {
            invoiceGenerator = new CabInvoiceGenerator.InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);

            InvoiceSummary expected_Summary = new InvoiceSummary{ total_Fare = 30, total_Rides = 2, avg_Fare = 15 };
            Assert.That(expected_Summary, Is.EqualTo(summary));
        }

        [Test]
        public void GivenUserID_WhenPassed_ShouldReturnInvoice()
        {
            invoiceGenerator = new CabInvoiceGenerator.InvoiceGenerator(RideType.NORMAL);
            RideRepository rideRepository = new RideRepository();
            rideRepository.AddRide("101", new Ride[] { new Ride(2.0, 5), new Ride(0.1, 1) });
            rideRepository.AddRide("102", new Ride[] { new Ride(2.0, 7), new Ride(0.1, 6) });
            rideRepository.AddRide("103", new Ride[] { new Ride(2.0, 2), new Ride(0.1, 4) });

            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            string given_UserID = "102";
            
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rideRepository.GetRides(given_UserID));

            InvoiceSummary expected_Summary = new InvoiceSummary { total_Fare = 34, total_Rides = 2, avg_Fare = 17 };
            Assert.That(expected_Summary, Is.EqualTo(summary));
        }

    }
}