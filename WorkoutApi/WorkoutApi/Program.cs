using WorkoutApi.Repositories;
using WorkoutApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<DatabaseConnection>(provider =>
{
    var settings = new DatabaseConnectionSettings
    {
        DataSource = Environment.GetEnvironmentVariable("DB_DATASOURCE"),
        InitialCatalog = Environment.GetEnvironmentVariable("DB_INITIALCATALOG"),
        UserID = Environment.GetEnvironmentVariable("DB_USERID"),
        Password = Environment.GetEnvironmentVariable("DB_PASSWORD")
    };

    return new DatabaseConnection(settings);
});


builder.Services.AddControllers();
builder.Services.AddScoped<IHelloWorldRepository, HelloWorldRepository>();
builder.Services.AddScoped<IHelloWorldRepository, HelloWorldRepository>();
builder.Services.AddScoped<IHelloWorldService, HelloWorldService>();
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
