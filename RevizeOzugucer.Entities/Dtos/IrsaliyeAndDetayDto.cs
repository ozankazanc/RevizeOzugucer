using RevizeOzugucer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RevizeOzugucer.Entities.Dtos
{
    public class IrsaliyeAndDetayDto : ONIrsaliye
    {
        public List<ONIrsaliyeDetay> listIrsaliyeDetay { get; set; }
        public string Plaka { get; set; }
    }
}
