using Microsoft.EntityFrameworkCore;

namespace itTicketSystem.Models
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Tickets> Tickets { get; set; }
        public DbSet<Device_Inventory> Device_Inventory { get; set; }
        public DbSet<Device_Assignment> Device_Assignments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .HasOne(u => u.Roles)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);


            modelBuilder.Entity<Tickets>()
                .HasOne(t => t.Users)
                .WithMany(u => u.CreatedTickets)
                .HasForeignKey(t => t.user_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Tickets>()
                .HasOne(t => t.AssignedToUser)
                .WithMany(u => u.AssignedTickets)
                .HasForeignKey(t => t.assigned_to_user_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Device_Assignment>()
                .HasOne(da => da.Device_Inventory)
                .WithMany(d => d.Device_Assignments)
                .HasForeignKey(da => da.device_id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Device_Assignment>()
                .HasOne(da => da.Users)
                .WithMany(u => u.Device_Assignments)
                .HasForeignKey(da => da.user_id)
                .OnDelete(DeleteBehavior.Cascade);

        }

    }

}