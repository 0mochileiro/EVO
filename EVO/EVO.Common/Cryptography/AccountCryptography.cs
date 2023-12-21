using System.Text;
using System.Security.Cryptography;

namespace EVO.Common.Cryptography;

public static class AccountCryptography
{
    public static (byte[] hash, byte[] salt) GenerateHMACSHA512Hash(string password)
    {
        using (var hmac = new HMACSHA512())
        {
            var salt = hmac.Key;

            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return (hash, salt);
        }
    }

    public static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
    {
        if (password == null) throw new ArgumentException("Value cannot be null password", "password");
        if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
        if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
        if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

        using (var hmac = new HMACSHA512(storedSalt))
        {
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return computedHash.SequenceEqual(storedHash);
        }
    }
}
