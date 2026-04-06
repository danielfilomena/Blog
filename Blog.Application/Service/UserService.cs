using AutoMapper;
using Blog.Application.Dtos;
using Blog.Application.Interfaces;
using Blog.Domain.Interfaces;

namespace Blog.Application.Service
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {

            _userRepository = userRepository;
            _mapper = mapper;

        }

        public async Task<UserDto> GetUser(string userName)
        {

            var user = await _userRepository.GetUser(userName);
            return _mapper.Map<UserDto>(user);

        }

    }
}
