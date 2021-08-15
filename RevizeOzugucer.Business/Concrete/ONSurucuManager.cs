using RevizeOzugucer.Business.Abstract;
using RevizeOzugucer.Business.Constant;
using RevizeOzugucer.Core.Utilities.Business;
using RevizeOzugucer.Core.Utilities.Results;
using RevizeOzugucer.DataAccess.Abstract;
using RevizeOzugucer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RevizeOzugucer.Business.Concrete
{
    public class ONSurucuManager : IONSurucuService
    {
        IONSurucuDal _surucuDal;

        public ONSurucuManager(IONSurucuDal surucuDal)
        {
            _surucuDal = surucuDal;
        }
        public IResult Add(ONSurucu surucu)
        {
            _surucuDal.Add(surucu);

            return new SuccessResult(Messages.Surucu.SurucuAdded);
        }

        public IDataResult<int> Count()
        {
            return new SuccessDataResult<int>(_surucuDal.GetAll().Count);
        }

        public IResult Delete(int id)
        {
            var result = GetBySurucuId(id);
            
            result.Data.Sil = true;
            _surucuDal.Update(result.Data);

            return new SuccessResult(Messages.Surucu.SurucuUpdated);
        }

        public IDataResult<List<ONSurucu>> GetAll()
        {
            return new SuccessDataResult<List<ONSurucu>>(_surucuDal.GetAll(), Messages.Surucu.SurucuGetAll);
        }

        public IDataResult<List<ONSurucu>> GetAllDeleted()
        {
            return new SuccessDataResult<List<ONSurucu>>(_surucuDal.GetAll(x=>x.Sil==true), Messages.Surucu.SurucuGetAll);

        }

        public IDataResult<List<ONSurucu>> GetAllNonDeleted()
        {
            return new SuccessDataResult<List<ONSurucu>>(_surucuDal.GetAll(x => x.Sil == false), Messages.Surucu.SurucuGetAll);
        }

        public IDataResult<ONSurucu> GetBySurucuId(int id)
        {
            var result = _surucuDal.Get(x=>x.SurucuId == id);

            if (result == null)
            {
                return new ErrorDataResult<ONSurucu>(data:null,Messages.Surucu.SurucuNotFind);
            }

            return new SuccessDataResult<ONSurucu>(result, Messages.Surucu.SurucuGet);

        }

        public IDataResult<List<string>> GetOnlySurucuNames()
        {
            var result = _surucuDal.GetAll(x => x.Sil == false)
                                   .Select(x => new { AdSoyad = $"{x.SurucuAdi} {x.SurucuSoyadi}" })
                                   .Select(x => (string)x.AdSoyad).ToList();

            return new SuccessDataResult<List<string>>(result, Messages.Surucu.SurucuGetOnlyNames);
        }

        public IResult Update(ONSurucu surucu)
        {
            _surucuDal.Update(surucu);

            return new SuccessResult(Messages.Surucu.SurucuUpdated);
        }
    }
}
