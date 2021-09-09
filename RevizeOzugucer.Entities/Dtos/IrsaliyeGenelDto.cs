using System;
using System.Collections.Generic;
using System.Text;

namespace RevizeOzugucer.Entities.Dtos
{
    public class IrsaliyeGenelDto
    {
        public int IrsaliyeNo { get; set; }
        public string SurucuAdSoyad { get; set; }
        public string Plaka { get; set; }
        public string HesapNo { get; set; }
        public string VergiDairesi { get; set; }
        public DateTime KayitTarihi { get; set; }
        public DateTime DegistirmeTarihi { get; set; }
    }
}
