using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using TestADRES.Application.Behaviours;

namespace TestADRES.Application
{
    public static class DependencyInyection
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


            return services;
        }
    }
}