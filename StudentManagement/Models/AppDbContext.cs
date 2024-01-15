using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Models
{
    public class AppDbContext : DbContext//数据库上下文，表示与数据库的会话，并提供了对数据库的访问和管理实体的功能
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        // :base(options) :调用基类构造函数的方式，其中基类是DbContext。通过传递options给基类的构造函数，告诉Entity Framework Core如何配置和连接到数据库。
        //DbContextOptions 实例会承载应用中的配置信息，如连接字符串，数据库提供商使用等

        {

        }
        public DbSet<Student> Students { get; set; }
        //使用此 DbSet 类型的属性 Students 来查询和保存 Student 类的实例。针对 DbSet<TEntity>的 LINQ 查询将被转换为针对底层数据库的查询
        protected override void OnModelCreating(ModelBuilder modelBuilder)//使用 modelBuilder 参数来配置实体之间的关系、主键、外键、索引等信息
        {
            modelBuilder.Seed();
        }
    }
}
