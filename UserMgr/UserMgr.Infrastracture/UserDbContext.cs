using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UserMgr.Domain.Entities;
using UserMgr.Infrastracture.Config;

namespace UserMgr.Infrastracture
{
    public class UserDbContext:DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> opt):base(opt)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserLoginHistory> UserLoginHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new UserLoginHistoryConfig());
        }
    }
}
