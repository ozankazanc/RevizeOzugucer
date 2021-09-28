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
        private IONPlakaService _plakaService;
        private IONSurucuService _surucuService;

        public ONIrsaliyeManager(IONIrsaliyeDal irsaliyeDal, IONIrsaliyeDetayService irsaliyeDetayService, IONPlakaService plakaService, IONSurucuService surucuService)
        {
            _irsaliyeDal = irsaliyeDal;
            _irsaliyeDetayService = irsaliyeDetayService;
            _plakaService = plakaService;
            _surucuService = surucuService;
        }

        public IResult Add(ONIrsaliye irsaliye)
        {
            _irsaliyeDal.Add(irsaliye);

            return new SuccessResult(Messages.Irsaliye.IrsaliyeAdded);
        }

        [TransactionScopeAspect]
        public IResult AddIrsaliyeAndIrsaliyeDetay(IrsaliyeAndDetayDto irsaliyeAndDetayDto)
        {
            //plaka tanımlı değilse kaydet.
            if (_plakaService.GetByPlakaArac(irsaliyeAndDetayDto.Plaka).Data == null)
            {
                ONPlaka plaka = new ONPlaka
                {
                    PlakaArac = irsaliyeAndDetayDto.Plaka
                };

                _plakaService.Add(plaka);
            }

            ONIrsaliye irsaliye = new ONIrsaliye
            {
                IrsaliyeId = irsaliyeAndDetayDto.IrsaliyeId,
                SurucuId = irsaliyeAndDetayDto.SurucuId,
                HesapNo = irsaliyeAndDetayDto.HesapNo,
                VergiDairesi = irsaliyeAndDetayDto.VergiDairesi,
                PlakaId = _plakaService.GetLastId().Data,
                IrsaliyeTarihi = irsaliyeAndDetayDto.IrsaliyeTarihi,
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

        [TransactionScopeAspect]
        public IResult UpdateIrsaliyeAndIrsaliyeDetay(IrsaliyeAndDetayDto irsaliyeAndDetayDto)
        {
            var resultIrsaliye = Get(irsaliyeAndDetayDto.IrsaliyeId);

            if (resultIrsaliye.IsSuccess)
            {
                ONIrsaliye irsaliye = resultIrsaliye.Data;
                irsaliye.IrsaliyeId = irsaliyeAndDetayDto.IrsaliyeId;
                irsaliye.SurucuId = irsaliyeAndDetayDto.SurucuId;
                irsaliye.PlakaId = irsaliyeAndDetayDto.PlakaId;
                irsaliye.HesapNo = irsaliyeAndDetayDto.HesapNo;
                irsaliye.VergiDairesi = irsaliyeAndDetayDto.VergiDairesi;
                irsaliye.IrsaliyeTarihi = irsaliyeAndDetayDto.IrsaliyeTarihi;
                irsaliye.DegistirmeTarihi = irsaliyeAndDetayDto.DegistirmeTarihi;

                Update(irsaliye);
            }
            else
            {
                return new ErrorResult(Messages.Irsaliye.IrsaliyeNotUpdated);
            }

            var resultIrsaliyeDetay = _irsaliyeDetayService.GetByIrsaliyeId(irsaliyeAndDetayDto.IrsaliyeId);
            if (resultIrsaliyeDetay.IsSuccess)
            {
                var listIrsaliyeDetay = resultIrsaliyeDetay.Data;

                foreach (var irsaliyeDetay in listIrsaliyeDetay)
                {
                    irsaliyeDetay.Sil = true;
                    _irsaliyeDetayService.Update(irsaliyeDetay);
                }
            }
            else
            {
                return new ErrorResult(Messages.IrsaliyeDetay.IrsaliyeDetayNotUpdated);
            }

            foreach (var irsaliyeDetay in irsaliyeAndDetayDto.listIrsaliyeDetay)
            {
                irsaliyeDetay.IrsaliyeDetayId = 0;
                _irsaliyeDetayService.Add(irsaliyeDetay);
            }

            return new SuccessResult(Messages.Irsaliye.IrsaliyeUpdated);
        }

        public IDataResult<int> Count()
        {
            return new SuccessDataResult<int>(_irsaliyeDal.GetAll().Count);
        }

        //TRANSACTION GECILECEK
        public IResult Delete(int id)
        {
            //master 
            var result = Get(id);

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
            //var result = _irsaliyeDal.GetAll(x => x.Sil == false);

            //if (result != null)
            //{
            //    var plakasGrp = (from plakas in result
            //                     group plakas by plakas.PlakaNo into plakas
            //                     select new { PlakaNo = plakas.Key })
            //                     .Select(x => (string)x.PlakaNo).ToList();

            //    return new SuccessDataResult<List<string>>(plakasGrp, Messages.Irsaliye.IrsaliyeGetPlakas);
            //}
            //return new ErrorDataResult<List<string>>(null, Messages.Irsaliye.IrsaliyePlakasNotFound);

            return new ErrorDataResult<List<string>>(null, Messages.Irsaliye.IrsaliyePlakasNotFound);
        }

        public IDataResult<ONIrsaliye> Get(int id)
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

        public IDataResult<List<IrsaliyeGenelDto>> ViewIrsaliyeGenel()
        {
            return new SuccessDataResult<List<IrsaliyeGenelDto>>(_irsaliyeDal.ViewIrsaliyeGenel(), Messages.Irsaliye.IrsaliyeGetAll);
        }

        public IDataResult<List<IrsaliyeGenelDto>> GetAllToday()
        {
            var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            var result = _irsaliyeDal.ViewIrsaliyeGenel().Where(x => x.KayitTarihi >= startDate && x.KayitTarihi <= DateTime.Now).ToList();

            return new SuccessDataResult<List<IrsaliyeGenelDto>>(result, Messages.Irsaliye.IrsaliyeGetAll);
        }

        public IDataResult<List<IrsaliyeGenelDto>> GetAllThisWeek()
        {
            //ŞUAN Kİ SUNUCU KÜLTÜRÜ TÜRKİYE OLARAK AYARLI, EĞER DEĞİLSE GÜNE +1 EKLENMELİ 
            var startDate = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
            var result = _irsaliyeDal.ViewIrsaliyeGenel().Where(x => x.KayitTarihi >= startDate && x.KayitTarihi <= DateTime.Now).ToList();

            return new SuccessDataResult<List<IrsaliyeGenelDto>>(result, Messages.Irsaliye.IrsaliyeGetAll);
        }

        public IDataResult<List<IrsaliyeGenelDto>> GetAllThisMonth()
        {
            var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var result = _irsaliyeDal.ViewIrsaliyeGenel().Where(x => x.KayitTarihi >= startDate && x.KayitTarihi <= DateTime.Now).ToList();

            return new SuccessDataResult<List<IrsaliyeGenelDto>>(result, Messages.Irsaliye.IrsaliyeGetAll);
        }

        public IDataResult<List<IrsaliyeGenelDto>> GetAllThisYear()
        {
            var startDate = new DateTime(DateTime.Now.Year, 1, 1);
            var result = _irsaliyeDal.ViewIrsaliyeGenel().Where(x => x.KayitTarihi >= startDate && x.KayitTarihi <= DateTime.Now).ToList();

            return new SuccessDataResult<List<IrsaliyeGenelDto>>(result, Messages.Irsaliye.IrsaliyeGetAll);
        }

        public IDataResult<List<IrsaliyeGenelDto>> GetAllBeetweenTwoDates(BetweenToDatesIrsaliye betweenToDatesIrsaliye)
        {
            var startDate = new DateTime(DateTime.Now.Year, 1, 1);
            var result = _irsaliyeDal.ViewIrsaliyeGenel().Where
                (x => x.KayitTarihi >= betweenToDatesIrsaliye.StartDate && x.KayitTarihi <= betweenToDatesIrsaliye.EndDate).ToList();

            return new SuccessDataResult<List<IrsaliyeGenelDto>>(result, Messages.Irsaliye.IrsaliyeGetAll);
        }

        public IDataResult<IrsaliyeAndDetayGenelDto> GetIrsaliyeAndDetayGenelDto(int id)
        {
            var irsaliye = Get(id);
            var irsaliyeDetay = _irsaliyeDetayService.GetByIrsaliyeId(id);

            if (irsaliye.Data == null || irsaliyeDetay.Data == null)
            {
                return new ErrorDataResult<IrsaliyeAndDetayGenelDto>(Messages.Irsaliye.IrsaliyeNotFound);
            }

            var surucu = _surucuService.Get(irsaliye.Data.SurucuId);
            var plaka = _plakaService.Get(irsaliye.Data.PlakaId);

            if (surucu.Data == null || plaka.Data == null)
            {
                return new ErrorDataResult<IrsaliyeAndDetayGenelDto>(Messages.Irsaliye.IrsaliyeNotFound);
            }

            IrsaliyeAndDetayGenelDto irsaliyeAndDetayGenelDto = new IrsaliyeAndDetayGenelDto
            {
                IrsaliyeId = irsaliye.Data.IrsaliyeId,
                HesapNo = irsaliye.Data.HesapNo,
                VergiDairesi = irsaliye.Data.VergiDairesi,
                IrsaliyeTarihi = irsaliye.Data.IrsaliyeTarihi,
                KayitTarihi = irsaliye.Data.KayitTarihi,
                DegistirmeTarihi = irsaliye.Data.DegistirmeTarihi,
                Sil = irsaliye.Data.Sil,
                Plaka = plaka.Data,
                Surucu = surucu.Data,
                IrsaliyeDetay = irsaliyeDetay.Data
            };

            return new SuccessDataResult<IrsaliyeAndDetayGenelDto>(irsaliyeAndDetayGenelDto, Messages.Irsaliye.IrsaliyeGet);
        }
    }
}
