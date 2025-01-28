using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using quickprofixer.Services;
using QuickProFixer.Data;
using QuickProFixer.Hubs;
using QuickProFixer.Models;
using QuickProFixer.Services;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Linq;
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
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			services.AddIdentity<ApplicationUser, IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders();

			services.AddScoped<IAccountService, AccountService>();
			services.AddScoped<IAuthService, AuthService>();

			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(options =>
			{
				var key = Configuration["Jwt:Key"];
				if (string.IsNullOrEmpty(key) || key.Length < 16)
				{
					throw new InvalidOperationException("Jwt:Key is not configured or is too short.");
				}

				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ValidIssuer = Configuration["Jwt:Issuer"],
					ValidAudience = Configuration["Jwt:Issuer"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
				};
			});
			// .AddGoogle(options =>
			// {
			// 	options.ClientId = Configuration["Authentication:Google:ClientId"] ?? throw new InvalidOperationException("Google ClientId is not configured.");
			// 	options.ClientSecret = Configuration["Authentication:Google:ClientSecret"] ?? throw new InvalidOperationException("Google ClientSecret is not configured.");
			// });

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
			services.AddScoped<IAuthService, AuthService>();
			services.AddScoped<IFixerService, FixerService>();
			services.AddScoped<IFixRequestService, FixRequestService>();
			services.AddSignalR();
			services.AddScoped<IEmailService, EmailService>();
			services.AddScoped<IBookingService, BookingService>();
			services.AddScoped<IRatingService, RatingService>();
			services.AddScoped<IDashboardService, DashboardService>();
			services.AddScoped<IPaymentService, PaymentService>();
			services.AddScoped<IServiceService, ServiceService>();
			services.AddScoped<IAddressService, AddressService>();

			// Add Swagger services
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "QuickProFixer API", Version = "v1" });
			});

			// Add logging
			services.AddLogging(loggingBuilder =>
			{
				loggingBuilder.AddConsole();
				loggingBuilder.AddDebug();
			});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "QuickProFixer v1"));
			}

			app.UseHttpsRedirection();
			app.UseRouting();

			// Enable CORS
			app.UseCors("AllowSpecificOrigin");

			// Enable authentication and authorization
			app.UseAuthentication();
			app.UseAuthorization();

			// Log incoming requests
			app.Use(async (context, next) =>
			{
				logger.LogInformation($"Incoming request: {context.Request.Method} {context.Request.Path}");
				await next.Invoke();
				logger.LogInformation($"Outgoing response: {context.Response.StatusCode}");
			});

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				endpoints.MapHub<NotificationHub>("/notificationHub");

				// Log the registered endpoints
				foreach (var endpoint in endpoints.DataSources.SelectMany(ds => ds.Endpoints))
				{
					logger.LogInformation($"Registered endpoint: {endpoint.DisplayName}");
				}
			});

			// Log that the application has started
			logger.LogInformation("Application has started and is listening for requests.");
		}
	}
}