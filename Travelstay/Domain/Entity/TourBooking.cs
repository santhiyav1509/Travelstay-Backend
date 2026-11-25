using System.ComponentModel.DataAnnotations;

namespace Travelstay.Domain.Entity
{
    public class TourBooking
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; } = "";
        public string? LastName { get; set; }
        public string Email { get; set; } = "";
        public string? Phone { get; set; }
        public DateTime VisitDate { get; set; }
        public string GroupSize { get; set; } = "";
        public string TourName { get; set; } = "";
        public string ContactMethod { get; set; } = "Phone";   // Phone or Email
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
