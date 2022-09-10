using AutoMapper;
using SchoolJournal.DataAccess.Primitives;
using SchoolJournal.Primitives;

namespace SchoolJournal.Mapping;

public class SubjectJournalProfile : Profile
{
    public SubjectJournalProfile()
    {
        CreateMap<SubjectJournal, SubjectJournalViewModel>();
    }
}