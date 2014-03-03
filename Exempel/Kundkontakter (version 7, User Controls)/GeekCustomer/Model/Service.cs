using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using GeekCustomer.Model.DAL;

namespace GeekCustomer.Model
{
    /// <summary>
    /// Klassen tillhandahåller metoder presentationslogiklagret
    /// anropar för att hantera data. Främst innehåller klassen
    /// metoder som använder sig av klasser i dataåtkomstlagret.
    /// 
    /// Klassens medlemmar kan anses tillhöra "Service Layer" samt
    /// "Cache Layer".
    /// </summary>
    public class Service
    {
        #region Fält

        private ContactDAL _contactDAL;
        private ContactTypeDAL _contactTypeDAL;
        private CustomerDAL _customerDAL;

        #endregion

        #region Egenskaper

        private ContactDAL ContactDAL
        {
            // Ett ContactDAL-objekt skapas först då det behövs för första 
            // gången (lazy initialization, http://en.wikipedia.org/wiki/Lazy_initialization).
            get { return _contactDAL ?? (_contactDAL = new ContactDAL()); }
        }

        private ContactTypeDAL ContactTypeDAL
        {
            get { return _contactTypeDAL ?? (_contactTypeDAL = new ContactTypeDAL()); }
        }

        private CustomerDAL CustomerDAL
        {
            get { return _customerDAL ?? (_customerDAL = new CustomerDAL()); }
        }

        #endregion

        #region Contact CRUD-metoder
        // http://en.wikipedia.org/wiki/Create,_read,_update_and_delete

        /// <summary>
        /// Tar bort specifierad kontaktuppgift ur databasen.
        /// </summary>
        /// <param name="contact">Kontaktuppgift som ska tas bort.</param>
        public void DeleteContact(int contactId)
        {
            ContactDAL.DeleteContact(contactId);
        }

        /// <summary>
        /// Hämtar kontaktuppgift med ett specifikt nummer från databasen.
        /// </summary>
        /// <param name="contactId">Kontaktuppgiftens nummer.</param>
        /// <returns>Ett Contact-objekt innehållande kontaktuppgifter.</returns>
        public Contact GetContact(int contactId)
        {
            return ContactDAL.GetContactById(contactId);
        }

        /// <summary>
        /// Hämtar en kunds kontaktuppgifter som finns lagrade i databasen.
        /// </summary>
        /// <returns>Lista med referenser till Contact-objekt innehållande kontaktuppgifter.</returns>
        public List<Contact> GetContactsByCustomerId(int customerId)
        {
            return ContactDAL.GetContactByCustomerId(customerId);
        }

        /// <summary>
        /// Spara en kontaktuppgift i databasen.
        /// </summary>
        /// <param name="customer">KOntaktuppgifter som ska sparas.</param>
        public void SaveContact(Contact contact)
        {
            // Uppfyller inte objektet affärsreglerna...
            ICollection<ValidationResult> validationResults;
            if (!contact.Validate(out validationResults)) // Använder "extension method" för valideringen!
            {                                              // Klassen finns under App_Infrastructure.
                // ...kastas ett undantag med ett allmänt felmeddelande samt en referens 
                // till samlingen med resultat av valideringen.
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }

            // Contact-objektet sparas antingen genom att en ny post 
            // skapas eller genom att en befintlig post uppdateras.
            if (contact.ContactId == 0) // Ny post om ContactId är 0!
            {
                ContactDAL.InsertContact(contact);
            }
            else
            {
                ContactDAL.UpdateContact(contact);
            }
        }

        #endregion

        #region ContactType (C)R(UD)-metoder

        /// <summary>
        /// Hämtar alla kontakttyper.
        /// </summary>
        /// <returns>Ett List-objekt innehållande referenser till ContactType-objekt.</returns>
        public IEnumerable<ContactType> GetContactTypes(bool refresh = false)
        {
            // Försöker hämta lista med kontakttyper från cachen.
            var contactTypes = HttpContext.Current.Cache["ContactTypes"] as IEnumerable<ContactType>;

            // Om det inte finns det en lista med kontakttyper...
            if (contactTypes == null || refresh)
            {
                // ...hämtar då lista med kontakttyper...
                contactTypes = ContactTypeDAL.GetContactTypes();

                // ...och cachar dessa. List-objektet, inklusive alla ContactType-objekt, kommer att cachas 
                // under 10 minuter, varefter de automatiskt avallokeras från webbserverns primärminne.
                HttpContext.Current.Cache.Insert("ContactTypes", contactTypes, null, DateTime.Now.AddMinutes(10), TimeSpan.Zero);
            }

            // Returnerar listan med kontakttyper.
            return contactTypes;
        }

        #endregion

        #region Customer

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