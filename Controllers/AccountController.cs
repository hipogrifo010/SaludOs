using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AlkemyWallet.Core.Helper;
using ApiSalud.Core.Interfaces;
using ApiSalud.Entities;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ApiSalud.Core.Services;

[Produces("application/json")]
[Route("/auth")]
public class AccountController : Controller
{
    private readonly IConfiguration _configuration;
   // private readonly ISendgridMailService _mailService;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public AccountController(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IConfiguration configuration
        //ISendgridMailService mailService
        )

    {
        //_mailService = mailService;
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
    }

    /// <Register>
    ///     https://localhost:7105/auth/register
    ///     </RequerimientosdePassword:NoAlfanumerico,Uppercase,LowerCase,DigitRequired,MinimoCaracteres=6>
    [Route("register")]
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] UserInfo model)
    {
        if (ModelState.IsValid)
        {
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                // falta configurar el sistema de Mailsend es decir subir los secrets a azure :)
               // await _mailService.SendEmailAsync(model.Email, "Email: " + user.Email,
              //     " Password: " + model.Password + " fecha de creacion: " + DateTime.Now);

                return BuildToken(model);
            }

            return BadRequest("Username or password invalid");
        }

        return BadRequest(ModelState);
    }


    /// <Login>
    ///     https://localhost:7105/auth/login
    ///     </UtilizarMailcomoLoginaccount>
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] UserInfo userInfo)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(userInfo.Email, userInfo.Password, false, false);
            if (result.Succeeded) return BuildToken(userInfo);

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return BadRequest(ModelState);
        }

        return BadRequest(ModelState);
    }

    private IActionResult BuildToken(UserInfo userInfo)
    {
        const string secretName = "APISECRET";
        var keyVaultName = "ubaldoramirezapi";
        var kvUri = $"https://{keyVaultName}.vault.azure.net";


        var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());

        var secret = client.GetSecretAsync(secretName).Result.Value;

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
            new Claim(secret.Name,secret.Value),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };


        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["VaultUri"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var expiration = DateTime.UtcNow.AddHours(1);

        var token = new JwtSecurityToken(
            issuer:  "ubaldoramirez.azurewebsites.net",
            audience: "ubaldoramirez.azurewebsites.net",
            claims,
            expires: expiration,
            signingCredentials: creds);


        return Ok(new
        {
            token = new JwtSecurityTokenHandler().WriteToken(token),
            expiration = expiration,
            
        }) ;

    }
}