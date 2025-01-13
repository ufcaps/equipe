using System.Net;

namespace Backend.Core.Application.Exceptions;

public sealed class InternalServerErrorException(string message)
    : HttpException(message, HttpStatusCode.InternalServerError);
