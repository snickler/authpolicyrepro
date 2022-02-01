using authrepro;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Server.IISIntegration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IAuthorizationHandler, SomeAuthHandler>();
builder.Services.AddAuthentication(IISDefaults.AuthenticationScheme);
builder.Services.AddAuthorization(pol =>
 {
     pol.AddPolicy("WindowsAuth",
         new AuthorizationPolicy(
             new[] {new SomeRequirement() }, 
             builder.Configuration.GetSection("AuthSchemes").GetChildren().Select(x=>x.Value)));
 });
 
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new AuthorizeFilter("WindowsAuth"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
