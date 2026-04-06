using Blog.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Interfaces
{
    public interface IUserService
    {

        Task<UserDto> GetUser(string userName);

    }
}
