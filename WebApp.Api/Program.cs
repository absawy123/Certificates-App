
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApp.Application.Mappers;
using WebApp.Application.Services;
using WebApp.Core.Interfaces;
using WebApp.Core.models;
using WebApp.Infrastructure.persistence;
using WebApp.Infrastructure.Repositories;

namespace WebApp.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
          //  builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("constr")));


            var hexKey = builder.Configuration["Jwt:Key"];
            var keyBytes = Convert.FromHexString(hexKey);

            builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
            })
                   .AddEntityFrameworkStores<AppDbContext>()
                   .AddDefaultTokenProviders();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                   .AddJwtBearer(options =>
                   {
                       options.RequireHttpsMetadata = false;
                       options.SaveToken = true;
                       options.TokenValidationParameters = new TokenValidationParameters
                       {
                           ValidateIssuerSigningKey = true,
                           IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
                           ValidateIssuer = true,
                           ValidateAudience = true,
                           ValidIssuer = builder.Configuration["Jwt:Issuer"],
                           ValidAudience = builder.Configuration["Jwt:Audience"],
                           ClockSkew = TimeSpan.Zero
                       };
                   });

            builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<CertificateService>();
            builder.Services.AddScoped<CertificateTitleService>();
            builder.Services.AddScoped<CertificateTypeService>();
            builder.Services.AddScoped<InspectedItemService>();
            builder.Services.AddScoped<JobService>();
            builder.Services.AddScoped<LocationService>();
            builder.Services.AddScoped<ReferenceService>();


            // registure Mappers
            builder.Services.AddAutoMapper(typeof(CertificateProfile).Assembly);


            var app = builder.Build();
            //app.UseCors("AllowAll");

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();
            app.Run();
        }
    }
}
