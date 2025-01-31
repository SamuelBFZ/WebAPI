using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAPI.DAL.Entities
{
    public class AuditBase
    {
        [Key]
        [JsonIgnore]
        public virtual Guid Id {  get; set; } = Guid.Empty;
        [JsonIgnore]
        public virtual DateTime? CreatedDate { get; set; } //para guardar todo registro nuevo con su date
        [JsonIgnore]
        public virtual DateTime? ModifiedDate { get; set; } //para guardar todo registro que se modificó con su date
    }
}
