using AutoMapper;
using DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using ViewModels;

namespace Strijp_T_Hotspots.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthenticationHandler authenticationHandler;
        private IMapper mapper;

        public AuthController(IAuthenticationHandler authenticationHandler, IMapper mapper)
        {
            this.authenticationHandler = authenticationHandler;
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult login([FromBody] UserLoginRequest loginRequest)
        {
            try
            {
                string token = authenticationHandler.LoginUser(mapper.Map<UserLoginRequestDTO>(loginRequest));
                return Ok(token);
            }
            catch (Exception e)
            {
                if (e.Message == "Invalid email" || e.Message == "Invalid password")
                {
                    return StatusCode(422, e.Message);
                }
                return StatusCode(500, e.Message);
            }
        }
    }
}
