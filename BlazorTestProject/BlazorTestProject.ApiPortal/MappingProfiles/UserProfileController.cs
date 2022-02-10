using AutoMapper;
using BlazorTestProject.BLL.DTO;
using BlazorTestProject.Models.Models;

namespace BlazorTestProject.ApiPortal.MappingProfiles
{
    public class UserProfileController : Profile
    {
        public UserProfileController()
        {
            #region To DTO
            CreateMap<UserRegistrationModel, UserDTO>();
            CreateMap<UserInfoModel, UserInfoDTO>();
            CreateMap<RoleNamesModel, RoleDTO>();
            #endregion

            #region from DTO
            CreateMap<UserDTO, UserRegistrationModel>();
            CreateMap<UserInfoDTO, UserInfoModel>();
            CreateMap<RoleDTO, RoleNamesModel>();
            #endregion
        }
    }
}
