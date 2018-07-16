using Evolent.BusinessEntities.CustomValidation;
using System.ComponentModel.DataAnnotations;

namespace Evolent.BusinessEntities
{
    public class ContactEntity
    {
        public int ID { get; set; }

        [StringLength(20), Required]
        [RegularExpression("^[a-zA-Z]{1,20}$", ErrorMessage = "Enter only Alphabet for First Name")]
        public string FirstName { get; set; }

        [StringLength(20), Required]
        [RegularExpression("^[a-zA-Z]{1,20}$", ErrorMessage = "Enter only Alphabet for Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Address { get; set; }

        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]   
        public string Email { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$")]
        public string PhoneNumber { get; set; }

        [ValidEnumValue]
        [Required(ErrorMessage = "Staus must be Active/Inactive")]
        public enumStatus Status { get; set; } 
    }

    public enum enumStatus
    {
        Active,
        Inactive
    }
}
