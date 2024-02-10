using ContactApiDTO.Data;
using ContactApiDTO.Models;
using ContactApiDTO.Repositories;
using ContactApiDTOAsync.Extension;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.InjectDependancies();


//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("allConnections", options =>
//    {
//        options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
//    });
//    options.AddPolicy("angularApp", options =>
//    {
//        options.WithOrigins("https://angularadress:angularport").WithMethods("GET").WithHeaders("application/json");
//    });
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// c'est ici que l'on va utiliser le middleware des cors (cross-origin requests)
// on le laisse vide lorsque l'on utilise des policy sur nos contrôlleurs/actions (ne pas oublier le service de configuration des cors)
// on peut aussi préciser une policy qui s'appliquera sur toute l'application avec son nom
//app.UseCors("allConnections");
// cette version permet d'appliquer une policy globale sans la nommer:
app.UseCors(options =>
{
    options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
