
using BudgettingInfrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

ServiceConfigurationContainer.EnsureDbCreation();
ServiceConfigurationContainer.SetConnectionString(builder.Configuration);
ServiceConfigurationContainer.RegisterConnections(builder.Services, builder.Configuration);
ServiceConfigurationContainer.ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseDeveloperExceptionPage();


}

ServiceConfigurationContainer.Configure(app);


app.MapControllerRoute(name: "dafault", pattern: "{controller}/{action?}/{id?}");

app.MapControllers();


app.Run();