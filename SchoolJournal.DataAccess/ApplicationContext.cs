using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

    //TODO: Add comment
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(new DateOnlyJsonConverter());

        //TODO: Deal with comparers
        var studentComparer = new ValueComparer<List<Student>>(
            (c1, c2) => c1!.SequenceEqual(c2!),
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
            c => c);
        var journalComparer = new ValueComparer<List<SubjectJournal>>(
            (c1, c2) => c1!.SequenceEqual(c2!),
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
            c => c);
        var marksComparer = new ValueComparer<Dictionary<Student, Mark?>>(
            (c1, c2) => c1!.SequenceEqual(c2!),
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
            c => c);
        var lessonComparer = new ValueComparer<List<Lesson>>(
            (c1, c2) => c1!.SequenceEqual(c2!),
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
            c => c);

        modelBuilder.Entity<Class>()
            .Property(x => x.Students)
            .HasConversion(
                x => JsonSerializer.Serialize(x, options),
                x => JsonSerializer.Deserialize<List<Student>>(x, options)!)
            .Metadata.SetValueComparer(studentComparer);
        modelBuilder.Entity<Class>()
            .Property(x => x.Journal)
            .HasConversion(
                x => JsonSerializer.Serialize(x, options),
                x => JsonSerializer.Deserialize<List<SubjectJournal>>(x, options)!)
            .Metadata.SetValueComparer(journalComparer);

        modelBuilder.Entity<Lesson>()
            .Property(x => x.Marks)
            .HasConversion(
                x => JsonSerializer.Serialize(x, options),
                x => JsonSerializer.Deserialize<Dictionary<Student, Mark?>>(x, options)!)
            .Metadata.SetValueComparer(marksComparer);

        modelBuilder.Entity<SubjectJournal>()
            .Property(x => x.Lessons)
            .HasConversion(
                x => JsonSerializer.Serialize(x, options),
                x => JsonSerializer.Deserialize<List<Lesson>>(x, options)!)
            .Metadata.SetValueComparer(lessonComparer);

        var s1 = new Student
        {
            Id = 1, FirstName = "Mikhail", LastName = "Mikhaylov", ClassId = 1,
            Birthday = new DateOnly(2005, 7, 9), Login = "mikhail", Password = "1111"
        };
        var s2 = new Student
        {
            Id = 2, FirstName = "Vasiliy", LastName = "Vasiliev", ClassId = 1,
            Birthday = new DateOnly(2006, 1, 2), Login = "vasya2006", Password = "13863"
        };
        var students = new List<Student>();
        students.Add(s1);
        students.Add(s2);
        var t = new Teacher
        {
            Id = 1, FirstName = "Yana", LastName = "Yanovna",
            Birthday = new DateOnly(1983, 11, 18), Login = "yanito", Password = "lll"
        };
        var c = new Class
        {
            Id = 1, Number = 11, Students = students, ClassTeacherId = 1
        };

        modelBuilder.Entity<Student>().HasData(students);
        modelBuilder.Entity<Teacher>().HasData(t);
        modelBuilder.Entity<Class>().HasData(c);

        base.OnModelCreating(modelBuilder);
    }
}