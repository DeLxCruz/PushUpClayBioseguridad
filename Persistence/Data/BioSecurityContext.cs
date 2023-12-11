using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Persistence.Data;

public partial class BioSecurityContext : DbContext
{
    public BioSecurityContext()
    {
    }

    public BioSecurityContext(DbContextOptions<BioSecurityContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Addresstype> Addresstypes { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Contacttype> Contacttypes { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<Contracttype> Contracttypes { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Personaddress> Personaddresses { get; set; }

    public virtual DbSet<Personcategory> Personcategories { get; set; }

    public virtual DbSet<Personcontact> Personcontacts { get; set; }

    public virtual DbSet<Persontype> Persontypes { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Shift> Shifts { get; set; }

    public virtual DbSet<State> States { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<UserRol> UsersRols { get; set; }

    public DbSet<Rol> Rols { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
