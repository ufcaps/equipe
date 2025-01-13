using System.Net;

namespace Backend.Core.Application.Exceptions;

public sealed class UnauthorizedException(string message)
    : HttpException(message, HttpStatusCode.Unauthorized);
