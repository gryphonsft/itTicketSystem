namespace itTicketSystem.Models
{
    public class TicketsCreateDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Priority { get; set; }
        public string? Category { get; set; }
        public int AssignedToUserId { get; set; }
    }

}