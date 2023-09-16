using BusinessLogicLayer;
using DataAccessLayer;
using Interfaces;
using Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//----------------------------------------------------------------

builder.Services.AddScoped<ICurveDataService, CurveDataService>();

// Populate properties of the MongoDbSettings.cs from the configuration file.
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDb"));

// Select one of the following data service.

// builder.Services.AddSingleton<IDataService, MongoDBService>();

// builder.Services.AddSingleton<IDataService, FakeCurveDataService>();

builder.Services.AddSingleton<IDataService, JsonFileService>(provider => 
    new JsonFileService(builder.Configuration.GetValue<string>("JsonFileSetting:JsonFilePath")));

//----------------------------------------------------------------

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
