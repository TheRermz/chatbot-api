using chatbot.Hubs;
using chatbot.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));

// CORS para permitir conexão com frontend (ajuste a origem se necessário)
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:5173") // porta padrão do Vite
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

// Adiciona SignalR
builder.Services.AddSignalR();

// ChatFlowService (roteamento mockado)
builder.Services.AddSingleton<ChatFlowService>(); // Vamos criar esse já já

//Injeção de Controllers
builder.Services.AddControllers();

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// HTTPS + CORS
app.UseHttpsRedirection();
app.UseCors();

//Mapeia os Controllers
app.MapControllers();

// Mapeia o Hub
app.MapHub<ChatHub>("/chatHub");



app.Run();
