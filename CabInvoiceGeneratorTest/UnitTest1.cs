using CabInvoiceGenerator;
using NUnit.Framework;

namespace CabInvoiceGeneratorTest
{
    
    public class Tests
    {
        InvoiceGenerator invoiceGenerator = null;
        /// <summary>
        /// Setups this instance.
        /// </summary>
        [SetUp]
        public void Setup()
        {

        }

        /// <summary>
        /// Givens the distance and time when passed shoul retrun fare.
        /// </summary>
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

        /// <summary>
        /// Givens the multiple rides when passed should return aggregate total.
        /// </summary>
        [Test]
        public void GivenMultipleRides_WhenPassed_ShouldReturnAggregateTotal()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            double total_Fare = summary.total_Fare;
            double expected_Total_Fare = 30;
            Assert.AreEqual(expected_Total_Fare, total_Fare);
        }

        /// <summary>
        /// Givens the multiple rides when passed should return invoice summary.
        /// </summary>
        [Test]
        public void GivenMultipleRides_WhenPassed_ShouldReturnInvoiceSummary()
        {
            invoiceGenerator = new CabInvoiceGenerator.InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);

            InvoiceSummary expected_Summary = new InvoiceSummary{ total_Fare = 30, total_Rides = 2, avg_Fare = 15 };
            Assert.That(expected_Summary, Is.EqualTo(summary));
        }

        /// <summary>
        /// Givens the user identifier when passed should return invoice.
        /// </summary>
        [Test]
        public void GivenUserID_WhenPassed_ShouldReturnInvoice()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            RideRepository rideRepository = new RideRepository();
            rideRepository.AddRide("101", new Ride[] { new Ride(2.0, 5), new Ride(0.1, 1) });
            rideRepository.AddRide("102", new Ride[] { new Ride(2.0, 7), new Ride(0.1, 6) });
            rideRepository.AddRide("103", new Ride[] { new Ride(2.0, 2), new Ride(0.1, 4) });

            string given_UserID = "102";
            
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rideRepository.GetRides(given_UserID));

            InvoiceSummary expected_Summary = new InvoiceSummary { total_Fare = 34, total_Rides = 2, avg_Fare = 17 };
            Assert.That(expected_Summary, Is.EqualTo(summary));
        }


        [Test]
        public void GivenRideTypePREMIUMandNormal_WhenPassed_ShouldReturnInvoice()
        {

            InvoiceGenerator invoiceGenerator_Normal = new InvoiceGenerator(RideType.NORMAL);
            InvoiceGenerator invoiceGenerator_Premium = new InvoiceGenerator(RideType.PREMIUM);

            double distance_Normal = 2.0;
            int time_Normal = 5;
            double distance_Premium = 2.0;
            int time_Premium = 5;

            double fare_Normal = invoiceGenerator_Normal.CalculateFare(distance_Normal, time_Normal);
            double fare_Premium = invoiceGenerator_Premium.CalculateFare(distance_Premium, time_Premium);

            double expected_Fare_Normal = 25;
            double expected_Fare_Premium = 40;

            Assert.AreEqual(expected_Fare_Normal, fare_Normal);
            Assert.AreEqual(expected_Fare_Premium, fare_Premium);




        }

    }
}