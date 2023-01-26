using System.ComponentModel.DataAnnotations;

namespace Nachweis0r.Models;

public class LoginViewModel
{
    public string UserName { get; set; }
    [DataType(DataType.Password)]
    [Required]
    public string Password { get; set; }

    public bool RememberMe { get; set; }
}