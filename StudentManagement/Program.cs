using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;

var builder = WebApplication.CreateBuilder(args);//生成一个WebApplicationBuilder实例

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("StudentDBConnection")));
//builder.Services.AddMvc();
//builder.Services.AddSingleton<IStudentRepository, MockStudentRepository>();//绑定依赖注入容器和服务，使得HomeController(IStudentRepository studentRepository)方法接受到需要的实例
builder.Services.AddScoped<IStudentRepository,SQLStudentRepository>();

var app = builder.Build();//构建

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())//异常提示
{
    var developmentExceptionPageOptions = new DeveloperExceptionPageOptions();
    developmentExceptionPageOptions.SourceCodeLineCount = 10;
    app.UseDeveloperExceptionPage();
}
app.UseStaticFiles();//静态文件
//大部分中间件，尤其是路由的，放在静态文件之后

app.UseRouting();

app.UseAuthorization();


//app.MapRazorPages();//配置和启用 Razor 页面（Razor Pages）支持的方法,默认显示Index.cshtml

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Deatails}/{id?}");

});
// Redirect to Home/Details when the root URL is accessed.
app.MapGet("/", context =>
{
    context.Response.Redirect("/Home/Details");
    return Task.CompletedTask;
});

app.Run();
