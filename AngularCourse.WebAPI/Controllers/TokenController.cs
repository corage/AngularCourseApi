using AngularCourse.Models;
using AngularCourse.UnitOfWork;
using AngularCourse.WebAPI.Authentication;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularCourse.WebAPI.Controllers
{
    [Route("api/token")]
    [EnableCors("CorsPolitic")]
    public class TokenController: Controller
    {
        private ITokenProvider _tokenProvider;
        private IUnitOfWork _unitOfWork;
        public TokenController(ITokenProvider tokenProvider,IUnitOfWork unitOfWork)
        {
            _tokenProvider = tokenProvider;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public JsonWebToken Post([FromBody]User userLogin)
        {
            var user = _unitOfWork.User.ValidateUser(userLogin.Email,userLogin.Password);
            if (user == null)
            {
                throw new UnauthorizedAccessException();
            }
            var token = new JsonWebToken
            {
                Acces_Token = _tokenProvider.CreateToken(user,DateTime.UtcNow.AddHours(8)),
                Expires_in = 480//minutes
            };

            return token;
        }
    }
}
