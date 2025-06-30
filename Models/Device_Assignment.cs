namespace itTicketSystem.Models
{

    public class Device_Assignment
    {
        public int id { get; set; }
        public int device_id { get; set; }
        public Device_Inventory? Device_Inventory { get; set; }
        public int user_id { get; set; }
        public Users? Users { get; set; }
    }
}