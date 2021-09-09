using RevizeOzugucer.Business.Abstract;
using RevizeOzugucer.Business.Constant;
using RevizeOzugucer.Core.Utilities.Results;
using RevizeOzugucer.DataAccess.Abstract;
using RevizeOzugucer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RevizeOzugucer.Business.Concrete
{
    public class ONIrsaliyeDetayManager : IONIrsaliyeDetayService
    {
        IONIrsaliyeDetayDal _irsaliyeDetayDal;

        public ONIrsaliyeDetayManager(IONIrsaliyeDetayDal irsaliyeDetayDal)
        {
            _irsaliyeDetayDal = irsaliyeDetayDal;
        }

        public IResult Add(ONIrsaliyeDetay irsaliyeDetay)
        {
            _irsaliyeDetayDal.Add(irsaliyeDetay);

            return new SuccessResult(Messages.IrsaliyeDetay.IrsaliyeDetayAdded);
        }

        public IDataResult<int> Count()
        {
            return new SuccessDataResult<int>(_irsaliyeDetayDal.GetAll().Count);
        }

        public IResult Delete(int id)
        {
            var result = Get(id);

            result.Data.Sil = true;
            _irsaliyeDetayDal.Update(result.Data);

            return new SuccessResult(Messages.IrsaliyeDetay.IrsaliyeDetayDeleted);
        }

        public IDataResult<List<ONIrsaliyeDetay>> GetAll()
        {
            return new SuccessDataResult<List<ONIrsaliyeDetay>>(_irsaliyeDetayDal.GetAll(), Messages.IrsaliyeDetay.IrsaliyeDetayGetAll);
        }

        public IDataResult<List<ONIrsaliyeDetay>> GetAllDeleted()
        {
            return new SuccessDataResult<List<ONIrsaliyeDetay>>(_irsaliyeDetayDal.GetAll(x => x.Sil == true), Messages.IrsaliyeDetay.IrsaliyeDetayGetAll);
        }

        public IDataResult<List<ONIrsaliyeDetay>> GetAllNonDeleted()
        {
            return new SuccessDataResult<List<ONIrsaliyeDetay>>(_irsaliyeDetayDal.GetAll(x => x.Sil == false), Messages.Surucu.SurucuGetAll);
        }

        public IDataResult<ONIrsaliyeDetay> Get(int id)
        {
            var result = _irsaliyeDetayDal.Get(x => x.IrsaliyeDetayId == id);

            if (result == null)
            {
                return new ErrorDataResult<ONIrsaliyeDetay>(data: null, Messages.IrsaliyeDetay.IrsaliyeDetayNotFound);
            }

            return new SuccessDataResult<ONIrsaliyeDetay>(result, Messages.Surucu.SurucuGet);
        }

        public IDataResult<List<ONIrsaliyeDetay>> GetByIrsaliyeId(int id)
        {
            var result = _irsaliyeDetayDal.GetAll(x => x.IrsaliyeId == id && x.Sil == false);
            
            if (result == null)
            {
                return new ErrorDataResult<List<ONIrsaliyeDetay>>(data: null, Messages.Irsaliye.IrsaliyeNotFound);
            }

            return new SuccessDataResult<List<ONIrsaliyeDetay>>(result, Messages.Irsaliye.IrsaliyeGet);
        }

        public IResult Update(ONIrsaliyeDetay irsaliyeDetay)
        {

            _irsaliyeDetayDal.Update(irsaliyeDetay);

            return new SuccessResult(Messages.IrsaliyeDetay.IrsaliyeDetayUpdated);
        }
    }
}
