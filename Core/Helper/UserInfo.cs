using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiSalud.Core.Helper;

[Table("UserInfo")]
public class UserInfo
{
    [Key] public string Email { get; set; }

    public string Password { get; set; }
}