var builder = WebApplication.CreateBuilder(args);

//Politica CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "ABIRU",
        builder =>
        {
            builder.WithOrigins("https://localhost:7053")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowAnyOrigin();
        });
});

// Add services to the container.
builder.Services.AddControllers();
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

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
