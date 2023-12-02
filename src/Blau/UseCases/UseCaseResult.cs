namespace Blau.UseCases;

public interface IUseCaseResult
{
    bool IsSuccess { get; init; }
    List<string> ErrorMessages { get; init; }
}

public class UseCaseResult : IUseCaseResult
{
    public bool IsSuccess { get; init; }
    public List<string> ErrorMessages { get; init; } = [];

    public static UseCaseResult Success()
    {
        return new UseCaseResult { IsSuccess = true };
    }

    public static UseCaseResult Fail(string error)
    {
        return Fail([error]);
    }

    public static UseCaseResult Fail(List<string> errors)
    {
        return new UseCaseResult { IsSuccess = false, ErrorMessages = errors };
    }
}

public interface IUseCaseResult<TUseCaseResponse> : IUseCaseResult
    where TUseCaseResponse : class, IUseCaseResponse
{
    TUseCaseResponse? Data { get; init; }
}

public class UseCaseResult<TUseCaseResponse> : UseCaseResult, IUseCaseResult<TUseCaseResponse>
    where TUseCaseResponse : class, IUseCaseResponse
{
    public TUseCaseResponse? Data { get; init; }

    public static new UseCaseResult<TUseCaseResponse> Success()
    {
        return new UseCaseResult<TUseCaseResponse> { IsSuccess = true };
    }

    public static UseCaseResult<TUseCaseResponse> Success(TUseCaseResponse response)
    {
        return new UseCaseResult<TUseCaseResponse> { IsSuccess = true, Data = response };
    }

    public static new UseCaseResult<TUseCaseResponse> Fail(string error)
    {
        return Fail([error]);
    }

    public static new UseCaseResult<TUseCaseResponse> Fail(List<string> errors)
    {
        return new UseCaseResult<TUseCaseResponse> { IsSuccess = false, ErrorMessages = errors };
    }
}
