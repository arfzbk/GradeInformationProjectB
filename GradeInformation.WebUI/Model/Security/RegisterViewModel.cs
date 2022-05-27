using System.ComponentModel.DataAnnotations;

namespace GradeInformation.WebUI.Model.Security
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(11)]
        public string TC { get; set; }
    }
}
