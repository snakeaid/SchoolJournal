using Microsoft.EntityFrameworkCore;
using SchoolJournal.DataAccess;
using SchoolJournal.DataAccess.Primitives;

namespace SchoolJournal.BusinessLogic.Extensions;

/// <summary>
/// Provides extension methods for <see cref="ApplicationContext"/>.
/// </summary>
public static class ApplicationContextExtensions
{
    /// <summary>
    /// Gets complete classes from the database context.
    /// </summary>
    /// <param name="context">The database context.</param>
    /// <returns><see cref="IQueryable{T}"/> fpr <see cref="Class"/></returns>
    public static IQueryable<Class> CompleteClasses(this ApplicationContext context)
    {
        return context.Classes
            .Include(x => x.Students)
            .Include(x => x.ClassTeacher)
            .Include(x => x.Journal)!.ThenInclude(x => x.Lessons)
            .Include(x => x.Journal)!.ThenInclude(x => x.Subject);
    }
}