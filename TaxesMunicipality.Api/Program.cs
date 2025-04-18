using TaxesMunicipality.Core.Interfaces;
using TaxesMunicipality.Core.Services;
using TaxesMunicipality.Data;
using TaxesMunicipality.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// DI
builder.Services.AddScoped<IMunicipalityTaxService, MunicipalityTaxService>();
builder.Services.AddScoped<IMunicipalityTaxRepository, MunicipalityTaxRepository>();
builder.Services.AddDbContext<TaxesDbContext>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetService<TaxesDbContext>();
    dbContext.Database.EnsureCreated();
}

app.Run();
