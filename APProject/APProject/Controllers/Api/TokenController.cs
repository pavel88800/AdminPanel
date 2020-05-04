using System.Collections.Generic;
using System.Security.Claims;
using APP.Auth.Interfaces;
using APProject.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace APProject.Controllers.Api
{
    /// <summary>
    ///     Контроллер по работе с токеном.
    /// </summary>
    public class TokenController : BaseApiController
    {
        private readonly IGenerateTokenService _token;

        public TokenController(IGenerateTokenService token)
        {
            _token = token;
        }

        [HttpPost("/token")]
        public IActionResult GetToken(string login, string password)
        {
            var result = _token.GetToken(login, password);
            return Ok(result);
        }
        
    }
}