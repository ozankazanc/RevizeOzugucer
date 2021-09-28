using RevizeOzugucer.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RevizeOzugucer.Entities.Concrete
{
    public class ONIrsaliye : IEntity
    {
        [Key]
        public int IrsaliyeId { get; set; }
        public int SurucuId { get; set; }
        public int PlakaId { get; set; }
        public string HesapNo { get; set; }
        public string VergiDairesi { get; set; }
        public DateTime IrsaliyeTarihi { get; set; }
        public DateTime KayitTarihi { get; set; } = DateTime.Now;
        public DateTime DegistirmeTarihi { get; set; } = DateTime.Now;
        public bool Sil { get; set; }
    }
}
