using System.ComponentModel.DataAnnotations;

namespace Bloggs.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}