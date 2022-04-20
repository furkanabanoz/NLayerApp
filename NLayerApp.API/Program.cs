using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using NLayerApp.API.Filters;
using NLayerApp.Core.Repositories;
using NLayerApp.Core.Services;
using NLayerApp.Core.UnitOfWorks;
using NLayerApp.Repository;
using NLayerApp.Repository.Repositories;
using NLayerApp.Repository.UnitOfWorks;
using NLayerApp.Service.Mapping;
using NLayerApp.Service.Services;
using NLayerApp.Service.Validations;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{ 
    options.Filters.Add(new ValidateFilterAttribute());

}).AddFluentValidation(x=>x.RegisterValidatorsFromAssemblyContaining<ProductDtoValidator>());//addFluentValidation u ekliyoruz
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();//IUnitOfWork ile karsilasirsa UnitOfWork u nesne ornegi alacagini gosteriyoruz
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));//generic aldigi icin typeof ile gosteriyoruz ve yanina isaretleri icleri bos birsekilde yaziyoruz,eger birden fazla entity alsaydi virgul koyacaktik ne kadar aldigina gore
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));



builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddDbContext<AppDbContext>(x => 
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultString"), option => 
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name); 
        //repository libarysinin de adini verebilirisniz yukariya ya da bizim yaptigimiz gibi dinamik bir sekilde verirsek ileride ugrasmadan kalabilir burasi
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
