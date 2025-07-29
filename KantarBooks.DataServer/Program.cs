using KantarBooks.DataServer.Config;
using KantarBooks.DataServer.Data;
using KantarBooks.DataServer.Data.Repository;
using KantarBooks.DataServer.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

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
        policy.WithOrigins("http://localhost:5173") // URL where React runs
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpYXQiOjE1MTYyMzkwMjJ9.xbdL7b8XRYCyJ4j8IpD3EXnwYoiX7MU1lgYp0Z9vltk"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            Array.Empty<string>()
        }
    });
});

//Comment this to deactivate Jwt Authorization.
// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//     .AddJwtBearer(jwtOpt => {
//         jwtOpt.TokenValidationParameters = new TokenValidationParameters() {
//             ValidateIssuer = false,
//             ValidateAudience = false,
//             ValidateLifetime = false,
//             ValidateIssuerSigningKey = true,
//             IssuerSigningKey = new SymmetricSecurityKey(
//                 Encoding.UTF8.GetBytes(builder.Configuration["JwtSecret"] ?? "a-string-secret-at-least-256-bits-long"))
//         };
// });
#endregion

#region Application
var app = builder.Build();

if (app.Environment.IsDevelopment()){
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");
app.MapControllers();

//app.UseAuthorization();
//app.UseAuthentication();
#endregion

app.Run();