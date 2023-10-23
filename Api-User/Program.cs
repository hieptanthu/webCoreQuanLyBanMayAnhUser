using BLL;
using BLL.Interfaces;
using DAL.Repository;
using DAL.Repository.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Repository;
using DataAccessLayer.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddTransient<IDatabaseHelper, DatabaseHelper>();

builder.Services.AddTransient<IDanhMucRepository, DanhMucRepository>();
builder.Services.AddTransient<IDonHangRepository, DonHangRepository>();
builder.Services.AddTransient<ISanPhamRepository, SanPhamRepository>();
builder.Services.AddTransient<ITaiKhoanQuanLyRepository, TaiKhoanQuanLyRepository>();
builder.Services.AddTransient<IthuongHieuRepository, ThuongHieuRepository>();

//bll
builder.Services.AddTransient<IDanhMucBusiness, DanhMucBusiness>();
builder.Services.AddTransient<IDonHangBusiness, DonHangBusiness>();
builder.Services.AddTransient<ISanPhamBusiness, SanPhamBusiness>();

builder.Services.AddTransient<IThuongHieuBusiness, ThuongHieuBusiness>();




builder.Services.AddCors(options =>
{

    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.WithOrigins("*") // Ði?u ch?nh tên mi?n ho?c d?a ch? IP c?a ?ng d?ng web c?a b?n.
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowSpecificOrigin");
app.MapControllers();
app.Run();

