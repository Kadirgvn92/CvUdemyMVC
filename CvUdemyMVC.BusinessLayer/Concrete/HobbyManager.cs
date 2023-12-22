using CvUdemyMVC.BusinessLayer.Abstract;
using CvUdemyMVC.DataAccessLayer.Abstract;
using CvUdemyMVC.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvUdemyMVC.BusinessLayer.Concrete;
public class HobbyManager : IHobbyService
{
    private readonly IHobbyDal _hobbyDal;
    public void TAdd(Hobby entity)
    {
        _hobbyDal.Add(entity);
    }

    public void TDelete(Hobby entity)
    {
        _hobbyDal.Delete(entity);
    }

    public List<Hobby> TGetAll()
    {
        return _hobbyDal.GetAll();  
    }

    public Hobby TGetByID(int id)
    {
        return _hobbyDal.GetByID(id);
    }

    public void TUpdate(Hobby entity)
    {
       _hobbyDal.Update(entity);
    }
}
