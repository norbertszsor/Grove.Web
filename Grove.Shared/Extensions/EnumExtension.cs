using Grove.Shared.Enums;
using Grove.Shared.Helpers;

namespace Grove.Shared.Extensions
{
    public static class EnumExtension
    {
        public static GroveException Throw(this GroveError groveError) => ThrowHelper.Throw(groveError);
    }
}
