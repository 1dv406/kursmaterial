using System.Collections.Generic;
using GeekCustomer.Model.DAL;

namespace GeekCustomer.Model
{
    /// <summary>
    /// Klassen tillhandahåller metoder presentationslogiklagret
    /// anropar för att hantera data. Främst innehåller klassen
    /// metoder som använder sig av klasser i dataåtkomstlagret.
    /// </summary>
    public class Service
    {
        #region Customer (C)R(UD)-metoder

        private CustomerDAL _customerDAL;

        private CustomerDAL CustomerDAL
        {
            get { return _customerDAL ?? (_customerDAL = new CustomerDAL()); }
        }

        /// <summary>
        /// Hämtar alla kunder som finns lagrade i databasen.
        /// </summary>
        /// <returns>Samling med referenser till Customer-objekt innehållande kunduppgifter.</returns>
        public IEnumerable<Customer> GetCustomers()
        {
            return CustomerDAL.GetCustomers();
        }

        #endregion
    }
}