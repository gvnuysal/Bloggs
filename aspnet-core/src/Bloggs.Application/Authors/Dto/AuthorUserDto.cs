using Abp.Application.Services.Dto;

namespace Bloggs.Authors.Dto
{
    public class AuthorUserDto:EntityDto<long>
    {
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
    }
}
