using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;
using DataAccess.Model;


namespace DataAccess
{
    

    public class MsSqlAccess : DbContext
    {
        private string _sqlConnectString = string.Empty;

        public MsSqlAccess(string connectString)
        {
            _sqlConnectString = connectString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. 
            //See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(_sqlConnectString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Deviceinfo>(entity =>
            {
                entity.Property(e => e.MacId).IsRequired();
            });
        }

        public virtual DbSet<Deviceinfo> Deviceinfo { get; set; }

        public string GepEncryptString(string macid)
        {
            
            var info = Deviceinfo.Where(x=>x.MacId == macid).FirstOrDefault();

            return info.EncryptString;
        }
    }

}


