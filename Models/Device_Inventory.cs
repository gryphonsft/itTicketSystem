using System.ComponentModel.DataAnnotations;

namespace itTicketSystem.Models
{
    public class Device_Inventory
    {
        [Key]
        public int device_id { get; set; }
        public string? device_name { get; set; }
        public ICollection<Device_Assignment>? Device_Assignments { get; set; }

    }
}