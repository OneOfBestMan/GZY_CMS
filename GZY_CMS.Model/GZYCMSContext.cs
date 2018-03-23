using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GZY_CMS.Model
{
    public class GZYCMSContext : DbContext
    {
        public GZYCMSContext(DbContextOptions option)
          :base(option)

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
          //  Mlogger.AddProvider(new MyFilteredLoggerProvider());
            //var loggerFactory =
            //     optionsBuilder
            //    //  .UseLoggerFactory(Mlogger)
            //    .UseMySql(@"Server=101.37.25.170;database=coretest1;uid=sheca@2017;pwd=YM2U8MM9;");

        }

        /// <summary>
        /// 实体创建
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

        }

        public DbSet<GZY_Advertisement> GZY_Advertisement { get; set; }
        public DbSet<GZY_UserAdmin> GZY_UserAdmin { get; set; }
        public DbSet<GZY_Article> GZY_Article { get; set; }
        public DbSet<GZY_Column> GZY_Column { get; set; }
    }
}
