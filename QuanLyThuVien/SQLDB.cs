using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QuanLyThuVien
{
    public partial class SQLDB : DbContext
    {
        public SQLDB()
            : base("name=SQLDB")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
