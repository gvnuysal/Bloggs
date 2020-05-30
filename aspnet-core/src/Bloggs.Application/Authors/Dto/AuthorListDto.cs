using Abp.Application.Services.Dto;
using Bloggs.Users.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloggs.Authors.Dto
{
    public class AuthorListDto:EntityDto<long>
    {
        public UserDto UserDto { get; set; }
        public AuthorDto AuthorDto { get; set; }
    }
}
