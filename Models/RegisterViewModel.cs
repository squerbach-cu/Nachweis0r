using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MessagePack;
using Nachweis0r.Areas.Identity.Pages.Account;

namespace Nachweis0r.Models;

public class RegisterViewModel
{
    [Required]
    public string UserName { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}