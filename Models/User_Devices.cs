namespace itTicketSystem.Models
{

    public class User_Devices
{
    public int UserDeviceId { get; set; }

    public int UserId { get; set; }     
    public int DeviceId { get; set; }   

    public DateTime AssignedAt { get; set; } = DateTime.Now;
    public DateTime? UnassignedAt { get; set; }
    public bool IsCurrentlyAssigned { get; set; } = true;

    // Navigation Properties
    public Users? Users { get; set; }
    public Devices? Devices { get; set; }
}

}