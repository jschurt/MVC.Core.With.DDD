using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Solution.Application.Interfaces;
using Solution.Application.Services;
using Solution.Domain.Interfaces.Repositories;
using Solution.Domain.Interfaces.Services;
using Solution.Domain.Services;
using Solution.Infraestructure.Data.Context;
using Solution.Infraestructure.Data.Repositories;

namespace Solution.WebUI
{

    public class Startup
    {

        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        } //constructor


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            //Add Context
            string strConnString = _configuration["ConnectionStrings:DefaultConnection"];

            services.AddDbContext<SolutionContext>(options =>
                options.UseSqlServer(strConnString)
            );

            //Add support automapper
            services.AddAutoMapper();

            //Add support for mvc
            services.AddMvc();

            //Add app services
            services.AddScoped<IClienteAppService, ClienteAppService>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();


            //Add domain services
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IProdutoService, ProdutoService>();

            //Add repositories
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

        } //configugeServices

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            } //if

            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseMvcWithDefaultRoute();

        } //Configure

    } //class

} //namespace
