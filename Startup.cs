using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using QuickProFixer.Data;
using QuickProFixer.Hubs;
using QuickProFixer.Models;
using QuickProFixer.Services;
using System;
using System.Text;

namespace QuickProFixer
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			// Configure database context
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found."),
				sqlServerOptions => sqlServerOptions.EnableRetryOnFailure()));

			// Configure Identity
			services.AddIdentity<ApplicationUser, IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders();

			// Configure JWT Authentication
			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(options =>
			{
				var key = Configuration["Jwt:Key"];
				if (string.IsNullOrEmpty(key))
				{
					throw new InvalidOperationException("Jwt:Key is not configured.");
				}

				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ValidIssuer = Configuration["Jwt:Issuer"],
					ValidAudience = Configuration["Jwt:Audience"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
				};
			})
			.AddGoogle(options =>
			{
				options.ClientId = Configuration["Authentication:Google:ClientId"] ?? throw new InvalidOperationException("Google ClientId is not configured.");
				options.ClientSecret = Configuration["Authentication:Google:ClientSecret"] ?? throw new InvalidOperationException("Google ClientSecret is not configured.");
			});

			// Add CORS services
			services.AddCors(options =>
			{
				options.AddPolicy("AllowSpecificOrigin",
					builder => builder
						.WithOrigins("http://localhost:5173") // Add your frontend URL here
						.AllowAnyHeader()
						.AllowAnyMethod());
			});

			// Register HttpClient
			services.AddHttpClient();


			// Add services to the container.
			services.AddControllers();

			// Dependency Injection for custom services
			services.AddScoped<IAccountService, AccountService>();
			services.AddScoped<IProfileService, ProfileService>();
			services.AddScoped<IAdminService, AdminService>();
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IFixerService, FixerService>();
			services.AddScoped<IFixRequestService, FixRequestService>();
			services.AddSignalR();
			services.AddScoped<IEmailService, EmailService>();
			services.AddScoped<IBookingService, BookingService>();
			services.AddScoped<IRatingService, RatingService>();
			services.AddScoped<IDashboardService, DashboardService>();
			services.AddScoped<IPaymentService, PaymentService>();

			// Add logging

			services.AddLogging();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			// Enable CORS
			app.UseCors("AllowSpecificOrigin");

			// Enable authentication and authorization
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				endpoints.MapHub<NotificationHub>("/notificationHub");
			});
		}
	}
}
