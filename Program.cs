using biochallenge.DB;
using biochallenge.Models;
using biochallenge.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var sqlServerConnection = builder.Configuration.GetConnectionString("SqlServerConnection");
var mySqlConnection = builder.Configuration.GetConnectionString("MySqlConnection");


// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

var e = builder.Configuration.GetSection("Env").Value;

if (e.ToString().ToLower().Equals("development"))
{
	builder.Services.AddDbContextPool<Database>(
		options => options.UseSqlServer(sqlServerConnection)
	);
}
else if (e.ToString().ToLower().Equals("production"))
{
	builder.Services.AddDbContextPool<Database>(
		options => options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection))
	);
}



builder.Services.AddSwaggerGen(options =>
{
	options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
	{
		Description = "Standard Authorization using Bearer scheme",
		In = ParameterLocation.Header,
		Name = "Authorization",
		Type = SecuritySchemeType.ApiKey
	});

	options.OperationFilter<SecurityRequirementsOperationFilter>();
});



builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAll",
		builder =>
		{
			builder.AllowAnyOrigin()
				.AllowAnyHeader()
				.AllowAnyMethod();
		});
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
else if (app.Environment.IsProduction())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}


app.UseAuthentication();
app.UseAuthorization();

app.UseCors("AllowAll");


app.MapControllers();

app.Run();