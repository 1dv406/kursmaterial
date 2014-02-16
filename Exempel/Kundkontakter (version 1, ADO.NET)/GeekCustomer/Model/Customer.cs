using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeekCustomer.Model
{
    /// <summary>
    /// Klassen Customer.
    /// </summary>
    public class Customer
    {
        #region Auto-implementerade egenskaper

        // Egenskapernas namn och typ ges av tabellen
        // Customer i databasen.
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }

        #endregion
    }
}