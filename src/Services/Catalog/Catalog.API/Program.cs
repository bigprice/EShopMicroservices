
using BuildingBlocks.Behaviors;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddCarter();
builder.Services.AddMediatR(config => {
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
    config.AddOpenBehavior(typeof(ValidaitonBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

builder.Services.AddMarten(opts =>
{
    var connection = builder.Configuration.GetConnectionString("Database");
    opts.Connection(connection!);

    var tets = string.Empty;
    //opts.AutoCreateSchemaObjects
}).UseLightweightSessions();

var app = builder.Build();

// Configure the HTTP request pipeline
app.MapCarter();

app.Run();
