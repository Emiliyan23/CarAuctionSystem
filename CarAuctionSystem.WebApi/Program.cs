using Microsoft.EntityFrameworkCore;

using CarAuctionSystem.Core.Contracts;
using CarAuctionSystem.Core.Services;
using CarAuctionSystem.Infrastructure.Data;
using CarAuctionSystem.Infrastructure.Data.Common;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<CarAuctionDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IAuctionService, AuctionService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(setup =>
{
	setup.AddPolicy("CarAuctionSystem", policyBuilder =>
	{
		policyBuilder.WithOrigins("https://localhost:7203")
			.AllowAnyHeader()
			.AllowAnyMethod();
	});
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("CarAuctionSystem");

app.Run();
