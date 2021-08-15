using RevizeOzugucer.Business.Abstract;
using RevizeOzugucer.Business.Constant;
using RevizeOzugucer.Core.Aspects.Autofac.Transaction;
using RevizeOzugucer.Core.Utilities.Results;
using RevizeOzugucer.DataAccess.Abstract;
using RevizeOzugucer.Entities.Concrete;
using RevizeOzugucer.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RevizeOzugucer.Business.Concrete
{
    public class ONIrsaliyeManager : IONIrsaliyeService
    {
        private IONIrsaliyeDal _irsaliyeDal;
        private IONIrsaliyeDetayService _irsaliyeDetayService;

        public ONIrsaliyeManager(IONIrsaliyeDal irsaliyeDal, IONIrsaliyeDetayService irsaliyeDetayService)
        {
            _irsaliyeDal = irsaliyeDal;
            _irsaliyeDetayService = irsaliyeDetayService;
        }

        public IResult Add(ONIrsaliye irsaliye)
        {
            _irsaliyeDal.Add(irsaliye);

            return new SuccessResult(Messages.Irsaliye.IrsaliyeAdded);
        }

        [TransactionScopeAspect]
        public IResult AddIrsaliyeAndIrsaliyeDetay(IrsaliyeAndDetayDto irsaliyeAndDetayDto)
        {
            ONIrsaliye irsaliye = new ONIrsaliye
            {
                IrsaliyeId = irsaliyeAndDetayDto.IrsaliyeId,
                SurucuId = irsaliyeAndDetayDto.SurucuId,
                HesapNo = irsaliyeAndDetayDto.HesapNo,
                VergiDairesi = irsaliyeAndDetayDto.VergiDairesi,
                PlakaNo = irsaliyeAndDetayDto.PlakaNo,
                KayitTarihi = irsaliyeAndDetayDto.KayitTarihi,
                DegistirmeTarihi = irsaliyeAndDetayDto.DegistirmeTarihi,
                Sil = irsaliyeAndDetayDto.Sil
            };

            _irsaliyeDal.Add(irsaliye);

            int irsaliyeId = GetLastId().Data;
            foreach (var irsaliyeDetay in irsaliyeAndDetayDto.listIrsaliyeDetay)
            {
                irsaliyeDetay.IrsaliyeId = irsaliyeId;
                _irsaliyeDetayService.Add(irsaliyeDetay);
            }

            return new SuccessResult(Messages.Irsaliye.IrsaliyeAdded);
        }

        public IDataResult<int> Count()
        {
            return new SuccessDataResult<int>(_irsaliyeDal.GetAll().Count);
        }

        public IResult Delete(int id)
        {
            //master 
            var result = GetByIrsaliyeId(id);

            result.Data.Sil = true;
            _irsaliyeDal.Update(result.Data);

            //detail
            var resultIrsaliyeDetays = _irsaliyeDetayService.GetByIrsaliyeId(id).Data;

            foreach (var irsaliyeDetay in resultIrsaliyeDetays)
            {
                irsaliyeDetay.Sil = true;
                _irsaliyeDetayService.Update(irsaliyeDetay);
            }

            return new SuccessResult(Messages.Irsaliye.IrsaliyeDeleted);
        }

        public IDataResult<List<ONIrsaliye>> GetAll()
        {
            return new SuccessDataResult<List<ONIrsaliye>>(_irsaliyeDal.GetAll(), Messages.Irsaliye.IrsaliyeGetAll);
        }

        public IDataResult<List<ONIrsaliye>> GetAllDeleted()
        {
            return new SuccessDataResult<List<ONIrsaliye>>(_irsaliyeDal.GetAll(x => x.Sil == true), Messages.Irsaliye.IrsaliyeGetAll);
        }

        public IDataResult<List<ONIrsaliye>> GetAllNonDeleted()
        {
            return new SuccessDataResult<List<ONIrsaliye>>(_irsaliyeDal.GetAll(x => x.Sil == false), Messages.Irsaliye.IrsaliyeGetAll);
        }

        public IDataResult<List<string>> GetAllPlakas()
        {
            var result = _irsaliyeDal.GetAll(x => x.Sil == false);

            if (result != null)
            {
                var plakasGrp = (from plakas in result
                                 group plakas by plakas.PlakaNo into plakas
                                 select new { PlakaNo = plakas.Key })
                                 .Select(x => (string)x.PlakaNo).ToList();

                return new SuccessDataResult<List<string>>(plakasGrp, Messages.Irsaliye.IrsaliyeGetPlakas);
            }
            return new ErrorDataResult<List<string>>(null, Messages.Irsaliye.IrsaliyePlakasNotFound);
        }

        public IDataResult<ONIrsaliye> GetByIrsaliyeId(int id)
        {
            return new SuccessDataResult<ONIrsaliye>(_irsaliyeDal.Get(x => x.IrsaliyeId == id), Messages.Irsaliye.IrsaliyeGet);
        }

        public IDataResult<ONIrsaliye> GetBySurucuId(int id)
        {
            return new SuccessDataResult<ONIrsaliye>(_irsaliyeDal.Get(x => x.SurucuId == id), Messages.Irsaliye.IrsaliyeGet);
        }

        public IDataResult<int> GetLastId()
        {
            return new SuccessDataResult<int>(_irsaliyeDal.GetAll().LastOrDefault().IrsaliyeId, Messages.Irsaliye.IrsaliyeGetLastId);
        }

        public IResult Update(ONIrsaliye irsaliye)
        {
            _irsaliyeDal.Update(irsaliye);

            return new SuccessResult(Messages.Irsaliye.IrsaliyeUpdated);
        }
    }
}
