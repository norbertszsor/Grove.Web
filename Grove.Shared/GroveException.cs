using Grove.Shared.Enums;

namespace Grove.Shared
{
    public class GroveException(GroveError groveError) : Exception(groveError.ToString())
    {
    }
}
