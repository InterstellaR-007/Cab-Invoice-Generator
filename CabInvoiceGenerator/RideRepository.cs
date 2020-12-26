using System;
using System.Collections.Generic;

namespace CabInvoiceGenerator
{

    /// <summary>
    /// Ride Repository Class
    /// </summary>
    public class RideRepository
    {
        Dictionary<string, List<Ride>> userRides = null;

        public RideRepository()
        {
            this.userRides = new Dictionary<string, List<Ride>>();
        }

        /// <summary>
        /// Adds the ride.
        /// </summary>
        /// <param name="userID">The user identifier.</param>
        /// <param name="rides">The rides.</param>
        /// <exception cref="CabInvoiceException">Rides are null</exception>
        public void AddRide(string userID, Ride[] rides)
        {
            bool rideList = this.userRides.ContainsKey(userID);
            try
            {
                if(!rideList)
                {
                    List<Ride> list = new List<Ride>();
                    list.AddRange(rides);
                    this.userRides.Add(userID, list);
                }

            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Rides are null");

            }

        }

        /// <summary>
        /// Gets the rides.
        /// </summary>
        /// <param name="userID">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="CabInvoiceException">Invalid user id</exception>
        public Ride[] GetRides(string userID)
            {
            try
            {
                return this.userRides[userID].ToArray();
            }
            catch (Exception)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_USER_ID, "Invalid user id");
            }
            
        }

    }
}
