namespace Blau.UseCases;

public interface IUseCaseHandler
{
    Task<IUseCaseResult> Handle(CancellationToken cancellationToken);
}

public interface IUseCaseHandler<TUseCaseResponse>
    where TUseCaseResponse : class, IUseCaseResponse
{
    Task<IUseCaseResult<TUseCaseResponse>> Handle(CancellationToken cancellationToken);
}

public interface IUseCaseHandler<in TUseCaseRequest, TUseCaseResponse>
    where TUseCaseRequest : class, IUseCaseRequest
    where TUseCaseResponse : class, IUseCaseResponse
{
    Task<IUseCaseResult<TUseCaseResponse>> Handle(TUseCaseRequest request, CancellationToken cancellationToken);
}
