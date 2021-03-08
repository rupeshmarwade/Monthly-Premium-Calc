using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TAL.AppCore.Interfaces;
using TAL.AppCore.Services;
using TAL.Infrastructure;
using TAL.Infrastructure.Data;
using TAL.WebApi.Services;
using TAL.WebApi.Validators;

namespace TAL.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<InsuranceDbContext>(options => options.UseInMemoryDatabase("Insurance"));
            services.AddScoped<IPremiumCalcService, PremiumCalcService>();

            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IMemberService, MemberService>();

            services.AddScoped<IOccupationsService, OccupationsService>();
            services.AddScoped<IOccupationRepository, OccupationRepository>();

            services.AddScoped<IPremiumService, PremiumService>();
            services.AddScoped<IPremiumService, PremiumService>();
            services.AddControllers();
            services.AddSwaggerGen(swag =>
            {
                swag.SwaggerDoc("v1", new OpenApiInfo { Title = "TAL API", Version = "1.0" });
            });

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader());
            });


            services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<MemberDtoValidator>());
            services.AddControllers()
                
                .AddNewtonsoftJson();

            //services.AddTransient<IValidator<MemberDto>, MemberDtoValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();            
            app.UseCors(options => options.WithOrigins("http://localhost:4200"));
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TAL API");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
