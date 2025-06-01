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
        }

    }

}