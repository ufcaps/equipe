using System.Net;

namespace Backend.Core.Application.Exceptions;

public sealed class NotFoundException(string message)
    : HttpException(message, HttpStatusCode.NotFound);
