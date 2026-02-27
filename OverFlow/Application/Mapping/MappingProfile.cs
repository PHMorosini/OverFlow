using AutoMapper;
using OverFlow.Domain.Usuario.Entity;

namespace OverFlow.Application.Mapping;
public class MappingProfile : Profile
{

    public MappingProfile()
    {
        //depois trocar pra userViewModel

        CreateMap<UserEntity, UserEntity>();
        CreateMap<UserEntity, UserEntity>();
    }

}
