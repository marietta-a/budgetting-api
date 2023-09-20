
using BudgettingInfrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



ServiceConfigurationContainer.EnsureDbCreation();
ServiceConfigurationContainer.SetConnectionString(builder.Configuration);
ServiceConfigurationContainer.RegisterConnections(builder.Services, builder.Configuration);
ServiceConfigurationContainer.ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
    

}

ServiceConfigurationContainer.Configure(app);


app.Run();