using AutoMapper;
using SchoolJournal.DataAccess.Primitives;
using SchoolJournal.Primitives;

namespace SchoolJournal.Mapping;

public class StudentProfile : Profile
{
    public StudentProfile()
    {
        CreateMap<Student, StudentViewModel>()
            .ForMember(x => x.FullName,
                opt => opt.MapFrom(src => string.Join(' ', src.Names)));
        CreateMap<StudentUpdateModel, Student>()
            .ForMember(x => x.Names,
                opt => opt.MapFrom(src => src.FullName.Split(' ', StringSplitOptions.None)));
        CreateMap<StudentCreateModel, Student>()
            .ForMember(x => x.Names,
                opt => opt.MapFrom(src => src.FullName.Split(' ', StringSplitOptions.None)));
    }
}