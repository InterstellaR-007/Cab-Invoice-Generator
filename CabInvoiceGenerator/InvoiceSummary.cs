using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class InvoiceSummary
    {
        public int total_Rides;
        public double total_Fare;
        public double avg_Fare;

        public InvoiceSummary(int total_Rides, double total_Fare)
        {
            this.total_Fare = total_Fare;
            this.total_Rides = total_Rides;
            this.avg_Fare = this.total_Fare / this.total_Rides;
        }

    }
}
