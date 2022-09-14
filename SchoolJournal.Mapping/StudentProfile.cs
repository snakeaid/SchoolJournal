using AutoMapper;
using SchoolJournal.DataAccess.Primitives;
using SchoolJournal.Primitives;

namespace SchoolJournal.Mapping;

public class StudentProfile : Profile
{
    public StudentProfile()
    {
        CreateMap<Student, StudentViewModel>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
        CreateMap<StudentUpdateModel, Student>();
        CreateMap<StudentCreateModel, Student>();
    }
}