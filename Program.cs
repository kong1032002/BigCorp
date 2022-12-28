using BigCorp.Datas;
using BigCorp.Models;
using BigCorp.Repository;
using BigCorp.Repository.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(
    options => options.AddDefaultPolicy(
        policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

// Database
builder.Services.AddDbContext<BigCorpContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("SQLAuth"));
    });

// Repository
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IItemRepository<ProductModel>, ProductRepository>();
builder.Services.AddScoped<IItemRepository<ProductLineModel>, ProductLineRepository>();
builder.Services.AddScoped<IItemRepository<StockModel>, StockRepository>();
builder.Services.AddScoped<IItemRepository<StorageModel>, StorageRepository>();


// Authetication
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<BigCorpContext>().AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            builder.Configuration["JWT:Secret"]))
    };
});

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
