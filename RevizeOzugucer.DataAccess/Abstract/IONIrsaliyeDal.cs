using RevizeOzugucer.Core.DataAccess;
using RevizeOzugucer.Entities.Concrete;
using RevizeOzugucer.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace RevizeOzugucer.DataAccess.Abstract
{

    public interface IONIrsaliyeDal : IEntityRepository<ONIrsaliye>
    {
        List<IrsaliyeGenelDto> ViewIrsaliyeGenel();
    }
}
