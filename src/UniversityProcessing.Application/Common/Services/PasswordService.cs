using UniversityProcessing.Application.Common.Interfaces;

namespace UniversityProcessing.Application.Common.Services;

public class PasswordService : IPasswordService
{
    public string HashPassword(string password)
    {
        return new PasswordHasher<object?>().HashPassword(null, password);
    }

    public bool VerifyPassword(string password, string hash)
    {
        return new PasswordHasher<object?>().VerifyHashedPassword(
            null, 
            hash, 
            password) != PasswordVerificationResult.Failed;
    }
}