
using BudgettingInfrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



ConfigureServiceContainer.EnsureDbCreation();
ConfigureServiceContainer.SetConnectionString(builder.Configuration);
ConfigureServiceContainer.RegisterConnections(builder.Services, builder.Configuration);
ConfigureServiceContainer.ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
   
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseIdentityServer();

app.MapControllerRoute(name: "dafault", pattern: "{controller}/{action=Index}/{id?}");

app.MapControllers();

app.Run();
