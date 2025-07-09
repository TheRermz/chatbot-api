using chatbot.Hubs;
using chatbot.Services;
using chatbot.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

DotNetEnv.Env.Load();

//conn str

var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbPort = Environment.GetEnvironmentVariable("DB_PORT");
var dbName = Environment.GetEnvironmentVariable("DB_DATABASE");
var dbUser = Environment.GetEnvironmentVariable("DB_USER");
var dbPass = Environment.GetEnvironmentVariable("DB_PASSWD");

var connectionString = $"Host={dbHost};Port={dbPort};Database={dbName};Username={dbUser};Password={dbPass}";


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

//Carrega o banco de dados
builder.Services.AddDbContext<ChatbotDbContext>(options =>
    options.UseNpgsql(connectionString));


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
