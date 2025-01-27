using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace WebAPI.DAL.Entities
{
    public class Barber : AuditBase
    {
        [Display (Name = "Barber Name")]
        [MaxLength(20, ErrorMessage = "Field {0} can´t have more than 20 characters")]
        [Required(ErrorMessage = "Field {0} can't be empty")]
        public string Firstname { get; set; }

        [Display(Name = "Barber Lastname")]
        [MaxLength(20, ErrorMessage = "Field {0} can´t have more than 20 characters")]
        [Required(ErrorMessage = "Field {0} can't be empty")]
        public string LastName { get; set; }

        [Display(Name = "Barber Phone")]
        [MaxLength(10, ErrorMessage = "Field {0} can´t have more than 10 characters")]
        [Required(ErrorMessage = "Field {0} can't be empty")]
        public string PhoneNumber{ get; set; }
    }
}
