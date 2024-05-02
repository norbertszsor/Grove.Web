namespace Grove.Logic.Abstraction
{
    public interface ICryptService
    {
        string HashString(string value);

        bool Verify(string value, string hash);
    }
}
