using System.ComponentModel.DataAnnotations;

namespace ContactDatabase.API.Shared
{
    public class Contact
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public bool MarriageStatus { get; set; }
    }
}
