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
public class EfEducationDal : GenericRepository<Education>, IEducationDal
{
    public EfEducationDal(CvUdemyContext context) : base(context)
    {
    }
}
