using Microsoft.EntityFrameworkCore;
using CreekRiver.Models;

public class CreekRiverDbContext : DbContext
{

    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Campsite> Campsites { get; set; }
    public DbSet<CampsiteType> CampsiteTypes { get; set; }

    public CreekRiverDbContext(DbContextOptions<CreekRiverDbContext> context) : base(context)
    {

    }
}

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Campsite>().HasData(new Campsite[]
    {
        new Campsite {Id = 1, CampsiteTypeId = 1, Nickname = "Barred Owl", ImageUrl="https://tnstateparks.com/assets/images/content-images/campgrounds/249/colsp-area2-site73.jpg"},
        new Campsite {Id = 2, CampsiteTypeId = 2, Nickname = "Riverside Retreat", ImageUrl="https://example.com/image2.jpg"},
        new Campsite {Id = 3, CampsiteTypeId = 1, Nickname = "Forest Haven", ImageUrl="https://example.com/image3.jpg"},
        new Campsite {Id = 4, CampsiteTypeId = 3, Nickname = "Primitive Paradise", ImageUrl="https://example.com/image4.jpg"},
        new Campsite {Id = 5, CampsiteTypeId = 4, Nickname = "Hammock Hideaway", ImageUrl="https://example.com/image5.jpg"}
    });

    modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
 {
        new UserProfile {Id = 1, FirstName = "John", LastName = "Doe", Email = "john@example.com"}
 
 });

    modelBuilder.Entity<Reservation>().HasData(new Reservation[]
{
        new Reservation
        {
            Id = 1,
            UserProfileId = 1,   // Matches the UserProfile's Id
            CampsiteId = 1,      // Matches the Campsite's Id
            CheckinDate = DateTime.Now.AddDays(1),
            CheckoutDate = DateTime.Now.AddDays(5)
        }
});

    modelBuilder.Entity<CampsiteType>().HasData(new CampsiteType[]
    {
        new CampsiteType {Id = 1, CampsiteTypeName = "Tent", FeePerNight = 15.99M, MaxReservationDays = 7},
        new CampsiteType {Id = 2, CampsiteTypeName = "RV", FeePerNight = 26.50M, MaxReservationDays = 14},
        new CampsiteType {Id = 3, CampsiteTypeName = "Primitive", FeePerNight = 10.00M, MaxReservationDays = 3},
        new CampsiteType {Id = 4, CampsiteTypeName = "Hammock", FeePerNight = 12M, MaxReservationDays = 7}
    });
}