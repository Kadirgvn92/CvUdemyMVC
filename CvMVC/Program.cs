using CvUdemyMVC.DataAccessLayer.Concrete;
using CvUdemyMVC.EntityLayer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace CvMVC;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
        builder.Services.AddDbContext<CvUdemyContext>();
        builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<CvUdemyContext>();
        builder.Services.AddHttpClient();
        // Add services to the container.
        builder.Services.AddControllersWithViews(opt =>
        {
            opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
        });

        builder.Services.ConfigureApplicationCookie(opt =>
        {
            opt.LoginPath = "/Login/Index/";
        });
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

        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Default}/{action=Index}/{id?}");

        app.Run();
    }
}