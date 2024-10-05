using VV.ModelsEntity;
using VV.Interface;
using VV.iService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


//builder.Services.AddDbContext<VVDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("VVConnection")));

builder.Services.AddDbContext<VVDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("VVConnection"),
        sqlOptions => sqlOptions.MigrationsAssembly("VidyalayaVikas")));


builder.Services.AddScoped<iStudent_Interface, iStudent_Service>();
builder.Services.AddScoped<iClass_Interface, iClass_Service>();
builder.Services.AddScoped<iErrorLogging_Service>();
    


// Add services to the container.

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
