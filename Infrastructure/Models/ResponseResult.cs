namespace Infrastructure.Models;

public enum StatusCodes
{
    Ok = 200,
    Created = 201,
    BadRequest = 400,
    Unauthorized = 401,
    Forbidden = 403,
    NotFound = 404,
    InternalServerError = 500
}

public class ResponseResult
{
    public StatusCodes StatusCode { get; set; }
    public string Message { get; set; } = null!;
    public object? ContentResult { get; set; }
}
