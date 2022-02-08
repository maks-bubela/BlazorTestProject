﻿using AutoMapper;
using BlazorTestProject.BLL.DTO;
using BlazorTestProject.BLL.Interfaces;
using BlazorTestProject.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

        private CurrentUser _curentUser;
        //private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthenticationController(IMapper mapper, IAuthenticationService authenticationService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(IMapper));
            _authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(IAuthenticationService));
            _curentUser = new CurrentUser();
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

        /// <summary>
        /// Authenticates a user and returns generated token if authentication is successful
        /// </summary>
        /// <param name="user">User and login information to authenticate</param>
        /// <returns></returns>
        /// <response code="200"> User is authenticated </response>
        /// <response code="409"> Authentication is failed </response>
        /// <response code="204"> Not founded environment type </response>
        /// <response code="400">Model not valid</response>    
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] UserLoginModel user)
        {
            if (ModelState.IsValid)
            {
                var verified = await _authenticationService.VerifyCredentialsAsync(user.Username, user.Password);
                if (verified <= 0)
                    return Conflict(new { errorText = InvalidUserData });
                var userIdentity = await SetIdentityAsync(user);
                
                _curentUser = new CurrentUser
                {
                    IsAuthenticated = true,
                    UserName = userIdentity.Name,
                    Claims = userIdentity.Claims
                        .ToDictionary(c => c.Type, c => c.Value)
                };
                return Ok(_curentUser);
            }
            return BadRequest(new { errorText = InvalidUserData });
        }

        [HttpGet]
        [Route("user/info")]
        public CurrentUser CurrentUserInfo()
        {
            return new CurrentUser
            {
                IsAuthenticated = User.Identity.IsAuthenticated,
                UserName = User.Identity.Name,
                Claims = User.Claims
                    .ToDictionary(c => c.Type, c => c.Value)
            };
        }

        private async Task<ClaimsIdentity> SetIdentityAsync(UserLoginModel userModel)
        {
            var verified = await _authenticationService.VerifyCredentialsAsync(userModel.Username, userModel.Password);
            if (verified > 0)
            {
                var userDTO = await _authenticationService.GetUserIdentityById(verified);
                if (userDTO != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimsIdentity.DefaultNameClaimType, userDTO.Username),
                        new Claim(ClaimsIdentity.DefaultRoleClaimType, userDTO.RoleName),
                        new Claim(ClaimTypes.NameIdentifier, userDTO.UserId.ToString())
                    };
                    ClaimsIdentity claimsIdentity =
                        new ClaimsIdentity(claims, "Server authentication", ClaimsIdentity.DefaultNameClaimType,
                            ClaimsIdentity.DefaultRoleClaimType);
                    return claimsIdentity;
                }
            }
            return null;
        }
    }
}