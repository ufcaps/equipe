namespace Backend.Core.Domain.Interfaces;

public interface IJwtTokenGenerator
{
    string Generate(int id, string email);
}
