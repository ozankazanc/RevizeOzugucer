using RevizeOzugucer.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RevizeOzugucer.Entities.Concrete
{
    public class ONPlaka : IEntity
    {
        [Key]
        public int PlakaId { get; set; }
        public string Plaka { get; set; }
        public int IrsaliyeId { get; set; }
        public DateTime KayitTarihi { get; set; } = DateTime.Now;
        public DateTime DegistirmeTarihi { get; set; } = DateTime.Now;
        public bool Sil { get; set; }
    }
}
