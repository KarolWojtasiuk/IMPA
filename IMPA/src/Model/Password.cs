using System;
using System.Linq;
using System.Security.Cryptography;

namespace IMPA
{
    public struct Password
    {
        public string PasswordHash;
        public string PasswordSalt;

        public Password(string password)
        {
            PasswordHash = String.Empty;
            PasswordSalt = String.Empty;

            ChangePassword(password);
        }

        internal void ChangePassword(string password)
        {
            using var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, 16, 100000, HashAlgorithmName.SHA512);

            PasswordHash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(16));
            PasswordSalt = Convert.ToBase64String(rfc2898DeriveBytes.Salt);
        }

        public bool VerifyPassword(string passwordToVerify)
        {
            var hash = Convert.FromBase64String(PasswordHash);
            var salt = Convert.FromBase64String(PasswordSalt);

            using var rfc2898DeriveBytes = new Rfc2898DeriveBytes(passwordToVerify, salt, 100000, HashAlgorithmName.SHA512);

            var newHash = rfc2898DeriveBytes.GetBytes(16);
            return newHash.SequenceEqual(hash);
        }
    }
}
