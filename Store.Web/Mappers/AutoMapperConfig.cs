﻿using AutoMapper;
using Ninject.Activation;
using Store.DAL.Entities;

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
            config.CreateMap<UserMapper, User>().ReverseMap();
        }
    }
}