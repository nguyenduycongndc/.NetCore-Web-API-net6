using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectTest.Data;
using ProjectTest.Repo.Interface;
using ProjectTest.Repo;
using ProjectTest.Services.Interface;
using ProjectTest.Services;
using Microsoft.OpenApi.Models;
using ProjectTest.Tool.ServicesTool.IServicesTool;
using ProjectTest.Tool.ServicesTool;
using ProjectTest.Tool;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSession();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddDbContext<SqlDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlDbConnectionString")));

builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IUserService, UserServices>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<ISendMailService, SendMailService>();

builder.Services.AddSingleton<IWorker, Worker>();
builder.Services.AddHostedService<DerivedBackgroundPrinter>();
//builder.Services.AddHostedService<BackgroundPrinter>();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();


app.UseSession();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();    
app.UseAuthorization();

app.MapControllers();

app.Run();

app.UseSession();
