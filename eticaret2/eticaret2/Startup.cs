using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eticaret.DataAccess;
using eticaret.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
namespace eticaret2
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
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("Appsettings:Token").Value);
            services.Configure<CloudinarySettings>(Configuration.GetSection("CloudinarySettings"));
            services.AddDbContext<MeerschaumContext2>(x =>
#if DEBUG
  x.UseSqlServer(Configuration.GetConnectionString("DefaultConnectiondebug")));
#else
  x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
#endif



            services.AddMvc().AddJsonOptions(opt =>
            {
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            services.AddCors();
            services.AddScoped<IProductDal, EFProductDal>();
            services.AddScoped<IPhotosDal, EFPhotoDal>();
            services.AddScoped<ICategoryDal, EFCategoryDal>();
            services.AddScoped<ISalesedDal, EFSelesedDal>();
            services.AddScoped<IUsersDal, EFUsersDal>();
            services.AddScoped<IMotherCategoryDal, EFMotherCategoryDal>();
            services.AddScoped<IUnderCategoryDal, EFUnderCategoryDal>();
            services.AddScoped<IAuthRepository, EFAuthRepositoryDal>();
            services.AddHostedService<TimedHostedService>();
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });




            //services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
            //                                                        .AllowAnyMethod()
            //                                                         .AllowAnyHeader()));
            //services.AddMvc();









        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            //app.UseCors("AllowMyOrigin");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc(config =>
            {
                config.MapRoute("DefaultRoute", "api/{controller}/{action}");


            });
        }
    }
}
