using RevizeOzugucer.Business.Abstract;
using RevizeOzugucer.Business.Constant;
using RevizeOzugucer.Core.Utilities.Results;
using RevizeOzugucer.DataAccess.Abstract;
using RevizeOzugucer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RevizeOzugucer.Business.Concrete
{
    public class ONPlakaManager : IONPlakaService
    {
        private IONPlakaDal _plakaDal;

        public ONPlakaManager(IONPlakaDal plakaDal)
        {
            _plakaDal = plakaDal;
            
        }

        public IResult Add(ONPlaka plaka)
        {
            _plakaDal.Add(plaka);

            return new SuccessResult(Messages.Plaka.PlakaAdded);
        }

        public IDataResult<int> Count()
        {
            return new SuccessDataResult<int>(_plakaDal.GetAll().Count);
        }

        public IResult Delete(int id)
        {
            var result = GetByPlakaId(id);
            
            result.Data.Sil = true;
            _plakaDal.Update(result.Data);

            return new SuccessResult(Messages.Surucu.SurucuUpdated);
        }

        public IDataResult<List<ONPlaka>> GetAll()
        {
            return new SuccessDataResult<List<ONPlaka>>(_plakaDal.GetAll().ToList(), Messages.Plaka.PlakaGetAll);
        }

        public IDataResult<List<ONPlaka>> GetAllDeleted()
        {
            return new SuccessDataResult<List<ONPlaka>>(_plakaDal.GetAll(x => x.Sil == true), Messages.Plaka.PlakaGetAll);
        }

        public IDataResult<List<ONPlaka>> GetAllNonDeleted()
        {
            return new SuccessDataResult<List<ONPlaka>>(_plakaDal.GetAll(x => x.Sil == false), Messages.Plaka.PlakaGetAll);
        }

        public IDataResult<ONPlaka> GetByPlakaId(int id)
        {
            var result = _plakaDal.Get(x => x.PlakaId == id);

            if (result == null)
            {
                return new ErrorDataResult<ONPlaka>(data: null, Messages.Plaka.PlakaNotFound);
            }

            return new SuccessDataResult<ONPlaka>(result, Messages.Plaka.PlakaGet);
        }

        public IResult Update(ONPlaka plaka)
        {
            _plakaDal.Update(plaka);

            return new SuccessResult(Messages.Plaka.PlakaAdded);
        }
    }
}
