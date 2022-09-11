using AutoMapper;
using SchoolJournal.DataAccess.Primitives;
using SchoolJournal.Primitives;

namespace SchoolJournal.Mapping;

public class TeacherProfile : Profile
{
    public TeacherProfile()
    {
        CreateMap<Teacher, TeacherViewModel>()
            .ForMember(x => x.FullName,
                opt => opt.MapFrom(src => string.Join(' ', src.Names)));
        // CreateMap<TeacherUpdateModel, Teacher>()
        //     .ForMember(x => x.Names,
        //         opt => opt.MapFrom(src => src.FullName.Split(' ', StringSplitOptions.None)));
        // CreateMap<TeacherCreateModel, Teacher>()
        //     .ForMember(x => x.Names,
        //         opt => opt.MapFrom(src => src.FullName.Split(' ', StringSplitOptions.None)));
    }
}