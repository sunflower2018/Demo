/*
 *              启用session
 * 1、 services.AddDistributedMemoryCache(); 启用分布式缓存，因为需要在服务端存储session对象
 * 2、 services.AddSession(); 注册session服务
 * 3、 app.UseSession(); 不要放在最下面，否则报错
 * 4、 安装 Microsoft.AspNetCore.Session 包
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
                //p.Cookie.Expiration = TimeSpan.FromMinutes(1); 这个会报错
                p.IdleTimeout = TimeSpan.FromSeconds(20);//设置session的过期时间,
                p.Cookie.HttpOnly = true; //设置在浏览器不能通过js获得该cookie的值
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
