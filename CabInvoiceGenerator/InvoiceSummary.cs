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

        public InvoiceSummary() { }


        public InvoiceSummary(int total_Rides, double total_Fare)
        {
            this.total_Fare = total_Fare;
            this.total_Rides = total_Rides;
            this.avg_Fare = this.total_Fare / this.total_Rides;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is InvoiceSummary))
                return false;

            InvoiceSummary input_Object = (InvoiceSummary)obj;
            return this.total_Rides == input_Object.total_Rides && this.avg_Fare == input_Object.avg_Fare && this.total_Fare == input_Object.total_Fare;

            
        }

    }
}
