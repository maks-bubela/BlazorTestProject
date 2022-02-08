using AutoMapper;
using BlazorTestProject.BLL.DTO;
using BlazorTestProject.BLL.Enums;
using BlazorTestProject.BLL.Interfaces;
using BlazorTestProject.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BlazorTestProject.ApiPortal.Controllers
{
    [Route("api/authentication")]
    public class AuthenticationController : ControllerBase
    {
        #region Constants
        private const string InvalidUserData = "Invalid username or password.";
        private const string InvalidModel = "Invalid input model.";
        #endregion

        #region Services
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;
        #endregion

        public AuthenticationController(IMapper mapper, IAuthenticationService authenticationService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(IMapper));
            _authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(IAuthenticationService));
        }

        /// <summary>
        /// Registration new user and add him into database
        /// </summary>
        /// <param name="userRegist">User and login information to authenticate</param>
        /// <returns></returns>
        /// <response code="200"> User is authenticated </response>
        /// <response code="409"> Authentication is failed </response>
        /// <response code="400"> Model not valid </response>    
        [HttpPost]
        [Route("registration")]
        public async Task<IActionResult> RegistrationAsync(
            [FromBody] UserRegistrationModel userRegist)
        {
            if (ModelState.IsValid && userRegist != null)
            {
                var userDto = _mapper.Map<UserDTO>(userRegist);
                userDto.RoleId = (long)Roles.Customer;

                var userId = await _authenticationService.RegisterUserAsync(userDto);
                if (userId != 0)
                {
                    var response = new SuccesfullRegistUserModel()
                    {
                        Username = userDto.Username,
                        Firstname = userDto.Firstname,
                        Lastname = userDto.Lastname
                    };
                    return StatusCode(201, response);
                }
                return Conflict();
            }
            return BadRequest(new { errorText = InvalidModel });
        }
    }
}
