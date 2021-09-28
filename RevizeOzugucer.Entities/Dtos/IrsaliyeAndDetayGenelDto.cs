using RevizeOzugucer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RevizeOzugucer.Entities.Dtos
{
    public class IrsaliyeAndDetayGenelDto
    {
        public int IrsaliyeId { get; set; }
        public string HesapNo { get; set; }
        public string VergiDairesi { get; set; }
        public DateTime IrsaliyeTarihi { get; set; }
        public DateTime KayitTarihi { get; set; }
        public DateTime DegistirmeTarihi { get; set; }
        public bool Sil { get; set; }
        public ONSurucu Surucu { get; set; }
        public ONPlaka Plaka { get; set; }
        public List<ONIrsaliyeDetay> IrsaliyeDetay { get; set; }
    }
}
