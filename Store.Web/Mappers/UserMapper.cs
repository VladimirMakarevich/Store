using Store.Web.Models;
using Store.DAL.Entities;
using AutoMapper;

namespace Store.Web.Mappers
{
    public class UserMapper
    {
        private IMapper _mapper;

        public UserMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public User ToUser(RegistrationUser registrationJsonModel)
        {
            return _mapper.Map<RegistrationUser, User>(registrationJsonModel);
        }
    }
}