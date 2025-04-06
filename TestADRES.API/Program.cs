using FluentValidation;
using TestADRES.API.Middleware;
using TestADRES.Application;
using TestADRES.Application.Features.Requirements.Commands.CreateRequirement;
using TestADRES.Infrastructure;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();

        builder.Services.AddInfraestructuraServices(builder.Configuration);
        builder.Services.AddAplicationServices();

        builder.Services.AddValidatorsFromAssemblyContaining<CreateRequirementCommandValidator>();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseMiddleware<ExceptionMiddleware>();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseCors("CorsPolicy");

        app.MapControllers();

        app.Run();
    }
}