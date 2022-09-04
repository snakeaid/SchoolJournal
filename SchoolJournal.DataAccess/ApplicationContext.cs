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
        //Database.EnsureCreated(); //TODO: Should we use it?
    }

    /// <summary>
    /// Gets and sets the instance of <see cref="DbSet{TEntity}"/> for <see cref="Student"/>,
    /// represents the students table and is used for database interactions.
    /// </summary>
    public DbSet<Student> Students { get; set; } = null!;

    /// <summary>
    /// Gets and sets the instance of <see cref="DbSet{TEntity}"/> for <see cref="Teacher"/>,
    /// represents the teachers table and is used for database interactions.
    /// </summary>
    public DbSet<Teacher> Teachers { get; set; } = null!;

    /// <summary>
    /// Gets and sets the instance of <see cref="DbSet{TEntity}"/> for <see cref="Class"/>,
    /// represents the classes table and is used for database interactions.
    /// </summary>
    public DbSet<Class> Classes { get; set; } = null!;

    /// <summary>
    /// Gets and sets the instance of <see cref="DbSet{TEntity}"/> for <see cref="Subjects"/>,
    /// represents the subjects table and is used for database interactions.
    /// </summary>
    public DbSet<Subject> Subjects { get; set; } = null!;

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