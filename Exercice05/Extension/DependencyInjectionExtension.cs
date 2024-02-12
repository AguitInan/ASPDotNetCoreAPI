using Exercice05.Data;
using Exercice05.Models;
using Exercice05.Repositories;
using Exercice05.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text;

namespace Exercice05.Extension
{
    public static class DependencyInjectionExtension
    {

        public static void InjectDependancies(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.addSwagger();
            builder.AddRepositories();
            builder.AddDatabase();
            builder.AddAuthentication();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
