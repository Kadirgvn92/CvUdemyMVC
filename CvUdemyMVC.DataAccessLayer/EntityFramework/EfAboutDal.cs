using CvUdemyMVC.DataAccessLayer.Abstract;
using CvUdemyMVC.DataAccessLayer.Concrete;
using CvUdemyMVC.DataAccessLayer.Repositories;
using CvUdemyMVC.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvUdemyMVC.DataAccessLayer.EntityFramework;
public class EfAboutDal : GenericRepository<About>, IAboutDal
{
    public EfAboutDal(CvUdemyContext context) : base(context)
    {
    }
}
