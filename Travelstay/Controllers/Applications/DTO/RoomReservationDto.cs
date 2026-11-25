namespace Travelstay.Controllers.Applications.DTO
{
    public class RoomReservationDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public int Adults { get; set; } = 1;
        public int Children { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
