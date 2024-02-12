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
    }
}
