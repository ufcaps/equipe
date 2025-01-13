using System.Net;

namespace Backend.Core.Application.Exceptions;

public sealed class ConflictException(string message)
    : HttpException(message, HttpStatusCode.Conflict);
