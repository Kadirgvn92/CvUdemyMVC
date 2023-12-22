using CvUdemyMVC.BusinessLayer.Abstract;
using CvUdemyMVC.DataAccessLayer.Abstract;
using CvUdemyMVC.EntityLayer;

namespace CvUdemyMVC.BusinessLayer.Concrete;
public class EducationManager : IEducationService
{
    private readonly IEducationDal _educationDal;

    public EducationManager(IEducationDal educationDal)
    {
        _educationDal = educationDal;
    }

    public void TAdd(Education entity)
    {
        _educationDal.Add(entity);
    }

    public void TDelete(Education entity)
    {
        _educationDal.Delete(entity);
    }

    public List<Education> TGetAll()
    {
        return _educationDal.GetAll();  
    }

    public Education TGetByID(int id)
    {
        return _educationDal.GetByID(id);
    }

    public void TUpdate(Education entity)
    {
        _educationDal.Update(entity);
    }
}
