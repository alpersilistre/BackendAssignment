using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClayBackendCase.API.Core.Entities
{
    [Table("Users")]
    public class User : BaseEntity
    {
        [Required]
        [StringLength(50, ErrorMessage = "FirstName can't be longer than 50 characters")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "LastName can't be longer than 50 characters")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "UserName can't be longer than 50 characters")]
        public string UserName { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }

        [Required]
        public Role Role { get; set; }

        public Company Company { get; set; }

        public IReadOnlyCollection<Event> Events { get; set; }

        public User() { }

        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
