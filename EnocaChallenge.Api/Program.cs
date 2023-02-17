using EnocaChallenge.Business.Abstract;
using EnocaChallenge.Business.AutoMappers;
using EnocaChallenge.Business.Concrete;
using EnocaChallenge.DataAccess.Abstract;
using EnocaChallenge.DataAccess.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IFirmaDal, EfFirmaDal>();
builder.Services.AddScoped<IFirmaService, FirmaManager>();

builder.Services.AddScoped<IUrunDal, EfUrunDal>();
builder.Services.AddScoped<IUrunService, UrunManager>();

builder.Services.AddScoped<ISiparisDal, EfSiparisDal>();
builder.Services.AddScoped<ISiparisService, SiparisManager>();

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
