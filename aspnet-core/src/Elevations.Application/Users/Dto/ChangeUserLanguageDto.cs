using System.ComponentModel.DataAnnotations;

namespace Elevations.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}