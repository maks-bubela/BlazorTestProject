using AutoMapper;
using BlazorTestProject.BLL.DTO;
using BlazorTestProject.DAL.Entities;

namespace BlazorTestProject.BLL.MappingProfiles
{
    public class UserProfileBLL : Profile
    {
        public UserProfileBLL()
        {
            #region To DTO
            CreateMap<User, UserDTO>();
            CreateMap<Role, RoleDTO>();
            CreateMap<User, UserInfoDTO>().ForMember(x => x.RoleName, 
                b => b.MapFrom(src => src.Role.RoleName));
            #endregion

            #region from DTO
            CreateMap<UserDTO, User>();
            CreateMap<RoleDTO, Role>();
            CreateMap<UserInfoDTO, User>();
            #endregion
        }
    }
}
