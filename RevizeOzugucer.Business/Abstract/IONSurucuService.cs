using RevizeOzugucer.Core.Utilities.Results;
using RevizeOzugucer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RevizeOzugucer.Business.Abstract
{
    public interface IONSurucuService
    {
        IDataResult<List<ONSurucu>> GetAll();
        IDataResult<List<ONSurucu>> GetAllNonDeleted();
        IDataResult<List<ONSurucu>> GetAllDeleted();
        IDataResult<List<string>> GetOnlySurucuNames();
        IDataResult<ONSurucu> GetBySurucuId(int id);
        IDataResult<int> Count();
        IResult Add(ONSurucu surucu);
        IResult Update(ONSurucu surucu);
        IResult Delete(int id);
    }
}
