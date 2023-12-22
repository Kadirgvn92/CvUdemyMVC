using CvUdemyMVC.BusinessLayer.Abstract;
using CvUdemyMVC.BusinessLayer.Concrete;
using CvUdemyMVC.DataAccessLayer.Abstract;
using CvUdemyMVC.DataAccessLayer.Concrete;
using CvUdemyMVC.DataAccessLayer.EntityFramework;
using System.Reflection;

namespace CvUdemyMVC.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<CvUdemyContext>();   //ConnectionString için register yaptýk
        builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());  //Automappper için register iþlemi yaptýk.

        builder.Services.AddScoped<IAboutService, AboutManager>();
        builder.Services.AddScoped<IAboutDal, EfAboutDal>();

        builder.Services.AddScoped<ICertificationService, CertificationManager>();
        builder.Services.AddScoped<ICertificationDal, EfCertificationDal>();

        builder.Services.AddScoped<IContactService, ContactManager>();
        builder.Services.AddScoped<IContactDal, EfContactDal>();

        builder.Services.AddScoped<IEducationService, EducationManager>();
        builder.Services.AddScoped<IEducationDal, EfEducationDal>();

        builder.Services.AddScoped<IExprienceService, ExprienceManager>();
        builder.Services.AddScoped<IExprienceDal, EfExprienceDal>();

        builder.Services.AddScoped<IHobbyService, HobbyManager>();
        builder.Services.AddScoped<IHobbyDal, EfHobbyDal>();

        builder.Services.AddScoped<ISkillService, SkillManager>();
        builder.Services.AddScoped<ISkillDal, EfSkillDal>();


        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
