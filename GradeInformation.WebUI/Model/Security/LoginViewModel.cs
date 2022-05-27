using System.ComponentModel.DataAnnotations;

namespace GradeInformation.WebUI.Model.Security
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public bool IsPersistent { get; internal set; }
    }
}
