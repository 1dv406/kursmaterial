using System.ComponentModel.DataAnnotations;

namespace GeekCustomer.Model
{
    /// <summary>
    /// Klass för hantering av kontakttyper.
    /// </summary>
    public class ContactType
    {
        public int ContactTypeId { get; set; }

        [Required(ErrorMessage = "Ett namn måste anges.")]
        [StringLength(50, ErrorMessage = "Namnet kan bestå av som mest 50 tecken.")]
        public string Name { get; set; }

        public byte SortOrder { get; set; }
    }
}