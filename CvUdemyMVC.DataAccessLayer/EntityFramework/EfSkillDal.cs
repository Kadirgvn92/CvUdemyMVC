using CvUdemyMVC.DataAccessLayer.Abstract;
using CvUdemyMVC.DataAccessLayer.Concrete;
using CvUdemyMVC.DataAccessLayer.Repositories;
using CvUdemyMVC.EntityLayer;

namespace CvUdemyMVC.DataAccessLayer.EntityFramework;
public class EfSkillDal : GenericRepository<Skill>, ISkillDal
{
    public EfSkillDal(CvUdemyContext context) : base(context)
    {
    }
}
