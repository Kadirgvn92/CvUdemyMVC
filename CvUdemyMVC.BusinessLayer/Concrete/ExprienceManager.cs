using CvUdemyMVC.BusinessLayer.Abstract;
using CvUdemyMVC.DataAccessLayer.Abstract;
using CvUdemyMVC.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvUdemyMVC.BusinessLayer.Concrete;
public class ExprienceManager : IExprienceService
{
    private readonly IExprienceDal _exprienceDal;

    public ExprienceManager(IExprienceDal exprienceDal)
    {
        _exprienceDal = exprienceDal;
    }

    public void TAdd(Exprience entity)
    {
        _exprienceDal.Add(entity);
    }

    public void TDelete(Exprience entity)
    {
        _exprienceDal.Delete(entity);
    }

    public List<Exprience> TGetAll()
    {
        return _exprienceDal.GetAll();
    }

    public Exprience TGetByID(int id)
    {
        return _exprienceDal.GetByID(id);
    }

    public void TUpdate(Exprience entity)
    {
        _exprienceDal.Update(entity);
    }
}
