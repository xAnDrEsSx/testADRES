using MediatR;

namespace TestADRES.Application.Behaviours
{
    public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {

        // logger

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                var requestName = typeof(TRequest).Name;
                Console.WriteLine(ex.Message,"Application Request: Sucedio una excepcion para el request {Name} {@Request}", requestName, request );
                // log
                throw;
            }
        }
    }
}
