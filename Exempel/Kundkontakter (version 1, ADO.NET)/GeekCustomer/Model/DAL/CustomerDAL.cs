using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace GeekCustomer.Model.DAL
{
    /// <summary>
    /// Klassen CustomerDAL.
    /// </summary>
    public class CustomerDAL
    {
        /// <summary>
        /// Hämtar alla kunder i databasen.
        /// </summary>
        /// <returns>Samling med referenser till Customer-objekt.</returns>
        public IEnumerable<Customer> GetCustomers()
        {
            // Hämtar anslutningssträngen från web.config.
            string connectionString = WebConfigurationManager.ConnectionStrings["GeekCustomerConnectionString"].ConnectionString;

            // Skapar och initierar ett anslutningsobjekt.
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    // Skapar det List-objekt som initialt har plats för 100 referenser till Customer-objekt.
                    var customers = new List<Customer>(100);

                    // Skapar och initierar ett SqlCommand-objekt som används till att 
                    // exekveras specifierad lagrad procedur.
                    var cmd = new SqlCommand("app.uspGetCustomers", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // Den lagrade proceduren innehåller en SELECT-sats som kan returnera flera poster varför
                    // ett SqlDataReader-objekt måste ta hand om alla poster. Metoden ExecuteReader skapar ett
                    // SqlDataReader-objekt och returnerar en referens till objektet.
                    using (var reader = cmd.ExecuteReader())
                    {
                        // Tar reda på vilket index de olika kolumnerna har. Det är mycket effektivare att göra detta
                        // en gång för alla innan while-loopen. Genom att använda GetOrdinal behöver du inte känna till
                        // i vilken ordning de olika kolumnerna kommer, bara vad de heter.
                        var customerIdIndex = reader.GetOrdinal("CustomerId");
                        var nameIndex = reader.GetOrdinal("Name");
                        var addressIndex = reader.GetOrdinal("Address");
                        var postalCodeIndex = reader.GetOrdinal("PostalCode");
                        var cityIndex = reader.GetOrdinal("City");

                        // Så länge som det finns poster att läsa returnerar Read true. Finns det inte fler 
                        // poster returnerar Read false.
                        while (reader.Read())
                        {
                            // Hämtar ut datat för en post. Använder GetXxx-metoder - vilken beror av typen av data.
                            // Du måste känna till SQL-satsen för att kunna välja rätt GetXxx-metod.
                            customers.Add(new Customer
                            {
                                CustomerId = reader.GetInt32(customerIdIndex),
                                Name = reader.GetString(nameIndex),
                                Address = reader.GetString(addressIndex),
                                PostalCode = reader.GetString(postalCodeIndex),
                                City = reader.GetString(cityIndex)
                            });
                        }
                    }

                    // Sätter kapaciteten till antalet element i List-objektet, d.v.s. avallokerar minne
                    // som inte används.
                    customers.TrimExcess();

                    // Returnerar referensen till List-objektet med referenser med Customer-objekt.
                    return customers;
                }
                catch
                {
                    throw new ApplicationException("An error occured while getting customers from the database.");
                }
            }

        }
    }
}