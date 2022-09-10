using FreezeDanceTouring.Data.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FreezeDanceTouring.Data.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Agent> Agents{ get; set; }
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Show> Shows { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Tour> Tours { get; set; }
    public DbSet<Venue> Venues { get; set; }
    public DbSet<Venue_Tour> Venue_Tours { get; set; }
    public DbSet<Artist_Tour> Artist_Tours { get; set; }
}

