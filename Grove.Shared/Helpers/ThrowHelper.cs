using Grove.Shared.Enums;

namespace Grove.Shared.Helpers
{
    public static class ThrowHelper
    {
        public static void Throw(GroveError groveError) => throw new GroveException(groveError);
    }
}
