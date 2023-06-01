using Microsoft.Extensions.Options;
using MultiShop.Business.Abstract;
using MultiShop.Business.Concreate;
using MultiShop.Core.DataAcces.MongoDB.MongoSettings;
using MultiShop.DataAcces.Abstract;
using MultiShop.DataAcces.Concrete.EntityFramework;
using MultiShop.DataAcces.Concrete.MongoDb;

var builder = WebApplication.CreateBuilder(args);
//

// todo Mongo Db ucun JSonun icerisini Odutub Databasessetings icerisine birlesdirdi 
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));


builder.Services.AddControllersWithViews();
//todo INterface ucun OLAN HISSE HANSI interface hansi KLasla ise dusecek Onu yaziriq 
builder.Services.AddScoped<IProductsServices, ProducManager>();
builder.Services.AddScoped<IProductDal, MProductDal>();
// Category 
builder.Services.AddScoped<ICategoryServices, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, MCategoryDal>();


// Gelen Ders 
builder.Services.AddScoped<IDatabseSettings, DatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
