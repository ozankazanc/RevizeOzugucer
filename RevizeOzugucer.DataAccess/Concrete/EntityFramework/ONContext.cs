using Microsoft.EntityFrameworkCore;
using RevizeOzugucer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RevizeOzugucer.DataAccess.Concrete.EntityFramework
{
    public class ONContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=94.73.170.92; Database=MKocdb; User Id=oznkznc; Password=1234560_Ozaka.M;");
        }
        
        public DbSet<ONIrsaliye> ONIrsaliye { get; set; }
        public DbSet<ONIrsaliyeDetay> ONIrsaliyeDetay { get; set; }
        public DbSet<ONSurucu> ONSurucu { get; set; }
   
    }
}
