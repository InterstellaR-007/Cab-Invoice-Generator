﻿using System;

namespace CabInvoiceGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            InvoiceGenerator invoicegenerator = new InvoiceGenerator(RideType.NORMAL);
            double fare = invoicegenerator.CalculateFare(2.0, 5);
            Console.WriteLine($"Fare :{ fare}");
        }
    }
}
