/*
 *              ����session
 * 1�� services.AddDistributedMemoryCache(); ���÷ֲ�ʽ���棬��Ϊ��Ҫ�ڷ���˴洢session����
 * 2�� services.AddSession(); ע��session����
 * 3�� app.UseSession(); ��Ҫ���������棬���򱨴�
 * 4�� ��װ Microsoft.AspNetCore.Session ��
 */
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace Demo.AspNetCoreApiTestSession
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo.AspNetCoreApiTestSession", Version = "v1" });
            });          
            services.AddDistributedMemoryCache();
            services.AddSession(p =>
            {               
                p.Cookie.Name = "sessionname";
                //p.Cookie.Expiration = TimeSpan.FromMinutes(1); ����ᱨ��
                p.IdleTimeout = TimeSpan.FromSeconds(20);//����session�Ĺ���ʱ��,
                p.Cookie.HttpOnly = true; //���������������ͨ��js��ø�cookie��ֵ
            }
                
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSession();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Demo.AspNetCoreApiTestSession v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });          
        }
    }
}
