using System.ComponentModel.DataAnnotations;

namespace GeekCustomer.Model
{
    /// <summary>
    /// Klass för hantering av kontaktuppgifter.
    /// </summary>
    public class Contact
    {
        public int CustomerId { get; set; }
        public int ContactId { get; set; }
        public int ContactTypeId { get; set; }

        [Required(ErrorMessage = "Kontaktuppgift måste anges.")]
        [StringLength(50, ErrorMessage = "Kontaktuppgiften kan bestå av som mest 50 tecken.")]
        public string Value { get; set; }
    }
}