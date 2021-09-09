using RevizeOzugucer.Core.Utilities.Results;
using RevizeOzugucer.Entities.Concrete;
using RevizeOzugucer.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace RevizeOzugucer.Business.Abstract
{
    public interface IONIrsaliyeService
    {
        IDataResult<List<ONIrsaliye>> GetAll();
        IDataResult<List<ONIrsaliye>> GetAllNonDeleted();
        IDataResult<List<ONIrsaliye>> GetAllDeleted();
        IDataResult<List<string>> GetAllPlakas();
        IDataResult<ONIrsaliye> Get(int id);
        IDataResult<ONIrsaliye> GetBySurucuId(int id);
        IDataResult<int> Count();
        IResult Add(ONIrsaliye irsaliye);
        IResult Update(ONIrsaliye irsaliye);
        IResult Delete(int id);
        IDataResult<int> GetLastId();
        /// <summary>
        /// Transaction - Irsaliye ->Master IrsaliyeDetay -> Detail
        /// </summary>
        /// <param name="listIrsaliyeDetay"></param>
        /// <returns></returns>
        IResult AddIrsaliyeAndIrsaliyeDetay(IrsaliyeAndDetayDto irsaliyeAndDetayDto);
        IDataResult<List<IrsaliyeGenelDto>> ViewIrsaliyeGenel();
        IDataResult<List<IrsaliyeGenelDto>> GetAllToday();
        IDataResult<List<IrsaliyeGenelDto>> GetAllThisWeek();
        IDataResult<List<IrsaliyeGenelDto>> GetAllThisMonth();
        IDataResult<List<IrsaliyeGenelDto>> GetAllThisYear();
        IDataResult<List<IrsaliyeGenelDto>> GetAllBeetweenTwoDates(BetweenToDatesIrsaliye betweenToDatesIrsaliye);





    }
}
