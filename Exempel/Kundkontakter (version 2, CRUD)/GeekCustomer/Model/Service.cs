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
            // Ett CustomerDAL-objekt skapas först då det behövs för första 
            // gången (lazy initialization, http://en.wikipedia.org/wiki/Lazy_initialization).
            get { return _customerDAL ?? (_customerDAL = new CustomerDAL()); }
        }

        /// <summary>
        /// Tar bort specifierad kund ur databasen.
        /// </summary>
        /// <param name="customer">Kund som ska tas bort.</param>
        public void DeleteCustomer(int customerId)
        {
            CustomerDAL.DeleteCustomer(customerId);
        }

        /// <summary>
        /// Hämtar en kund med ett specifikt kundnummer från databasen.
        /// </summary>
        /// <param name="customerId">Kundens kundnummer.</param>
        /// <returns>Ett Customer-objekt innehållande kunduppgifter.</returns>
        public Customer GetCustomer(int customerId)
        {
            return CustomerDAL.GetCustomerById(customerId);
        }

        /// <summary>
        /// Hämtar alla kunder som finns lagrade i databasen.
        /// </summary>
        /// <returns>Lista med referenser till Customer-objekt innehållande kunduppgifter.</returns>
        public IEnumerable<Customer> GetCustomers()
        {
            return CustomerDAL.GetCustomers();
        }

        /// <summary>
        /// Spara en kunds kunduppgifter i databasen.
        /// </summary>
        /// <param name="customer">Kunduppgifter som ska sparas.</param>
        public void SaveCustomer(Customer customer)
        {
            // Customer-objektet sparas antingen genom att en ny post 
            // skapas eller genom att en befintlig post uppdateras.
            // ======================================================
            // OBS! HÄR SAKNAS VALIDERING I AFFÄRSLOGIKLAGRET!!!!!
            //      Se senare versioner av Kundkontakter för korrekt
            //      implementering.
            // ======================================================
            if (customer.CustomerId == 0) // Ny post om CustomerId är 0!
            {
                CustomerDAL.InsertCustomer(customer);
            }
            else
            {
                CustomerDAL.UpdateCustomer(customer);
            }
        }

        #endregion
    }
}