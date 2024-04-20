using Grove.Shared.Enums;

namespace Grove.Shared.Helpers
{
    public static class ThrowHelper
    {
        public static GroveException Throw(GroveError groveError) => throw new GroveException(groveError);
    }
}
