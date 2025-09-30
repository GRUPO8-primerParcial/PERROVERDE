using System;
using System.ComponentModel.DataAnnotations;

namespace PERROVERDE8.API.Models
{
    public class SupportTicket
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(200)]
        public string Subject { get; set; }

        [Required, EmailAddress, StringLength(200)]
        public string RequesterEmail { get; set; }

        public string? Description { get; set; }

        [Required, StringLength(20)]
        public string Severity { get; set; } = "Medium";

        [Required, StringLength(20)]
        public string Status { get; set; } = "Open";

        [Required]
        public DateTime OpenedAt { get; set; } = DateTime.UtcNow;

        public DateTime? ClosedAt { get; set; }

        [StringLength(150)]
        public string? AssignedTo { get; set; }
    }
}