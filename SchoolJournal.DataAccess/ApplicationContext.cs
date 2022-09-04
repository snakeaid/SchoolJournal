using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SchoolJournal.DataAccess.Primitives;

namespace SchoolJournal.DataAccess;

/// <summary>
/// Entity Framework context class which represents the database.
/// </summary>
public class ApplicationContext : DbContext
{
    /// <summary>
    /// Constructs an instance of <see cref="ApplicationContext"/> using the specified options.
    /// </summary>
    /// <param name="options"></param>
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
        Database.EnsureCreated(); //TODO: Should we use it?
    }

    /// <summary>
    /// 
    /// </summary>
    public DbSet<Student> Students { get; set; }

    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<Subject> Subjects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>()
            .Property(x => x.Students)
            .HasConversion(
                x => JsonConvert.SerializeObject(x),
                x => JsonConvert.DeserializeObject<List<Student>>(x)!);
        modelBuilder.Entity<Class>()
            .Property(x => x.Subjects)
            .HasConversion(
                x => JsonConvert.SerializeObject(x),
                x => JsonConvert.DeserializeObject<Dictionary<Subject, Teacher>>(x)!);
        modelBuilder.Entity<Class>()
            .Property(x => x.Specialization)
            .HasConversion(
                x => JsonConvert.SerializeObject(x),
                x => JsonConvert.DeserializeObject<List<Subject>>(x)!);

        modelBuilder.Entity<Teacher>()
            .Property(x => x.Classes)
            .HasConversion(
                x => JsonConvert.SerializeObject(x),
                x => JsonConvert.DeserializeObject<List<Class>>(x)!);
        modelBuilder.Entity<Teacher>()
            .Property(x => x.Specialization)
            .HasConversion(
                x => JsonConvert.SerializeObject(x),
                x => JsonConvert.DeserializeObject<List<Subject>>(x)!);
        base.OnModelCreating(modelBuilder);
    }
}