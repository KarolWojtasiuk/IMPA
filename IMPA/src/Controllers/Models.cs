using System;

namespace IMPA
{
    public record ErrorResult(string ExceptionType, string ExceptionMessage);
    public record CreateResult(Guid Id, DateTime CreationDate);
    public record InfoResult(string Title, string Description, string Version);

    public record UserModel(string Username, string Password);
}
