namespace AddisEats.Api.Common;

public record Error(
    string Code,
    string Message,
    int Status
);

public class Result<T>
{
    public T? Value { get; init; }

    public Error? Error { get; init; }

    public bool IsSuccess => Error is null;

    public static Result<T> OK(T value)
    => new() { Value = value };

    public static Result<T> Fail(
        string code, 
        string message, 
        int status)
        =>new()
        {
            Error = new Error(code, message, status)
        };
    //public static Result<T> Success(T value) => new Result<T>(value);
    //public static Result<T> Failure(Error error) => new Result<T>(error);
}