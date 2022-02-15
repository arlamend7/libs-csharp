using System;
using System.Reflection;

namespace Libs.System.Extensions
{
    public static class GenericExtensions
    {
        public static TResult ParseOrDefault<T, TResult>(this T value)
        {
            TryConvert(value, out TResult teste);
            return teste;
        }
        public static bool TryConvert<T, TResult>(this T stringValue, out TResult convertedValue)
        {
            convertedValue = default;
            Type targetType = typeof(TResult);
            Type[] argTypes = { typeof(T), targetType.MakeByRefType() };
            MethodInfo tryParseMethodInfo = targetType.GetMethod("TryParse", argTypes);
            if (tryParseMethodInfo == null) return false;
            object[] args = { stringValue, null };
            bool successfulParse = (bool)tryParseMethodInfo.Invoke(null, args);
            if (!successfulParse) return false;
            convertedValue = (TResult)args[1];
            return true;
        }
        public static TResult MapValue<T,TResult>(this T source, Func<T, TResult> memb)
        {
            return memb(source);
        }
    }
}
