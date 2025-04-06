using FluentValidation;
using MediatR;

namespace TestADRES.Application.Behaviours
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                // validar y ejecutar validaciones que se crearon en los Validators de los Commands
                var validationResults = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                // si tengo errores de validacion
                if (failures.Count() > 0)
                {
                    throw new ValidationException(failures);
                }
            }

            // continua el flujo
            return await next();
        }
    }
}
