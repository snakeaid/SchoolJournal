using AutoMapper;
using SchoolJournal.DataAccess.Primitives;
using SchoolJournal.Primitives;

namespace SchoolJournal.Mapping;

public class TeacherProfile : Profile
{
    public TeacherProfile()
    {
        CreateMap<Teacher, TeacherViewModel>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
            .ForMember(dest => dest.Classes,
                opt => opt.MapFrom(src => src.Journals == null ? null : src.Journals!.Select(x => x.Class)));
        // CreateMap<TeacherUpdateModel, Teacher>();
        // CreateMap<TeacherCreateModel, Teacher>();
    }
}