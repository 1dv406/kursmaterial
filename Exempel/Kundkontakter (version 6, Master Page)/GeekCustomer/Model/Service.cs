using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        #region Customer

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
            //var validationContext = new ValidationContext(customer);
            //var validationResults = new List<ValidationResult>();
            //if (!Validator.TryValidateObject(customer, validationContext, validationResults, true))
            //{
            //    // Uppfyller inte objektet affärsreglerna kastas ett undantag med
            //    // ett allmänt felmeddelande samt en referens till samlingen med
            //    // resultat av valideringen.
            //    var ex = new ValidationException("Objektet klarade inte valideringen.");
            //    ex.Data.Add("ValidationResults", validationResults);
            //    throw ex;
            //}

            // Uppfyller inte objektet affärsreglerna...
            ICollection<ValidationResult> validationResults;
            if (!customer.Validate(out validationResults)) // Använder "extension method" för valideringen!
            {                                              // Klassen finns under App_Infrastructure.
                // ...kastas ett undantag med ett allmänt felmeddelande samt en referens 
                // till samlingen med resultat av valideringen.
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }

            // Customer-objektet sparas antingen genom att en ny post 
            // skapas eller genom att en befintlig post uppdateras.
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