using AutoMapper;
using Blog.Application.Dtos;
using Blog.Domain.Entities;

namespace Blog.Application.Mapping
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {

            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<PostDto, Post>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();

        }

    }
}
