using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Interfaces
{
    public interface ITokenService
    {

        string GenereteToken(Guid userId, string userName);

    }
}
