using RevizeOzugucer.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RevizeOzugucer.Entities.Concrete
{
    public class ONSurucu : IEntity
    {
        [Key]
        public int SurucuId { get; set; }
        public string SurucuAdi { get; set; }
        public string SurucuSoyadi { get; set; }
        public string SurucuTelefon { get; set; }
        public string SurucuKimlikNo { get; set; }
        public DateTime KayitTarihi { get; set; } = DateTime.Now;
        public DateTime DegistirmeTarihi { get; set; } = DateTime.Now;
        public bool Sil { get; set; }
    }
}
