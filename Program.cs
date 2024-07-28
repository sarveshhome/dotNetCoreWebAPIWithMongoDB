using DotNetCoreWebAPIWithMongoDB.DB;
using DotNetCoreWebAPIWithMongoDB.Serivecs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<MongoDBContext>(x =>
{
    var configuration = x.GetService<IConfiguration>();
    var connectionString = configuration["MongoDB:ConnectionString"];
    var databaseName = configuration["MongoDB:DatabaseName"];
    return new MongoDBContext(connectionString, databaseName);
});
builder.Services.AddSingleton<StudentService>();

builder.Services.AddControllers(); // Add this line
// Learn more about configuring Swagger/OpenAPI at (link unavailable)
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
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();