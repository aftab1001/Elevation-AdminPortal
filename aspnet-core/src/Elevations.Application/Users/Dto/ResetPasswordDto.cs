namespace Elevations.Users.Dto
{
    using System.ComponentModel.DataAnnotations;

    public class ResetPasswordDto
    {
        [Required]
        public string AdminPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }

        [Required]
        public long UserId { get; set; }
    }
}