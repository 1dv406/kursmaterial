using System.ComponentModel.DataAnnotations;

namespace GeekCustomer.Model
{
    /// <summary>
    /// Klass för hantering av kunder.
    /// </summary>
    public class Customer
    {
        // Egenskapernas namn och typ ges av tabellen
        // Customer i databasen.

        public int CustomerId { get; set; }

        [Required(ErrorMessage="Ett namn måste anges.")]
        [StringLength(30, ErrorMessage = "Namnet kan bestå av som mest 30 tecken.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "En adress måste anges.")]
        [StringLength(30, ErrorMessage = "Adressen kan bestå av som mest 30 tecken.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Ett postnummer måste anges.")]
        [RegularExpression(@"^[1-9]\d{2} ?\d{2}", ErrorMessage = "Postnumret verkar inte vara korrekt.")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "En ort måste anges.")]
        [StringLength(30, ErrorMessage = "Orten kan bestå av som mest 30 tecken.")]
        public string City { get; set; }
    }
}