namespace Blau.UseCases;

public interface IUseCaseHandler
{
}

public interface IUseCaseHandler<TResponse> : IUseCaseHandler
    where TResponse : class, IUseCaseResponse
{
    Task<TResponse> Handle();
}

public interface IUseCaseHandler<TRequest, TResponse> : IUseCaseHandler<TResponse>
    where TRequest : class, IUseCaseRequest
    where TResponse : class, IUseCaseResponse
{
    Task<TResponse> Handle(TRequest request);
}
