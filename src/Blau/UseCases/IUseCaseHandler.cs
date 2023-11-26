namespace Blau.UseCases;

public interface IUseCaseHandler<TResponse>
    where TResponse : class, IUseCaseResponse
{
    Task<TResponse> Handle();
}

public interface IUseCaseHandler<TRequest, TResponse>
    where TRequest : class, IUseCaseRequest
    where TResponse : class, IUseCaseResponse
{
    Task<TResponse> Handle(TRequest request);
}
