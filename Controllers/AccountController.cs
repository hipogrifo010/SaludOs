using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AlkemyWallet.Core.Helper;
using ApiSalud.Entities;
using ApiSalud.Core.Interfaces;

namespace ApiSalud.Core.Services
{

    [Produces("application/json")]
    [Route("/auth")]
    public class AccountController : Controller
    {
        private ISendgridMailService _mailService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        
        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration,
            ISendgridMailService mailService)
        {
            _mailService = mailService;
            _userManager = userManager;
            _signInManager = signInManager;
            this._configuration = configuration;
        }

        /// <Register>
        /// https://localhost:7105/auth/register
        /// </Requerimientos de Password: NoAlfanumerico,Uppercase,LowerCase,DigitRequired,Minimo Caracteres =6>

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

                    await _mailService.SendEmailAsync(model.Email, "Email: "+ user.Email, " Password: "+ model.Password +" fecha de creacion: "+ DateTime.Now);

                    return BuildToken(model);
                }
                else
                {
                    return BadRequest("Username or password invalid");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }

        }




        /// <Login>
        /// https://localhost:7105/auth/login
        /// </Utilizar Mail como Login account>


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(userInfo.Email, userInfo.Password, isPersistent: false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return BuildToken(userInfo);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return BadRequest(ModelState);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        private  IActionResult BuildToken(UserInfo userInfo)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
                new Claim("miValor", "Lo que yo quiera"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Llave_super_secreta"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(1);

            JwtSecurityToken tokenIn = new JwtSecurityToken(
               issuer: "localhost",
               audience: "localhost",
               claims: claims,
               expires: expiration,
               signingCredentials: creds);
               


            var tokenHandler = new JwtSecurityTokenHandler();

           // var token = tokenHandler.CreateJwtSecurityToken(tokenIn);
            var encryptedToken=tokenHandler.WriteToken(tokenIn);

            var token = encryptedToken;

            const string Xaccesstoken = "token";
            Response.Cookies.Append(Xaccesstoken, encryptedToken,new CookieOptions 
            { 
             
             Secure = true,
             HttpOnly=true ,
             SameSite=SameSiteMode.None,
             IsEssential =true,
             Expires=DateTime.Now.AddDays(1)
           
            });

            return Ok(Response.Cookies);
        }


    }
}
