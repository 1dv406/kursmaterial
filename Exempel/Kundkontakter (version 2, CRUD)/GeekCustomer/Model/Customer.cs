using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeekCustomer.Model
{
    /// <summary>
    /// Klass för hantering av kunduppgifter.
    /// </summary>
    public class Customer
    {
        // Egenskapernas namn och typ ges av tabellen
        // Customer i databasen.
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
    }
}