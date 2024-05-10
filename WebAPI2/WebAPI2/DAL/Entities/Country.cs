using System.ComponentModel.DataAnnotations;

namespace WebAPI2.DAL.Entities
{
    public class Country : AuditBase
    {
        [MaxLength(50, ErrorMessage = "El campo {0} es obligatorio")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Pais")]
        public string Name { get; set; }

    }
}
