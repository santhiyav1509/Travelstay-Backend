namespace Travelstay.Controllers.Applications.DTO
{
    public class TourBookingDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string? LastName { get; set; }
        public string Email { get; set; } = "";
        public string? Phone { get; set; }
        public DateTime VisitDate { get; set; }
        public string GroupSize { get; set; } = "";
        public string TourName { get; set; } = "";
        public string ContactMethod { get; set; } = "Phone";
        public DateTime CreatedAt { get; set; }
    }
}
