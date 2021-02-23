using Microsoft.EntityFrameworkCore;
using TaskManagementCore.Models;

namespace TaskManagementCore.Api
{

    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        //
        }

        public DbSet<CheckoutProcess> CheckOutProcesses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Jobs> Jobs { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //MODELO DE IMPLATANÇÃO DOS MODELS, NÃO NECESSARIO NO ENTITY 5.0+. 

            /* modelBuilder.Entity<DepartmentsUsers>()
                  .HasKey(bc => new { bc.DepartmentId, bc.UserId });
             modelBuilder.Entity<DepartmentsUsers>()
                  .HasOne(pt => pt.User)
                  .WithMany(p => p.DepartmentsUsers)
                  .HasForeignKey(pt => pt.UserId);
             modelBuilder.Entity<DepartmentsUsers>()
                 .HasOne(pt => pt.Department)
                 .WithMany(t => t.DepartmentsUsers)
                 .HasForeignKey(pt => pt.DepartmentId);

             modelBuilder.Entity<JobsUser>()
              .HasKey(bc => new { bc.JobsId, bc.UserId });
             modelBuilder.Entity<JobsUser>()
                 .HasOne(bc => bc.Jobs)
                 .WithMany(b => b.JobsUsers)
                 .HasForeignKey(bc => bc.JobsId);
             modelBuilder.Entity<JobsUser>()
                 .HasOne(bc => bc.User)
                 .WithMany(c => c.JobsUsers)
                 .HasForeignKey(bc => bc.UserId);*/

            /*   modelBuilder.Entity<DepartmentsUsers>()
             .HasKey(t => new { t.UserId, t.TagId });

               modelBuilder.Entity<PostTag>()
                   .HasOne(pt => pt.Post)
                   .WithMany(p => p.PostTags)
                   .HasForeignKey(pt => pt.PostId);

               modelBuilder.Entity<PostTag>()
                   .HasOne(pt => pt.Tag)
                   .WithMany(t => t.PostTags)
                   .HasForeignKey(pt => pt.TagId);*/
        }
    }
}


