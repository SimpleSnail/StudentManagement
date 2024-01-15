using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;

var builder = WebApplication.CreateBuilder(args);//����һ��WebApplicationBuilderʵ��

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("StudentDBConnection")));
//builder.Services.AddMvc();
//builder.Services.AddSingleton<IStudentRepository, MockStudentRepository>();//������ע�������ͷ���ʹ��HomeController(IStudentRepository studentRepository)�������ܵ���Ҫ��ʵ��
builder.Services.AddScoped<IStudentRepository,SQLStudentRepository>();

var app = builder.Build();//����

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())//�쳣��ʾ
{
    var developmentExceptionPageOptions = new DeveloperExceptionPageOptions();
    developmentExceptionPageOptions.SourceCodeLineCount = 10;
    app.UseDeveloperExceptionPage();
}
app.UseStaticFiles();//��̬�ļ�
//�󲿷��м����������·�ɵģ����ھ�̬�ļ�֮��

app.UseRouting();

app.UseAuthorization();


//app.MapRazorPages();//���ú����� Razor ҳ�棨Razor Pages��֧�ֵķ���,Ĭ����ʾIndex.cshtml

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
