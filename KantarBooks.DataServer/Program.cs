using KantarBooks.DataServer.Config;
using KantarBooks.DataServer.Data;
using KantarBooks.DataServer.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("Data/agents.json", optional: false, reloadOnChange: true);
    
#region Services
var config = builder.Configuration;
var dbConfig = config.GetSection("DbConfig").Get<DbConfig>();
var connectionString = KantarBooksContext.BuildConnectionString(dbConfig ?? new DbConfig());

builder.Services.AddDbContext<KantarBooksContext>(options => 
    options.UseSqlServer(connectionString)
);

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAgentService, AgentService>();
#endregion

#region API
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

#region Application
var app = builder.Build();

if (app.Environment.IsDevelopment()){
    app.UseHttpsRedirection();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowFrontend");
app.MapControllers();
#endregion

app.Run();