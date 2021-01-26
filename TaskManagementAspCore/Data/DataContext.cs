using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Models;

namespace TaskManager.Data
{

    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            //
        }



        public DbSet<Department> Departments { get; set; }
        public DbSet<Jobs> Jobs { get; set; }
        public DbSet<CheckoutProcess> CheckOutProcess { get; set; }               
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public object User { get; internal set; }
    }
}
