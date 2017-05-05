using AutoMapper;
using Ninject.Activation;
using Store.DAL.Entities;
using Store.Web.Models;

namespace Store.Web.Mappers
{
    public class AutoMapperConfig
    {
        public static IMapper GetMapper(IContext context)
        {
            MapperConfiguration config = new MapperConfiguration(RegisterMappings);
            IMapper mapper = config.CreateMapper();
            return mapper;
        }

        private static void RegisterMappings(IMapperConfigurationExpression config)
        {
            config.CreateMap<RegistrationUser, User>()
                .ForMember(dest => dest.Login,
                           opt => opt.MapFrom(src => src.Email));
        }
    }
}