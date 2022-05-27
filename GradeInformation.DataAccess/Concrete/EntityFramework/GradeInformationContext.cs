using GradeInformation.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeInformation.DataAccess.Concrete.EntityFramework
{
    public class GradeInformationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=GradeInformationDB;Trusted_Connection=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Student>().Property(p => p.Gpa).HasPrecision(5, 2);
            //modelBuilder.Entity<StudentCompany>().HasKey(p => new { p.StudentId, p.CompanyId });

            //modelBuilder.Entity<SectorCompany>().HasKey(p => new { p.SectorId, p.CompanyId });
            //modelBuilder.Entity<StudentCompanyTool>().HasKey(p => new { p.StudentCompanyId, p.ToolId });
            modelBuilder.Entity<Student>().HasIndex(s => s.Tc).IsUnique(true);

        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<SectorCompany> SectorCompanies { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCompany> StudentCompanies { get; set; }
        public DbSet<StudentCompanyTool> StudentCompanyTools { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<CompanyField> CompanyFields { get; set; }
    }
}
