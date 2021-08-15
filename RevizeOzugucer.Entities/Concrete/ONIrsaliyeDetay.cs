using RevizeOzugucer.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RevizeOzugucer.Entities.Concrete
{
    public class ONIrsaliyeDetay: IEntity
    {
        [Key]
        public int IrsaliyeDetayId { get; set; }
        public int IrsaliyeId { get; set; }
        public string HalNo { get; set; }
        public string Gonderen { get; set; }
        public decimal Kilogram { get; set; }
        public int Adet { get; set; }
        public string Cinsi { get; set; }
        public string SandikNevi { get; set; }
        public decimal Fiyat { get; set; }
        public DateTime KayitTarihi { get; set; } = DateTime.Now;
        public DateTime DegistirmeTarihi { get; set; } = DateTime.Now;
        public bool Sil { get; set; }
    }
}
