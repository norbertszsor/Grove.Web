namespace Grove.Logic.Helpers
{
    public static class CryptHelper
    {
        public static string HashString(string value)
        {
            return BCrypt.Net.BCrypt.HashPassword(value);
        }

        public static bool Verify(string value, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(value, hash);
        }
    }
}
