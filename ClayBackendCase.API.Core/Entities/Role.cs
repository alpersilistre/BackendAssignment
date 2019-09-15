using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClayBackendCase.API.Core.Entities
{
    [Table("Roles")]
    public class Role : BaseEntity
    {
        [Required]
        [StringLength(50, ErrorMessage = "Name can't be longer than 50 characters")]
        public string Name { get; set; }

        public Role()
        {
        }

        public Role(string name)
        {
            Name = name;
        }
    }
}
