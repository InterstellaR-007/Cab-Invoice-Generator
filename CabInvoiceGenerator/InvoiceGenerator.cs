using System;

namespace CabInvoiceGenerator
{
    public class InvoiceGenerator
    {
        RideType rideType;
        private RideRepository rideRepository;

        private readonly double MINIMUM_COST_PER_KM;
        private readonly int COST_PER_TIME;
        private readonly double MINIMUM_FARE;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceGenerator"/> class.
        /// </summary>
        /// <param name="rideType">Type of the ride.</param>
        /// <exception cref="CabInvoiceException">Invalid Ride type</exception>
        public InvoiceGenerator(RideType rideType)
        {
            this.rideType = rideType;
            this.rideRepository = new RideRepository();
            try
            {
                if (rideType.Equals(RideType.PREMIUM))
                {
                    this.MINIMUM_COST_PER_KM = 15;
                    this.COST_PER_TIME = 2;
                    this.MINIMUM_FARE = 20;
                }
                else if (rideType.Equals(RideType.NORMAL))
                {
                    this.MINIMUM_COST_PER_KM = 10;
                    this.COST_PER_TIME = 1;
                    this.MINIMUM_FARE = 5;
                }
            }
            catch(CabInvoiceException e)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid Ride type");
            }


        }

        /// <summary>
        /// Calculates the fare.
        /// </summary>
        /// <param name="distance">The distance.</param>
        /// <param name="time">The time.</param>
        /// <returns></returns>
        /// <exception cref="CabInvoiceException">
        /// Null rides
        /// or
        /// Invalid distance
        /// or
        /// Invalid Times
        /// </exception>
        public double CalculateFare(double distance, int time)
        {
            double total_fare = 0;
            try
            {
                total_fare = distance * MINIMUM_COST_PER_KM  + time*COST_PER_TIME;
            }
            catch (CabInvoiceException)
            {
                if (rideType.Equals(null))
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Null rides");
                if(distance==0)
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_DISTANCE, "Invalid distance ");
                if (time < 0)
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_TIME, "Invalid Times");
            }
            return Math.Max(total_fare, MINIMUM_FARE);
        }

        /// <summary>
        /// Calculates the fare.
        /// </summary>
        /// <param name="rides">The rides.</param>
        /// <returns></returns>
        /// <exception cref="CabInvoiceException">Rides are null</exception>
        public InvoiceSummary CalculateFare(Ride[] rides)
        {
            double total_Fare = 0;
            try
            {
                foreach( var ride in rides)
                {
                    total_Fare += this.CalculateFare(ride.distance, ride.time);
                }

            }
            catch (CabInvoiceException)
            {
                if(rides == null)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Rides are null");
                }

            }
            return new InvoiceSummary(rides.Length, total_Fare);
        }
    }
}
