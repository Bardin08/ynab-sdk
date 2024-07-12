using Sandbox;
using YnabNet;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddYnabClient(builder.Configuration);

var app = builder.Build();
app.RegisterEndpoints();
app.Run();
