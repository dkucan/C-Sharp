using VIdeoteka.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// prilagodba za dokumentaciju, èitati https://medium.com/geekculture/customizing-swagger-in-asp-net-core-5-2c98d03cbe52

builder.Services.AddSwaggerGen(sgo => { // sgo je instanca klase SwaggerGenOptions
    // èitati https://devintxcontent.blob.core.windows.net/showcontent/Speaker%20Presentations%20Fall%202017/Web%20API%20Best%20Practices.pdf
    var o = new Microsoft.OpenApi.Models.OpenApiInfo()
    {
        Title = "Videoteka API",
        Version = "v1",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact()
        {
            Email = "dkucan61@gmail.com",
            Name = "Darko Kucan"
        },
        Description = "Ovo je dokumentacija za Videoteka API",
        License = new Microsoft.OpenApi.Models.OpenApiLicense()
        {
            Name = "Edunova licenca"
        }
    };
    sgo.SwaggerDoc("v1", o);


});


// dodavanje baze podataka
builder.Services.AddDbContext<videotekaContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString(name: "videotekaContext"),
        sqlServerOptionsAction: sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
        });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(opcije =>
    {
        opcije.SerializeAsV2 = true;
    });
    app.UseSwaggerUI(opcije =>
    {
        opcije.ConfigObject.
        AdditionalItems.Add("requestSnippetsEnabled", true);
    });
}

app.UseHttpsRedirection();


app.MapControllers();

app.Run();
