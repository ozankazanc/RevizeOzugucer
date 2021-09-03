using RevizeOzugucer.Core.Utilities.Results;
using RevizeOzugucer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RevizeOzugucer.Business.Abstract
{
    public interface IONPlakaService
    {
        IDataResult<List<ONPlaka>> GetAll();
        IDataResult<List<ONPlaka>> GetAllNonDeleted();
        IDataResult<List<ONPlaka>> GetAllDeleted();
        IDataResult<ONPlaka> GetByPlakaId(int id);
        IDataResult<ONPlaka> GetByPlakaArac(string plaka);
        IDataResult<int> Count();
        IResult Add(ONPlaka plaka);
        IResult Update(ONPlaka plaka);
        IResult Delete(int id);
    }
}
