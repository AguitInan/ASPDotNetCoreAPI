using ContactApiDTO.Data;
using ContactApiDTOAsync.DTOs;
using ContactApiDTOAsync.Helpers;
using ContactApiDTOAsync.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ContactApiDTOAsync.Controllers
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
