using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskManager.Data;
using TaskManager.Enums;
using TaskManager.Models;
using TaskManager.ValueObjects;

namespace TaskManagementAspCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            InitializeDb();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
        });

       /* public class Startup
        {
            public void ConfigureServices(IServiceCollection services)
                => services.AddDbContext<DataContext>();
        }

        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<DataContext> options)
                : base(options)
            {
            }
        }*/


        #region CustomMethods
        public static void InitializeDb()
        {
            string email = "renato@123.com";
            List<Department> departments = new List<Department>();
            List<Department> departments2 = new List<Department>();
            List<Department> departments3 = new List<Department>();
            List<User> users = new List<User>();
            List<Jobs> tasks = new List<Jobs>();
            departments.AddRange(new List<Department> {
                new Department("Administração"),
                new Department("RH"),
                new Department("Gerencia"),
                new Department("Limpeza"),
                new Department("T.I"),
            });
            departments2.Add(departments[1]);
            departments3.Add(departments[4]);


            Company company = new Company("ModalGR");
            User user = new User("Renato", email, DateTime.Now, true, departments3, company);
            User user1 = new User("AndrezinhoReiDelas", email, DateTime.Now, true, departments2, company);
            Jobs task = new Jobs("Pegar a manga e sair correndo", ETaskStatus.CONCLUDED, DateTime.Now, DateTime.Now, users);
            Jobs task2 = new Jobs("DEU RUIM ", ETaskStatus.CONCLUDED, DateTime.Now, DateTime.Now);
            tasks.Add(task); tasks.Add(task2);
            CheckoutProcess checkoutprocess = new CheckoutProcess("Pegar manga no quintal dos outros", departments[1], "pegar a manga ue", DateTime.Now, DateTime.Now, tasks);
            users.AddRange(new List<User> { user, user1 });
            user1.Tasks = tasks;
            user.Tasks.Add(task2);


            //MessageBox.Show(task.Id.ToString());
            //MessageBox.Show(company.ListAllUsers());


            //DataContext db = new DataContext(opt => opt.UseSqlServer(Configuration.GetConnectionString("TaskManagmentString")));
          /*  db.CheckOutProcess.Add(checkoutprocess);
            db.Company.Add(company);
            db.User.AddRange(users);
            db.Department.AddRange(departments);
            db.SaveChanges();
            db.Department.Add(departments[0]);
            db.Task.Add(task2);
            db.SaveChanges();
*/
        }
        #endregion
    }
}
