using System.Collections.Generic;
using Toolaku.Models.DTO;
using Toolaku.Models.Pagingnation;

namespace Toolaku.Models.Profile
{
    public class UserDetail
    {
        public int UserId { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string MobileNo { get; set; }
        public bool ActiveStatus { get; set; }
        public int RoleId { get; set; }
    }

    public class UserDetailList
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string MobileNo { get; set; }
        public bool ActiveStatus { get; set; }
        public string RoleName { get; set; }
    }

    public class UserDetailLists : ResponseBase
    {
        public List<UserDetailList> UserList { get; set; }

        public PageInfo pageInfo { get; set; }
    }

    public class UserDetailNew
    {
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string MobileNo { get; set; }
        public bool ActiveStatus { get; set; }
        public int RoleId { get; set; }
    }

    public class UserIdToRemove
    {
        public int UserId { get; set; }
    }

    public class UserSetting
    {
        public string ImageUrl { get; set; }
        public string Fullname { get; set; }
        public string PhoneNo { get; set; }
    }

    public class ProfileListIdToDelete
    {
        public int id { get; set; }
    }

}
