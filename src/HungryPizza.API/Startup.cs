using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using HungryPizza.Domain.Commands.Order;
using HungryPizza.Domain.Commands.User;
using HungryPizza.Domain.Infra.Contexts;
using HungryPizza.Domain.Infra.Repositories;
using HungryPizza.Domain.Interfaces.Repositories;
using System.Text;

namespace HungryPizza
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AddAuthentication(services);
            services.AddControllers()
                .AddNewtonsoftJson();
            services.AddMvc()
                .AddFluentValidation();
            services.AddCors();
            services.AddDbContext<HungryPizzaContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnectionString")));

            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IAddressRepository, addressRepository>();
            services.AddTransient<IPizzaRepository, PizzaRepository>();
            services.AddTransient<IFlavorRepository, FlavorRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HungryPizza", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Por favor, entre com a palavra 'Bearer' seguido de espaço e o token JWT.",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
            });
            services.AddMediatR(typeof(NewOrderCommand).Assembly);
            services.AddMediatR(typeof(NewUserCommand).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HungryPizza V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
                var dbContextAccount = serviceScope.ServiceProvider.GetRequiredService<HungryPizzaContext>();
                dbContextAccount.Database.Migrate();
            }



            app
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }

        private void AddAuthentication(IServiceCollection services)
        {
            byte[] key = Encoding.ASCII.GetBytes("hungry@bearerKey-_-2123131");
            services
            .AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });
        }
    }
}
