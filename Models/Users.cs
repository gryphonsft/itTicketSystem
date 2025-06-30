namespace itTicketSystem.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }

        public int RoleId { get; set; }
        public Roles? Roles { get; set; }

        public ICollection<Tickets>? CreatedTickets { get; set; }
        public ICollection<Tickets>? AssignedTickets { get; set; }
        public ICollection<Device_Assignment>? Device_Assignments { get; set; }      
    }
}
