using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace GeekTallStory.Model.DAL
{
    /// <summary>
    /// Klassen används för att hantera datat, via lagrade procedurer, i tabellen TallStory.
    /// 
    /// OBS! Koden som följer är överkommenterad och tjänar inte som ett gott exempel på 
    ///      hur kod bör kommenteras.
    /// 
    /// </summary>
    public class TallStoryDAL
    {
        /// <summary>
        /// Metoden returner en samling med referenser till TallStory-objekt, där varje
        /// TallStory-objekt representerar en post i tabellen TallStory.
        /// </summary>
        public List<TallStory> GetTallStories()
        {
            try
            {
                // En samling för referenser till TallStory-objekt skapas.
                var tallStories = new List<TallStory>(100);

                // Hämtar anslutningssträngen från web.config.Anslutningssträngen används då... 
                string connString = WebConfigurationManager.ConnectionStrings["GeekTallStoryConnectionString"].ConnectionString;

                // ...anslutningsobjektet skapas. Efter att anslutningsobjektet skapats så kan...
                using (var conn = new SqlConnection(connString))
                {
                    // ...anslutningen öppnas. 
                    //(using ser till att anslutningen stängs automatiskt vad som än händer. Behöver alltså
                    // inte anropa Close.)
                    conn.Open();

                    // Ett kommandoobjekt, associerat med anslutningsobjektet, skapas och
                    // initieras att köra en lagrad procedur i databas.
                    var cmd = new SqlCommand("app.GetTallStories", conn);

                    // Den lagrade procedurer exekveras, och...
                    using (var reader = cmd.ExecuteReader())
                    {

                        // ...de olika fältens index tas reda på innan...
                        var tallStoryIdIndex = reader.GetOrdinal("TallStoryId");
                        var headerIndex = reader.GetOrdinal("Header");
                        var phraseIndex = reader.GetOrdinal("Phrase");

                        // ....en post åt gången hämtas.
                        while (reader.Read())
                        {
                            // Med en post som underlag skapas en skröna och den 
                            // läggs till samlingen med skrönor.
                            tallStories.Add(new TallStory
                            {
                                TallStoryId = reader.GetInt32(tallStoryIdIndex),
                                Header = reader.GetString(headerIndex),
                                Phrase = reader.GetString(phraseIndex)
                            });
                        }
                    }
                }

                // Sätter samlingens kapacitet till antalet använda element (antalet skrönor).
                tallStories.TrimExcess();

                // Returnerar referensen till samlingen med referenser till skrönor.
                return tallStories;
            }
            catch
            {
                // Kastas ett undantag ska inte felinformationen "läcka vidare" utan ett allmänt (ofarligt)
                // undantag kastas.
                throw new ApplicationException("Ett fel inträffade då skrönor hämtades från databasen.");
            }
        }
    }
}