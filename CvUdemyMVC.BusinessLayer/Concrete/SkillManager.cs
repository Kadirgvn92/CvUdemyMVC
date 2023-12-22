using CvUdemyMVC.BusinessLayer.Abstract;
using CvUdemyMVC.DataAccessLayer.Abstract;
using CvUdemyMVC.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvUdemyMVC.BusinessLayer.Concrete;
public class SkillManager : ISkillService
{
    private readonly ISkillDal _skillDal;

    public SkillManager(ISkillDal skillDal)
    {
        _skillDal = skillDal;
    }

    public void TAdd(Skill entity)
    {
        _skillDal.Add(entity);
    }

    public void TDelete(Skill entity)
    {
       _skillDal.Delete(entity);
    }

    public List<Skill> TGetAll()
    {
        return _skillDal.GetAll();
    }

    public Skill TGetByID(int id)
    {
       return _skillDal.GetByID(id);
    }

    public void TUpdate(Skill entity)
    {
        _skillDal.Update(entity);
    }
}
