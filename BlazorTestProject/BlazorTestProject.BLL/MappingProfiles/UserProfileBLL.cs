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
            #endregion

            #region from DTO
            CreateMap<UserDTO, User>();
            #endregion
        }
    }
}
