using AutoMapper;
using Blog.Application.Dtos;
using Blog.Application.Interfaces;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;

namespace Blog.Application.Service
{
    public class AuthService : IAuthService
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public AuthService(IUserRepository userRepository, IMapper mapper, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<string> Login(UserDto dto)
        {

            var userName = _mapper.Map<string>(dto.UserName);
            var user = await _userRepository.GetUser(userName);
            
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
                throw new Exception("Usuário Inválido!");

            //return JWT
            return _tokenService.GenereteToken(user.Id, user.UserName);

        }

        public async Task<bool> RegisterUser(UserDto dto)
        {

            var hash = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            var user = new UserDto
            {
                UserName = dto.UserName,
                Password = hash
            };
           
            var reult = await _userRepository.SaveUser(_mapper.Map<User>(user));

            return reult;

        }

    }
}
