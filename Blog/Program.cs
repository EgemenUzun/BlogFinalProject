using Project.DataBase.Business.Abstract;
using Project.DataBase.Business.Concrete;
using Project.DataBase.DataAccess.Abstract;
using Project.DataBase.DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddSession();
//Dependecy Injection start
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IUserDal, EfUserDal>();

builder.Services.AddScoped<IBlogPostService, BlogPostManager>();
builder.Services.AddScoped<IBlogPostDal, EfBlogPostDal>();

builder.Services.AddScoped<ICommentService, CommentManager>();
builder.Services.AddScoped<ICommentDal, EFCommentDal>();
//Dependecy Injection end

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapRazorPages();

app.UseMvc(ConfigureRoutes);
void ConfigureRoutes(IRouteBuilder routeBuilder)
{
    routeBuilder.MapRoute("Default", "{controller=Account}/{action=Login}/{id?}");
}
app.UseRouting();

app.Run();
