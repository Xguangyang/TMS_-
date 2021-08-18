using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS_Smart_logistics.Repository;
using TMS_Smart_logistics.IRepository;
using TMS_Smart_logistics.Common;
using Autofac;
using System.Reflection;
using System.IO;

namespace TMS_Smart_logistics.Api
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
            ConnString.connstring = Configuration.GetConnectionString("Default");



            services.AddTransient<ILogin, User_logins>();
            services.AddTransient<IDepartmentModel, DepartmentModel>();
            services.AddTransient<IRoleModel, RoleModel>();
            services.AddControllers();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "TMS_Smart_logistics.API",
                    Version = "v1",
                    Description = "TMS_Smart_logistics API"
                }
                );
                c.SwaggerDoc("v2", new OpenApiInfo
                {
                    Version = "v1.0",
                    Title = "�����ӿ�",
                    Description = "�û���¼��֤�ӿ�"
                });

                // Ϊ Swagger ����xml�ĵ�ע��·��
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                // ��ӿ�������ע�ͣ�true��ʾ��ʾ������ע��
                c.IncludeXmlComments(xmlPath, true);

            });

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TMS_Smart_logistics.Api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
        public void ConfigureContainer(ContainerBuilder build)
        {
            var bllFilePath = System.IO.Path.Combine(AppContext.BaseDirectory, "TMS_Smart_logistics.Repository.dll"); //DDal.dll������ע��Ĳ�
            build.RegisterAssemblyTypes(Assembly.LoadFile(bllFilePath)).AsImplementedInterfaces();
        }


    }
}
