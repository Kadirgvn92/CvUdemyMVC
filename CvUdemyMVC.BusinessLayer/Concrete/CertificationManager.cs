using CvUdemyMVC.BusinessLayer.Abstract;
using CvUdemyMVC.DataAccessLayer.Abstract;
using CvUdemyMVC.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvUdemyMVC.BusinessLayer.Concrete;
public class CertificationManager : ICertificationService
{
    private readonly ICertificationDal _certificationDal;

    public CertificationManager(ICertificationDal certificationDal)
    {
        _certificationDal = certificationDal;
    }

    public void TAdd(Certification entity)
    {
       _certificationDal.Add(entity);
    }

    public void TDelete(Certification entity)
    {
        _certificationDal.Delete(entity);
    }

    public List<Certification> TGetAll()
    {
        return _certificationDal.GetAll();
    }

    public Certification TGetByID(int id)
    {
        return _certificationDal.GetByID(id);
    }

    public void TUpdate(Certification entity)
    {
        _certificationDal.Update(entity);
    }
}
