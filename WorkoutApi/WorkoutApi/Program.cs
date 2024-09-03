using Microsoft.Data.SqlClient;
using WorkoutApi.Repositories;
using WorkoutApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Register the SQL connection
builder.Services.AddScoped<SqlConnection>(sp =>
{
    var builder = new SqlConnectionStringBuilder
    {
        DataSource = Environment.GetEnvironmentVariable("DB_DATASOURCE"),
        InitialCatalog = Environment.GetEnvironmentVariable("DB_INITIALCATALOG"),
        UserID = Environment.GetEnvironmentVariable("DB_USERID"),
        Password = Environment.GetEnvironmentVariable("DB_PASSWORD"),
        IntegratedSecurity = false,
        TrustServerCertificate = true,
    };
    return new SqlConnection(builder.ConnectionString);
});

// Add services to the container.
builder.Services.AddControllers();
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
