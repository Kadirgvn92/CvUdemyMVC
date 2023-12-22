using CvUdemyMVC.BusinessLayer.Abstract;
using CvUdemyMVC.DataAccessLayer.Abstract;
using CvUdemyMVC.EntityLayer;

namespace CvUdemyMVC.BusinessLayer.Concrete;
public class ContactManager : IContactService
{
    private readonly IContactDal _contactDal;

    public ContactManager(IContactDal contactDal)
    {
        _contactDal = contactDal;
    }

    public void TAdd(Contact entity)
    {
        _contactDal.Add(entity);
    }

    public void TDelete(Contact entity)
    {
       _contactDal.Delete(entity);
    }

    public List<Contact> TGetAll()
    {
       return _contactDal.GetAll();
    }

    public Contact TGetByID(int id)
    {
       return _contactDal.GetByID(id);
    }

    public void TUpdate(Contact entity)
    {
        _contactDal.Update(entity);
    }
}
