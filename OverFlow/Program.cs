
using Microsoft.EntityFrameworkCore;
using OverFlow.Application.Mapping;
using OverFlow.Infrastructure.Base.Interface;
using OverFlow.Infrastructure.Base.Repository;
using OverFlow.Infrastructure.Context;
using OverFlow.Infrastructure.Usuario.Interface;
using OverFlow.Infrastructure.Usuario.Repository;

namespace OverFlow;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(
                builder.Configuration.GetConnectionString("DefaultConnection")
            )
        );

        
        //registro de repositorys
        builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        //registro de automapper
        builder.Services.AddAutoMapper(config => { },typeof(MappingProfile));

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
    }
}
