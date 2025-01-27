using System.ComponentModel.DataAnnotations;

namespace WebAPI.DAL.Entities
{
    public class AuditBase
    {
        [Key]
        [Required]
        public virtual Guid Id {  get; set; }
        public virtual DateTime? CreatedDate { get; set; } //para guardar todo registro nuevo con su date
        public virtual DateTime? ModifiedDate { get; set; } //para guardar todo registro que se modificó con su date
    }
}
