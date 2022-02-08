using AutoMapper;
using BlazorTestProject.BLL.DTO;
using BlazorTestProject.DAL.Entities;
using BlazorTestProject.Models.Models;

namespace BlazorTestProject.ApiPortal.MappingProfiles
{
    public class UserProfileController : Profile
    {
        public UserProfileController()
        {
            #region To DTO
            CreateMap<UserRegistrationModel, UserDTO>();
            CreateMap<UserModel, UserDTO>();
            #endregion

            #region from DTO
            CreateMap<UserDTO, UserRegistrationModel>();
            CreateMap<UserDTO, UserModel>();
            #endregion
        }
    }
}
