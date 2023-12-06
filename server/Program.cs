using UniversityProcessing.API;

var builder = WebApplication.CreateBuilder(args);

builder.AddCustomServices();

var app = builder.Build();

app.MigrateDb();

app.UseCustomServices();

app.Run();
