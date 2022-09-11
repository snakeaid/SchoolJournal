using AutoMapper;
using SchoolJournal.DataAccess.Primitives;
using SchoolJournal.Primitives;

namespace SchoolJournal.Mapping;

public class ClassProfile : Profile
{
    public ClassProfile()
    {
        CreateMap<Class, ClassViewModel>();
        CreateMap<ClassCreateModel, Class>();
        CreateMap<ClassUpdateModel, Class>();
    }
}