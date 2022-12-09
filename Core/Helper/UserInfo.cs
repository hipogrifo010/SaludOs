using System.ComponentModel.DataAnnotations;

namespace AlkemyWallet.Core.Helper;

public class UserInfo
{
    [Key] public string Email { get; set; }

    public string Password { get; set; }
}