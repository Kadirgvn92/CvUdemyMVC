using CvUdemyMVC.EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace CvUdemyMVC.DataAccessLayer.Concrete;
public class CvUdemyContext :DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-A6C5CRN\\SQLEXPRESS;initial Catalog=CvUdemyDb;integrated Security=true");
    }

    public DbSet<About> Abouts { get; set; }
    public DbSet<Certification> Certifications { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Education> Educations { get; set; }
    public DbSet<Exprience> Expriences { get; set; }
    public DbSet<Hobby> Hobbies { get; set; }
    public DbSet<Skill> Skills { get; set; }



}