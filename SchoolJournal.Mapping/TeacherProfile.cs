using AutoMapper;
using SchoolJournal.DataAccess.Primitives;
using SchoolJournal.Primitives;

namespace SchoolJournal.Mapping;

public class TeacherProfile : Profile
{
    public TeacherProfile()
    {
        CreateMap<Teacher, TeacherModel>()
            .ForMember(x => x.FullName,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
    }
}