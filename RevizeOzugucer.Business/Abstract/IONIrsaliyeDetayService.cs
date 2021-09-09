using RevizeOzugucer.Core.Utilities.Results;
using RevizeOzugucer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RevizeOzugucer.Business.Abstract
{
    public interface IONIrsaliyeDetayService
    {
        IDataResult<List<ONIrsaliyeDetay>> GetAll();
        IDataResult<List<ONIrsaliyeDetay>> GetAllNonDeleted();
        IDataResult<List<ONIrsaliyeDetay>> GetAllDeleted();
        IDataResult<List<ONIrsaliyeDetay>> GetByIrsaliyeId(int id);
        IDataResult<ONIrsaliyeDetay> Get(int id);
        IDataResult<int> Count();
        IResult Add(ONIrsaliyeDetay irsaliyeDetay);
        IResult Update(ONIrsaliyeDetay irsaliyeDetay);
        IResult Delete(int id);
    }
}
