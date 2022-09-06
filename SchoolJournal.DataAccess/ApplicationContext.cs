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
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
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
    /// Gets and sets the instance of <see cref="DbSet{TEntity}"/> for <see cref="Subject"/>,
    /// represents the subjects table and is used for database interactions.
    /// </summary>
    public DbSet<Subject> Subjects { get; set; } = null!;

    /// <summary>
    /// Gets and sets the instance of <see cref="DbSet{TEntity}"/> for <see cref="Lesson"/>,
    /// represents the lessons table and is used for database interactions.
    /// </summary>
    public DbSet<Lesson> Lessons { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>()
            .Property(x => x.Students)
            .HasConversion(
                x => JsonConvert.SerializeObject(x),
                x => JsonConvert.DeserializeObject<List<Student>>(x)!);
        modelBuilder.Entity<Class>()
            .Property(x => x.Journal)
            .HasConversion(
                x => JsonConvert.SerializeObject(x),
                x => JsonConvert.DeserializeObject<List<SubjectJournal>>(x)!);

        modelBuilder.Entity<Lesson>()
            .Property(x => x.Marks)
            .HasConversion(
                x => JsonConvert.SerializeObject(x),
                x => JsonConvert.DeserializeObject<Dictionary<Student, Mark?>>(x)!);

        modelBuilder.Entity<SubjectJournal>()
            .Property(x => x.Lessons)
            .HasConversion(
                x => JsonConvert.SerializeObject(x),
                x => JsonConvert.DeserializeObject<List<Lesson>>(x)!);

        base.OnModelCreating(modelBuilder);
    }
}