using Microsoft.Extensions.DependencyInjection;
using ytech.labs.tasks.lib.Struct;

var builder = WebApplication.CreateBuilder(args);

#region Configurations
var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

builder.Configuration.AddJsonFile("Configurations/MongoDbConfig.json",optional: false,reloadOnChange: true)
    .AddJsonFile($"Configurations/MongoDbConfig.{environment}.json",optional: true, reloadOnChange:  true);
#endregion

// Add services to the container.
builder.Services.Configure<MongoDbConfig>(builder.Configuration);

builder.Services.AddControllers().AddNewtonsoftJson();
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

