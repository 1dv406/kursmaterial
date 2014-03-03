using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GeekCustomer.Model.DAL
{
    /// <summary>
    /// Klass för CRUD-funktionalitet mot tabellen Contact.
    /// </summary>
    public class CustomerDAL : DALBase
    {
        /// <summary>
        /// Hämtar alla kunder i databasen.
        /// </summary>
        /// <returns>Samling med referenser till Customer-objekt.</returns>
        public IEnumerable<Customer> GetCustomers()
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (var conn = CreateConnection())
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

        /// <summary>
        /// Hämtar en kunds kunduppgifter.
        /// </summary>
        /// <param name="customerId">En kunds kundnummer.</param>
        /// <returns>Ett Customer-objekt med en kunds kunduppgifter.</returns>
        public Customer GetCustomerById(int customerId)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar och initierar ett SqlCommand-objekt som används till att 
                    // exekveras specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("app.uspGetCustomer", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till den paramter den lagrade proceduren kräver. Använder här det MINDRE effektiva 
                    // sätttet att göra det på - enkelt, men ASP.NET behöver "jobba" rätt mycket.
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // Den lagrade proceduren innehåller en SELECT-sats som kan returner en post varför
                    // ett SqlDataReader-objekt måste ta hand om posten. Metoden ExecuteReader skapar ett
                    // SqlDataReader-objekt och returnerar en referens till objektet.
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Om det finns en post att läsa returnerar Read true. Finns ingen post returnerar
                        // Read false.
                        if (reader.Read())
                        {
                            // Tar reda på vilket index de olika kolumnerna har. Genom att använda 
                            // GetOrdinal behöver du inte känna till i vilken ordning de olika 
                            // kolumnerna kommer, bara vad de heter.
                            int customerIdIndex = reader.GetOrdinal("CustomerId");
                            int nameIndex = reader.GetOrdinal("Name");
                            int addressIndex = reader.GetOrdinal("Address");
                            int postalCodeIndex = reader.GetOrdinal("PostalCode");
                            int cityIndex = reader.GetOrdinal("City");

                            // Returnerar referensen till de skapade Contact-objektet.
                            return new Customer
                            {
                                CustomerId = reader.GetInt32(customerIdIndex),
                                Name = reader.GetString(nameIndex),
                                Address = reader.GetString(addressIndex),
                                PostalCode = reader.GetString(postalCodeIndex),
                                City = reader.GetString(cityIndex)
                            };
                        }
                    }

                    // Istället för att returnera null kan du välja att kasta ett undatag om du 
                    // inte får "träff" på en kund. I denna applikation väljer jag att *inte* betrakta 
                    // det som ett fel i detta lager om det inte går att hitta en kund. Vad du väljer 
                    // är en smaksak...
                    return null;
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }

        /// <summary>
        /// Skapar en ny post i tabellen Customer.
        /// </summary>
        /// <param name="customer">Kunduppgifter som ska läggas till.</param>
        public void InsertCustomer(Customer customer)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar och initierar ett SqlCommand-objekt som används till att 
                    // exekveras specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("app.uspInsertCustomer", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till de paramterar den lagrade proceduren kräver. Använder här det effektiva sätttet att
                    // göra det på - något "svårare" men ASP.NET behöver inte "jobba" så mycket.
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 30).Value = customer.Name;
                    cmd.Parameters.Add("@Address", SqlDbType.VarChar, 30).Value = customer.Address;
                    cmd.Parameters.Add("@PostalCode", SqlDbType.VarChar, 6).Value = customer.PostalCode;
                    cmd.Parameters.Add("@City", SqlDbType.VarChar, 30).Value = customer.City;

                    // Den här parametern är lite speciell. Den skickar inte något data till den lagrade proceduren,
                    // utan hämtar data från den. (Fungerar ungerfär som ref- och out-prameterar i C#.) Värdet 
                    // parametern kommer att ha EFTER att den lagrade proceduren exekverats är primärnycklens värde
                    // den nya posten blivit tilldelad av databasen.
                    cmd.Parameters.Add("@CustomerId", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // Den lagrade proceduren innehåller en INSERT-sats och returnerar inga poster varför metoden 
                    // ExecuteNonQuery används för att exekvera den lagrade proceduren.
                    cmd.ExecuteNonQuery();

                    // Hämtar primärnyckelns värde för den nya posten och tilldelar Customer-objektet värdet.
                    customer.CustomerId = (int)cmd.Parameters["@CustomerId"].Value;
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }

        /// <summary>
        /// Uppdaterar en kunds kunduppgifter i tabellen Customer.
        /// </summary>
        /// <param name="customer">Kunduppgifter som ska uppdateras.</param>
        public void UpdateCustomer(Customer customer)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar och initierar ett SqlCommand-objekt som används till att 
                    // exekveras specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("app.uspUpdateCustomer", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till de paramterar den lagrade proceduren kräver. Använder här det effektiva sätttet att
                    // göra det på - något "svårare" men ASP.NET behöver inte "jobba" så mycket.
                    cmd.Parameters.Add("@CustomerId", SqlDbType.Int, 4).Value = customer.CustomerId;
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 30).Value = customer.Name;
                    cmd.Parameters.Add("@Address", SqlDbType.VarChar, 30).Value = customer.Address;
                    cmd.Parameters.Add("@PostalCode", SqlDbType.VarChar, 6).Value = customer.PostalCode;
                    cmd.Parameters.Add("@City", SqlDbType.VarChar, 30).Value = customer.City;

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // Den lagrade proceduren innehåller en UPDATE-sats och returnerar inga poster varför metoden 
                    // ExecuteNonQuery används för att exekvera den lagrade proceduren.
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }

        /// <summary>
        /// Tar bort en kunds kunduppgifter.
        /// </summary>
        /// <param name="customerId">Kunds kundnummer.</param>
        public void DeleteCustomer(int customerId)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar och initierar ett SqlCommand-objekt som används till att 
                    // exekveras specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("app.uspDeleteCustomer", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till den paramter den lagrade proceduren kräver. Använder här det effektiva sätttet att
                    // göra det på - något "svårare" men ASP.NET behöver inte "jobba" så mycket.
                    cmd.Parameters.Add("@CustomerId", SqlDbType.Int, 4).Value = customerId;

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // Den lagrade proceduren innehåller en DELETE-sats och returnerar inga poster varför metoden 
                    // ExecuteNonQuery används för att exekvera den lagrade proceduren.
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
    }
}