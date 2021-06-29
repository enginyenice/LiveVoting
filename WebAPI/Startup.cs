using Business.Abstract;
using Business.Concreate;
using Business.Hubs;
using Business.Mapping;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace WebAPI
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
            services.Configure<MongoSettings>(Configuration.GetSection("MongoSettings"));

            services.AddSingleton<MongoSettings>(sp =>
            {
                return sp.GetRequiredService<IOptions<MongoSettings>>().Value;
            });

            services.AddCors(options => options.AddPolicy("CorsPolicy",
                    builder =>
                    {
                        builder.AllowAnyHeader()
                               .AllowAnyMethod()
                               .SetIsOriginAllowed((host) => true)
                               .AllowCredentials();
                    }));
            services.AddSingleton<IQuestionDal, QuestionDal>();
            services.AddSingleton<IAnswerDal, AnswerDal>();
            services.AddSingleton<IIpAdressDal, IpAdressDal>();

            services.AddSingleton<IQuestionService, QuestionManager>();
            services.AddSingleton<IAnswerService, AnswerManager>();
            services.AddSingleton<IIpAdressService, IpAdressManager>();

            services.AddControllersWithViews();
            services.AddAutoMapper(typeof(GeneralMapping));
            services.AddSwaggerGen();
            services.AddSignalR();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("CorsPolicy");
            app.UseSignalR(routes =>
            {
                routes.MapHub<MyHub>("/MyHub");
            });
            //app.UseCors("ReactAPPPolicy");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapHub<MyHub>("/MyHub");
                endpoints.MapControllers();
            });
        }
    }
}