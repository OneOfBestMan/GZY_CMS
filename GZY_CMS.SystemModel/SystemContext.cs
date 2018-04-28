using Microsoft.EntityFrameworkCore;
using System;

namespace GZY_CMS.SystemModel
{
    public class SystemContext : DbContext
    {
        public SystemContext(DbContextOptions option)
          : base(option)

        {
            //初始化的时候创建数据库
            this.Database.EnsureCreated();
            // this.Database.Migrate();
            //this.GetService<ILoggerFactory>().AddProvider(new MyFilteredLoggerProvider());
            //options
        }

        /// <summary>
        /// 配置加载
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        /// <summary>
        /// 实体创建
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


        }

        public DbSet<GZY_Right> GZY_Right { get; set; }
        public DbSet<GZY_RightAndWorknode> GZY_RightAndWorknode { get; set; }
        public DbSet<GZY_SystemTable> GZY_SystemTable { get; set; }
        public DbSet<GZY_User> GZY_User { get; set; }
        public DbSet<GZY_UserAndRight> GZY_UserAndRight { get; set; }
        public DbSet<Gzy_UserAndSystem> Gzy_UserAndSystem { get; set; }
        public DbSet<GZY_Worknode> GZY_Worknode { get; set; }
        public DbSet<SHECA_SystemAndRight> SHECA_SystemAndRight { get; set; }
    }
}
