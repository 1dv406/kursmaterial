using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Resources;

namespace GeekCustomer.Model.DAL
{
    /// <summary>
    /// Abstrakt basklass för dataåtkomstklasser.
    /// </summary>
    public abstract class DALBase
    {
        #region Fält

        /// <summary>
        /// Sträng med information som används för att ansluta till "SQL Server"-databasen.
        /// (Ett statiskt fält tillhör klassen och delas av alla instanser av klassen).
        /// </summary>
        private static string _connectionString;

        /// <summary>
        /// Sträng med allmänt felmeddelande.
        /// </summary>
        protected static readonly string GenericErrorMessage = Strings.Generic_DAL_Error_Message;

        #endregion

        #region Konstruktorer

        /// <summary>
        /// Initierar statiskt data. (Konstruktorn anropas automatiskt innan första instansen skapas
        /// eller innan någon statisk medlem används.)
        /// </summary>
        static DALBase()
        {
            // Hämtar anslutningssträngen från web.config.
            _connectionString =
                WebConfigurationManager.ConnectionStrings["GeekCustomerConnectionString"].ConnectionString;
        }

        #endregion

        #region Hjälpmetoder

        /// <summary>
        /// Skapar och initierar ett anslutningsobjekt.
        /// </summary>
        /// <returns>En referens till ett SqlConnection-objekt.</returns>
        protected SqlConnection CreateConnection()
        {
            // Skapar och initierar ett anslutningsobjekt.
            return new SqlConnection(_connectionString);
        }

        #endregion
    }
}