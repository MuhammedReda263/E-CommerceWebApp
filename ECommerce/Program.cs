﻿
using ECommerce.DataAccess.Data;
using ECommerce.DataAccess.Repository;
using ECommerce.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ECommerce.Utility;
using Microsoft.AspNetCore.Identity.UI.Services;
using ECommerce.Models;
using Stripe;

namespace ECommerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer (builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.Configure<StripSettings>(builder.Configuration.GetSection("Stripe")); // configure stripe


            builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/identity/Account/Login"; // لو المستخدم مش مسجل دخول
                options.AccessDeniedPath = "/identity/Account/AccessDenied"; // لو هو مسجل دخول لكن مش عنده صلاحية
                options.LogoutPath = "/identity/account/logout";
            });
            builder.Services.AddScoped <IUnitOfWork , UnitOfWork>();
            builder.Services.AddScoped<IEmailSender, EmailSender>(); // <=
            builder.Services.AddRazorPages();// Mean that we will use razor pages
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:SecretKey")?.Value;
            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();
            app.MapRazorPages(); // 
            app.MapControllerRoute(
                name: "default",
                pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
