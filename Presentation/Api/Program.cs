using Application;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddJWTTokenServices(builder.Configuration);
builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// app.Environment.IsDevelopment()
if (true)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
