using Grove.Shared.Enums;
using Grove.Shared.Helpers;

namespace Grove.Shared.Extensions
{
    public static class EnumExtension
    {
        public static void Throw(this GroveError groveError) => ThrowHelper.Throw(groveError);
    }
}
