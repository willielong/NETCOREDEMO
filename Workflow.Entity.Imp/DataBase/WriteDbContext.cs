

/****************************************************************************
* 类名：WriteDbContext（读取）/ReadDbContext（写入）
* 描述：进行数据库操作
* 创建人：李文龙
* 创建时间：208.04.22 16：43
* 修改人;李文龙
* 修改时间：2018.05.04
* 修改描述：
* **************************************************************************
*/

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Workflow.comm;

namespace Workflow.Entity.Imp.DataBase
{


    public class BaseContext : DbContext
    {

        public BaseContext(DbContextOptions opeions) : base(opeions) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserKey>()
                .HasOne<Department>()
                .WithMany(e => e.users)//配置这个多对多关系的另一端,另一端通过导航属性能够被访问(此处表明一个员工拥有一个项目对象的集合)  
                .HasForeignKey(e => e.ognId);
            modelBuilder.Entity<UserKey>()
                .HasOne<User>()
                .WithMany(p => p.Departments)
                .HasForeignKey(p => p.userId);
            modelBuilder.Entity<Company>()
                .HasMany<Department>(p => p.Departments)
                .WithOne()
                .HasForeignKey(p => p.unitId);
            modelBuilder.Entity<Permission>();

            modelBuilder.Entity<UserRole>()
                .HasOne<User>()
                .WithMany(k => k.roles)
                .HasForeignKey(k => k.user_id);
            modelBuilder.Entity<UserRole>()
              .HasOne<Role>()
              .WithMany(k => k.users)
              .HasForeignKey(k => k.code);

            modelBuilder.Entity<OpreationMiddle>()
              .HasOne<User>()
              .WithMany(k => k.opmodel)
              .HasForeignKey(k => k.person);
            modelBuilder.Entity<OpreationMiddle>()
              .HasOne<Role>()
              .WithMany(k => k.opmodel)
              .HasForeignKey(k => k.person);

            modelBuilder.Entity<OpreationMiddle>()
             .HasOne<Permission>()
             .WithMany(k => k.opmodel)
             .HasForeignKey(k => k.permission_id);
            modelBuilder.Entity<OpreationMiddle>()
              .HasOne<Workbench>()
              .WithMany(k => k.opmodel)
              .HasForeignKey(k => k.workbench_code);
            modelBuilder.Entity<OpreationMiddle>()
              .HasOne<Operation>()
              .WithMany(k => k.opmodel)
              .HasForeignKey(k => k.operation_id);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserKey> UserKey { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<UserRole> userRole { get; set; }
    }
    /// <summary>
    /// 进行写入数据操作
    /// </summary>
    public class WriteDbContext : BaseContext
    {
        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options) { }

        public WriteDbContext() : base(new DbContextOptionsBuilder().UseSqlServer(comm.ConstantHelper.GetDbBaseConnection().ms_write_connection).Options) { }
        // public DbSet<object> oBject { get; set; }

       
    }
    /// <summary>
    /// 进行读取数据操作
    /// </summary>
    public class ReadDbContext : BaseContext
    {
        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options) { }
        public ReadDbContext() : base(new DbContextOptionsBuilder().UseSqlServer(comm.ConstantHelper.GetDbBaseConnection().ms_read_connection).Options) { }

    }
}
