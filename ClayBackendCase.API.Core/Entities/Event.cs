using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClayBackendCase.API.Core.Entities
{
    public class Event : BaseEntity
    {
        [Required]
        [StringLength(250)]
        public string Detail { get; set; }

        [Required]
        public Lock Lock { get; set; }

        [Required]
        public User User { get; set; }
    }
}
