var builder = WebApplication.CreateBuilder(args);

// Swagger 및 OpenAPI 설정
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.AddApplicationServices();
builder.AddInfrastructureServices();

builder.Services.AddOpenApi();
builder.Services.AddControllers();
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

