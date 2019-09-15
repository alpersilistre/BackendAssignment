using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClayBackendCase.API.Core.Entities
{
    [Table("Companies")]
    public class Company : BaseEntity
    {
        [Required]
        [StringLength(200, ErrorMessage = "Company Name can't be longer than 200 characters")]
        public string Name { get; set; }

        public IReadOnlyCollection<User> Users { get; set; }
    }
}
