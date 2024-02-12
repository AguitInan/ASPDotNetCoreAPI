using Exercice05.Data;
using Exercice05.DTOs;
using Exercice05.Helpers;
using Exercice05.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Exercice05.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly AppDbContext _appDbContext1;
        private AppSettings _appSettings1;


        public AuthenticationController(AppDbContext appDbContext, IOptions<AppSettings> appSettings)
        {

            _appDbContext1 = appDbContext;
            _appSettings1 = appSettings.Value;

        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {

            if (await _appDbContext1.Users.FirstOrDefaultAsync(u => u.Email == user.Email) != null)
                return BadRequest("Email exist");

            user.Password = PasswordCrypter.Encrypt(user.Password, _appSettings1.SecretKey);

            await _appDbContext1.AddAsync(user);

            if (await _appDbContext1.SaveChangesAsync() > 0) return Ok("User crée");
            return BadRequest("Probleme creation User");

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto login)
        {
            login.Password = PasswordCrypter.Encrypt(login.Password, _appSettings1.SecretKey!);

            var user = await _appDbContext1.Users.FirstOrDefaultAsync(u => u.Email == login.Email && u.Password == login.Password);

            if (user == null) return BadRequest("Invalid Authentication !");

            var role = user.IsAdmin ? Constants.RoleAdmin : Constants.RoleUser;

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Role, role),
                new Claim("Userid",user.Id.ToString())

            };


            SigningCredentials signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appSettings1.SecretKey!)), SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwt = new JwtSecurityToken(
                claims: claims,
                issuer: _appSettings1.ValidIssuer,
                audience: _appSettings1.ValidAudience,
                signingCredentials: signingCredentials,
                expires: DateTime.Now.AddHours(2));

            string token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return Ok(new
            {
                Token = token,
                Message = "Authentication Succefull !!",
                User = user
            });



        }





    }
}
