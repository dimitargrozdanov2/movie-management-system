﻿using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieManagement.Data;
using MovieManagement.DataModels;
using MovieManagement.Infrastructure;
using MovieManagement.Services;
using MovieManagement.Services.Contracts;
using MovieManagement.Utilities;
using MovieManagement.Wrappers;

namespace MovieManagement
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            this.Configuration = configuration;
            this.Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<MovieManagementContext>(options =>
                options.UseSqlServer(this.Configuration.GetConnectionString("DConnection")));

            if (this.Environment.IsDevelopment())
            {
                services.Configure<IdentityOptions>(options =>
                {
                    // Password configuration
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 1;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequiredUniqueChars = 0;
                });
            }

            // we register them as scoped because services are using dbcontext, which should be the same for during the operation.
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IWatchlistService, WatchlistService>();
            services.AddScoped<INewsService, NewsService>();
            services.AddScoped<IActorService, ActorService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IMappingProvider, MappingProvider>();
            services.AddScoped<IUserManagerWrapper, UserManagerWrapper>();
            services.AddScoped<IRoleManagerWrapper, RoleManagerWrapper>();

            services.AddCors();

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddRoleManager<RoleManager<IdentityRole>>()
                .AddEntityFrameworkStores<MovieManagementContext>()
                .AddDefaultTokenProviders();

            services.AddMemoryCache();

            services.AddAutoMapper();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.CustomExceptionHandling();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseCors();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "admin",
                    template: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                //routes.MapRoute(
                //   name: "notfound",
                //   template: "{*url}",
                //   defaults: new { controller = "Home", action = "ServerError" });
            });
        }
    }
}