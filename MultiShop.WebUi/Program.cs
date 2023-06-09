using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MultiShop.Business.Abstract;
using MultiShop.Business.AutoMapper;
using MultiShop.Business.Concreate;
using MultiShop.Core.DataAcces.MongoDB.MongoSettings;
using MultiShop.Core.Entities.Concreate;
using MultiShop.Core.Helpers;
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


//Order
builder.Services.AddScoped<IOrderDal, EfOrderDal>();
builder.Services.AddScoped<IOrderService, OrderManager>();




// Gelen Ders 
builder.Services.AddScoped<IDatabseSettings, DatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});
//todo AppDbContext => 

builder.Services.AddScoped<AppDbContext>();


builder.Services.AddDefaultIdentity<User>().AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();



var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


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


///=>>>
app.UseAuthentication();
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
