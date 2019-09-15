using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClayBackendCase.API.Core.Entities
{
    [Table("Locks")]
    public class Lock : BaseEntity
    {
        [Required]
        [StringLength(200, ErrorMessage = "Lock Name can't be longer than 200 characters")]
        public string Name { get; set; }

        [Required]
        public bool IsLocked { get; set; } = false;

        [Required]
        public Company Company { get; set; }

        public IReadOnlyCollection<Event> Events { get; set; }
    }
}
