using Microsoft.EntityFrameworkCore;
using RevizeOzugucer.Core.DataAccess.EntityFramework;
using RevizeOzugucer.DataAccess.Abstract;
using RevizeOzugucer.Entities.Concrete;
using RevizeOzugucer.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RevizeOzugucer.DataAccess.Concrete.EntityFramework
{

    public class EFONIrsaliyeDal : EFEntityRepositoryBase<ONIrsaliye, ONContext>, IONIrsaliyeDal
    {
        public List<IrsaliyeGenelDto> ViewIrsaliyeGenel()
        {
            using (ONContext context = new ONContext())
            {
                var result = (from irsaliye in context.ONIrsaliye
                              join surucu in context.ONSurucu on irsaliye.SurucuId equals surucu.SurucuId into s
                              from su in s.DefaultIfEmpty()
                              join plaka in context.ONPlaka on irsaliye.PlakaId equals plaka.PlakaId into p
                              from pl in p.DefaultIfEmpty()
                              where irsaliye.Sil == false
                              select new IrsaliyeGenelDto
                              {
                                  IrsaliyeNo = irsaliye.IrsaliyeId,
                                  SurucuAdSoyad = $"{su.SurucuAdi} {su.SurucuSoyadi}",
                                  Plaka = pl.PlakaArac,
                                  HesapNo = irsaliye.HesapNo,
                                  VergiDairesi = irsaliye.VergiDairesi,
                                  KayitTarihi = irsaliye.KayitTarihi,
                                  DegistirmeTarihi = irsaliye.DegistirmeTarihi
                              }).ToList();
               
                return result;
            }
        }
    }
}
