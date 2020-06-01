using AngularCourse.Models;
using Microsoft.IdentityModel.Tokens;
using System;

namespace AngularCourse.WebAPI.Authentication
{
    public interface ITokenProvider
    {
        string CreateToken(User user, DateTime expiry);
        TokenValidationParameters GetValidationParameters();
    }
}
