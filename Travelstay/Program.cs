using Microsoft.EntityFrameworkCore;
using Travelstay.Controllers.Applications.MappingProfile;
//using Travelstay.Controllers.Applications.Mappings;
using Travelstay.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

string cs = builder.Configuration.GetConnectionString("TravelStayDb")!;
builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlServer(cs));

builder.Services.AddAutoMapper(cfg => { }, typeof(MappingProfile));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors(p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();