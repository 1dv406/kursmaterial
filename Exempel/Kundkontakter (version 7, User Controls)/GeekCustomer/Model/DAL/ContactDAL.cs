using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GeekCustomer.Model.DAL
{
    public class ContactDAL : DALBase
    {
        /// <summary>
        /// Klass för CRUD-funktionalitet mot tabellen Contact.
        /// </summary>
        /// <returns>Lista med referenser till Contact-objekt.</returns>
        public List<Contact> GetContactByCustomerId(int customerId)
        {
            // Skapar ett anslutningsobjekt.
            using (var conn = CreateConnection())
            {
                try
                {
                    // Skapar och initierar ett SqlCommand-objekt som används till att 
                    // exekveras specifierad lagrad procedur.
                    var cmd = new SqlCommand("app.uspGetContactByCustomerId", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till den paramter den lagrade proceduren kräver. Använder här det MINDRE effektiva 
                    // sätttet att göra det på - enkelt, men ASP.NET behöver "jobba" rätt mycket.
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);

                    // Skapar det List-objekt som initialt har plats för 10 referenser till Contact-objekt.
                    List<Contact> contacts = new List<Contact>(10);

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
                        var contactIdIndex = reader.GetOrdinal("ContactId");
                        var contactTypeIdIndex = reader.GetOrdinal("ContactTypeId");
                        var valueIndex = reader.GetOrdinal("Value");

                        // Så länge som det finns poster att läsa returnerar Read true. Finns det inte fler 
                        // poster returnerar Read false.
                        while (reader.Read())
                        {
                            // Hämtar ut datat för en post. Använder GetXxx-metoder - vilken beror av typen av data.
                            // Du måste känna till SQL-satsen för att kunna välja rätt GetXxx-metod.
                            contacts.Add(new Contact
                            {
                                CustomerId = reader.GetInt32(customerIdIndex),
                                ContactId = reader.GetInt32(contactIdIndex),
                                ContactTypeId = reader.GetInt32(contactTypeIdIndex),
                                Value = reader.GetString(valueIndex)
                            });
                        }
                    }

                    // Sätter kapaciteten till antalet element i List-objektet, d.v.s. avallokerar minne
                    // som inte används.
                    contacts.TrimExcess();

                    // Returnerar referensen till List-objektet med referenser med Contact-objekt.
                    return contacts;
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException(GenericErrorMessage);
                }
            }
        }

        /// <summary>
        /// Hämtar en kontaktuppgift.
        /// </summary>
        /// <param name="customerId">En kontaktuppgifts nummer.</param>
        /// <returns>Ett Contact-objekt med en kontaktuppgifter.</returns>
        public Contact GetContactById(int contactId)
        {
            // Skapar ett anslutningsobjekt.
            using (var conn = CreateConnection())
            {
                try
                {
                    // Skapar och initierar ett SqlCommand-objekt som används till att 
                    // exekveras specifierad lagrad procedur.
                    var cmd = new SqlCommand("app.uspGetContact", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till den paramter den lagrade proceduren kräver. Använder här det MINDRE effektiva 
                    // sätttet att göra det på - enkelt, men ASP.NET behöver "jobba" rätt mycket.
                    cmd.Parameters.AddWithValue("@ContactId", contactId);

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // Den lagrade proceduren innehåller en SELECT-sats som kan returner en post varför
                    // ett SqlDataReader-objekt måste ta hand om posten. Metoden ExecuteReader skapar ett
                    // SqlDataReader-objekt och returnerar en referens till objektet.
                    using (var reader = cmd.ExecuteReader())
                    {
                        // Om det finns en post att läsa returnerar Read true. Finns ingen post returnerar
                        // Read false.
                        if (reader.Read())
                        {
                            // Tar reda på vilket index de olika kolumnerna har. Genom att använda 
                            // GetOrdinal behöver du inte känna till i vilken ordning de olika 
                            // kolumnerna kommer, bara vad de heter.
                            var customerIdIndex = reader.GetOrdinal("CustomerId");
                            var contactIdIndex = reader.GetOrdinal("ContactId");
                            var contactTypeIdIndex = reader.GetOrdinal("ContactTypeId");
                            var valueIndex = reader.GetOrdinal("Value");

                            // Returnerar referensen till de skapade Contact-objektet.
                            return new Contact
                            {
                                CustomerId = reader.GetInt32(customerIdIndex),
                                ContactId = reader.GetInt32(contactIdIndex),
                                ContactTypeId = reader.GetInt32(contactTypeIdIndex),
                                Value = reader.GetString(valueIndex)
                            };
                        }
                    }

                    // Istället för att returnera null kan du välja att kasta ett undatag om du 
                    // inte får "träff" på en kontaktuppgift. I denna applikation väljer jag att *inte* betrakta 
                    // det som ett fel om det inte går att hitta en kontaktuppgift. Vad du väljer är en smaksak...
                    return null;
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException(GenericErrorMessage);
                }
            }
        }

        /// <summary>
        /// Skapar en ny post i tabellen Contact.
        /// </summary>
        /// <param name="customer">Kontaktuppgift som ska läggas till.</param>
        public void InsertContact(Contact contact)
        {
            // Skapar ett anslutningsobjekt.
            using (var conn = CreateConnection())
            {
                try
                {
                    // Skapar och initierar ett SqlCommand-objekt som används till att 
                    // exekveras specifierad lagrad procedur.
                    var cmd = new SqlCommand("app.uspInsertContact", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till de paramterar den lagrade proceduren kräver. Använder här det effektiva sätttet att
                    // göra det på - något "svårare" men ASP.NET behöver inte "jobba" så mycket.
                    cmd.Parameters.Add("@CustomerId", SqlDbType.Int, 4).Value = contact.CustomerId;
                    cmd.Parameters.Add("@ContactTypeId", SqlDbType.Int, 4).Value = contact.ContactTypeId;
                    cmd.Parameters.Add("@Value", SqlDbType.NVarChar, 50).Value = contact.Value;

                    // Den här parametern är lite speciell. Den skickar inte något data till den lagrade proceduren,
                    // utan hämtar data från den. (Fungerar ungerfär som ref- och out-prameterar i C#.) Värdet 
                    // parametern kommer att ha EFTER att den lagrade proceduren exekverats är primärnycklens värde
                    // den nya posten blivit tilldelad av databasen.
                    cmd.Parameters.Add("@ContactId", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // Den lagrade proceduren innehåller en INSERT-sats och returnerar inga poster varför metoden 
                    // ExecuteNonQuery används för att exekvera den lagrade proceduren.
                    cmd.ExecuteNonQuery();

                    // Hämtar primärnyckelns värde för den nya posten och tilldelar Customer-objektet värdet.
                    contact.CustomerId = (int)cmd.Parameters["@ContactId"].Value;
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException(GenericErrorMessage);
                }
            }
        }

        /// <summary>
        /// Uppdaterar en kunds kontaktuppgifter i tabellen Contact.
        /// </summary>
        /// <param name="customer">KOntaktuppgift som ska uppdateras.</param>
        public void UpdateContact(Contact contact)
        {
            // Skapar ett anslutningsobjekt.
            using (var conn = CreateConnection())
            {
                try
                {
                    // Skapar och initierar ett SqlCommand-objekt som används till att 
                    // exekveras specifierad lagrad procedur.
                    var cmd = new SqlCommand("app.uspUpdateContact", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till de paramterar den lagrade proceduren kräver. Använder här det effektiva sätttet att
                    // göra det på - något "svårare" men ASP.NET behöver inte "jobba" så mycket.
                    cmd.Parameters.Add("@ContactId", SqlDbType.Int, 4).Value = contact.ContactId;
                    cmd.Parameters.Add("@CustomerId", SqlDbType.Int, 4).Value = contact.CustomerId;
                    cmd.Parameters.Add("@ContactTypeId", SqlDbType.Int, 4).Value = contact.ContactTypeId;
                    cmd.Parameters.Add("@Value", SqlDbType.VarChar, 50).Value = contact.Value;

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // Den lagrade proceduren innehåller en UPDATE-sats och returnerar inga poster varför metoden 
                    // ExecuteNonQuery används för att exekvera den lagrade proceduren.
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException(GenericErrorMessage);
                }
            }
        }

        /// <summary>
        /// Tar bort en kontaktuppgift.
        /// </summary>
        /// <param name="customerId">Kontaktuppgifts nummer.</param>
        public void DeleteContact(int contactId)
        {
            // Skapar ett anslutningsobjekt.
            using (var conn = CreateConnection())
            {
                try
                {
                    // Skapar och initierar ett SqlCommand-objekt som används till att 
                    // exekveras specifierad lagrad procedur.
                    var cmd = new SqlCommand("app.uspDeleteContact", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till de paramterar den lagrade proceduren kräver. Använder här det effektiva sätttet att
                    // göra det på - något "svårare" men ASP.NET behöver inte "jobba" så mycket.
                    cmd.Parameters.Add("@ContactId", SqlDbType.Int, 4).Value = contactId;

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // Den lagrade proceduren innehåller en DELETE-sats och returnerar inga poster varför metoden 
                    // ExecuteNonQuery används för att exekvera den lagrade proceduren.
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException(GenericErrorMessage);
                }
            }
        }
    }
}