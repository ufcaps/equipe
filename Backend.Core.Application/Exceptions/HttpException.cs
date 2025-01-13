using System.Net;

namespace Backend.Core.Application.Exceptions;

public class HttpException(string message, HttpStatusCode statusCode) : Exception(message)
{
    public int StatusCode = (int)statusCode;
}
