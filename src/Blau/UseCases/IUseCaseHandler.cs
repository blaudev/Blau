namespace Blau.UseCases;

public interface IUseCaseHandler<TResponse>
    where TResponse : class, IUseCaseResponse
{
    Task<TResponse> HandleAsync();
}

public interface IUseCaseHandler<TRequest, TResponse>
    where TRequest : class, IUseCaseRequest
    where TResponse : class, IUseCaseResponse
{
    Task<TResponse> HandleAsync(TRequest request);
}
