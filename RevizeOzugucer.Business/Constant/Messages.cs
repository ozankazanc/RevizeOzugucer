using System;
using System.Collections.Generic;
using System.Text;

namespace RevizeOzugucer.Business.Constant
{
    public static class Messages
    {
        public static class Surucu
        {
            public static string SurucuAdded = "Sürücü eklendi.";
            public static string SurucuDeleted = "Sürücü silindi.";
            public static string SurucuUpdated = "Sürücü bilgileri güncellendi.";
            public static string SurucuGetAll = "Sürücüler getirildi.";
            public static string SurucuGet = "Sürücü getirildi.";
            public static string SurucuGetOnlyNames = "Sürücülerin adı ve soyadı getirildi.";


            public static string SurucuNotFind = "Sürücü bulunamadı.";
        }
        public static class Irsaliye
        {
            public static string IrsaliyeAdded = "Irsaliye eklendi.";
            public static string IrsaliyeDeleted = "Irsaliye silindi.";
            public static string IrsaliyeUpdated = "Irsaliye güncellendi.";
            public static string IrsaliyeGetAll = "Irsaliye getirildi.";
            public static string IrsaliyeGet = "Irsaliye getirildi.";
            public static string IrsaliyeGetLastId = "Son Irsaliye Id getirildi.";
            public static string IrsaliyeGetPlakas = "Plakalar getirildi.";

            public static string IrsaliyeNotFound = "Irsaliye bulunamadı.";
            public static string IrsaliyePlakasNotFound= "Plakalar getirilemedi.";


        }
        public static class IrsaliyeDetay
        {
            public static string IrsaliyeDetayAdded = "Irsaliye detayı eklendi.";
            public static string IrsaliyeDetayDeleted = "Irsaliye detayı silindi.";
            public static string IrsaliyeDetayUpdated = "Irsaliye detayı güncellendi.";
            public static string IrsaliyeDetayGetAll = "Irsaliyenin detayları getirildi.";
            public static string IrsaliyeDetayGet = "Irsaliye detayı getirildi.";
            public static string IrsaliyeDetayNotFound = "Irsaliye detayı bulunamadı.";


        }

        public static class Plaka
        {
            public static string PlakaAdded =   "Plaka eklendi.";
            public static string PlakaDeleted = "Plaka silindi.";
            public static string PlakaUpdated = "Plaka güncellendi.";
            public static string PlakaGetAll =  "Plakalar getirildi.";
            public static string PlakaGet =     "Plaka getirildi.";
            public static string PlakaNotFound ="Plaka bulunamadı.";
            public static string IrsaliyeGetLastId = "Son Plaka Id getirildi.";
        }
    }
}
