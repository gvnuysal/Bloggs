using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Bloggs.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloggs.Users.Dto
{
    [AutoMapFrom(typeof(User))]
    public class UserListDto : EntityDto<long>
    {
      
        public string UserName { get; set; }

      
        public string Name { get; set; }

      
        public string Surname { get; set; }

       
        public string EmailAddress { get; set; }

        public bool IsActive { get; set; }

        public string FullName { get; set; }

        public DateTime? LastLoginTime { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
