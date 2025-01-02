using System.Text;

namespace System.Extensions
{
    public static class StringExtensions
    {
        #region Enum

        /// <summary>
        /// Gets the name of the enum value as a string.
        /// </summary>
        /// <typeparam name="TEnum">The enum type.</typeparam>
        /// <param name="source">The enum value.</param>
        /// <returns>The name of the enum value.</returns>
        public static string GetName<TEnum>(this TEnum source)
            where TEnum : Enum
        {
            return Enum.GetName(typeof(TEnum), source);
        }

        /// <summary>
        /// Gets the integer value of the enum as a string.
        /// </summary>
        /// <typeparam name="TEnum">The enum type.</typeparam>
        /// <param name="source">The enum value.</param>
        /// <returns>The integer value of the enum as a string.</returns>
        public static string GetValue<TEnum>(this TEnum source)
            where TEnum : Enum
        {
            return source.ToInt().ToString();
        }

        /// <summary>
        /// Gets the integer value of the enum as a formatted string.
        /// </summary>
        /// <typeparam name="TEnum">The enum type.</typeparam>
        /// <param name="source">The enum value.</param>
        /// <param name="format">The format string.</param>
        /// <returns>The formatted integer value of the enum as a string.</returns>
        public static string GetValue<TEnum>(this TEnum source, string format)
            where TEnum : Enum
        {
            return source.ToInt().ToString(format);
        }

        /// <summary>
        /// Formats the enum value as a string using the specified format.
        /// </summary>
        /// <typeparam name="TEnum">The enum type.</typeparam>
        /// <param name="source">The enum value.</param>
        /// <param name="format">The format string.</param>
        /// <returns>The formatted enum value as a string.</returns>
        public static string Format<TEnum>(this TEnum source, string format)
            where TEnum : Enum
        {
            return Enum.Format(typeof(TEnum), source, format);
        }

        /// <summary>
        /// Converts the enum value to its integer representation.
        /// </summary>
        /// <typeparam name="TEnum">The enum type.</typeparam>
        /// <param name="source">The enum value.</param>
        /// <returns>The integer representation of the enum value.</returns>
        public static int ToInt<TEnum>(this TEnum source)
            where TEnum : Enum
        {
            return Convert.ToInt32(source);
        }

        #endregion

        #region String Comparisons

        /// <summary>
        /// Compares two strings for equality, ignoring case by default.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="target">The target string to compare.</param>
        /// <returns>True if the strings are equal; otherwise, false.</returns>
        public static bool Compare(this string source, string target)
        {
            return source.Compare(target, true);
        }

        /// <summary>
        /// Compares two strings for equality, with an option to ignore case.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="target">The target string to compare.</param>
        /// <param name="ignoreCase">Indicates whether to ignore case.</param>
        /// <returns>True if the strings are equal; otherwise, false.</returns>
        public static bool Compare(this string source, string target, bool ignoreCase)
        {
            return string.Compare(source, target, ignoreCase) == 0;
        }

        #endregion

        #region String Concatenation

        /// <summary>
        /// Concatenates the source string with an empty string.
        /// </summary>
        public static string Concat(this string source)
        {
            return string.Concat(source, string.Empty);
        }

        /// <summary>
        /// Concatenates the source string with another string.
        /// </summary>
        public static string Concat(this string source, string target)
        {
            return string.Concat(source, target);
        }

        /// <summary>
        /// Concatenates the source string with two additional strings.
        /// </summary>
        public static string Concat(this string source, string arg1, string arg2)
        {
            return string.Concat(source, arg1, arg2);
        }

        /// <summary>
        /// Concatenates the source string with three additional strings.
        /// </summary>
        public static string Concat(this string source, string arg1, string arg2, string arg3)
        {
            return string.Concat(source, arg1, arg2, arg3);
        }

        /// <summary>
        /// Concatenates the source string with a collection of objects.
        /// </summary>
        public static string Concat(this string source, params object[] args)
        {
            return string.Concat(source, string.Concat(args));
        }

        #endregion

        #region String Conversion

        /// <summary>
        /// Converts a Base64-encoded string to a byte array.
        /// </summary>
        /// <param name="str">The Base64-encoded string.</param>
        /// <returns>The decoded byte array.</returns>
        public static byte[] ToBase64(this string str)
        {
            return Convert.FromBase64String(str);
        }

        /// <summary>
        /// Converts a string to a boolean value.
        /// </summary>
        /// <param name="str">The string to convert.</param>
        /// <returns>True if the string represents a valid boolean value; otherwise, false.</returns>
        public static bool ToBool(this string str)
        {
            bool.TryParse(str, out bool value);
            return value;
        }

        /// <summary>
        /// Converts a string to a double value.
        /// </summary>
        /// <param name="str">The string to convert.</param>
        /// <returns>The double representation of the string, or 0 if the conversion fails.</returns>
        public static double ToDouble(this string str)
        {
            double.TryParse(str, out double value);
            return value;
        }

        /// <summary>
        /// Converts a string to a specified enum value.
        /// </summary>
        /// <typeparam name="TEnum">The enum type.</typeparam>
        /// <param name="str">The string to convert.</param>
        /// <returns>The enum value, or the default value if the conversion fails.</returns>
        public static TEnum ToEnum<TEnum>(this string str)
            where TEnum : struct, Enum
        {
            Enum.TryParse(str, true, out TEnum value);
            return value;
        }

        /// <summary>
        /// Converts a string to a float value.
        /// </summary>
        /// <param name="str">The string to convert.</param>
        /// <returns>The float representation of the string, or 0 if the conversion fails.</returns>
        public static float ToFloat(this string str)
        {
            float.TryParse(str, out float value);
            return value;
        }

        /// <summary>
        /// Converts a string to an integer value.
        /// </summary>
        /// <param name="str">The string to convert.</param>
        /// <returns>The integer representation of the string, or 0 if the conversion fails.</returns>
        public static int ToInt(this string str)
        {
            int.TryParse(str, out int value);
            return value;
        }

        /// <summary>
        /// Converts a string to a long value.
        /// </summary>
        /// <param name="str">The string to convert.</param>
        /// <returns>The long representation of the string, or 0 if the conversion fails.</returns>
        public static long ToLong(this string str)
        {
            long.TryParse(str, out long value);
            return value;
        }

        /// <summary>
        /// Converts a string to a UTF-8 encoded byte array.
        /// </summary>
        /// <param name="str">The string to convert.</param>
        /// <returns>The UTF-8 encoded byte array.</returns>
        public static byte[] ToUTF8(this string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }

        #endregion

        #region String Formatting

        /// <summary>
        /// Formats the source string with a single argument.
        /// </summary>
        public static string Format(this string source, string arg)
        {
            return string.Format(source, arg);
        }

        /// <summary>
        /// Formats the source string with two arguments.
        /// </summary>
        public static string Format(this string source, string arg1, string arg2)
        {
            return string.Format(source, arg1, arg2);
        }

        /// <summary>
        /// Formats the source string with three arguments.
        /// </summary>
        public static string Format(this string source, string arg1, string arg2, string arg3)
        {
            return string.Format(source, arg1, arg2, arg3);
        }

        /// <summary>
        /// Formats the source string with a collection of arguments.
        /// </summary>
        public static string Format(this string source, params object[] args)
        {
            return string.Format(source, args);
        }

        #endregion	

        #region String Manipulation

        /// <summary>
        /// Joins a collection of objects into a single string, using the source string as a separator.
        /// </summary>
        public static string Join(this string source, params object[] args)
        {
            return string.Join(source, args);
        }

        /// <summary>
        /// Removes all occurrences of a specified substring from the source string.
        /// </summary>
        public static string Remove(this string source, string target)
        {
            if (source.IsNullOrEmpty())
            {
                return string.Empty;
            }

            return source.Replace(target, string.Empty);
        }

        /// <summary>
        /// Converts the character at the specified index of the string to lowercase.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="index">The index of the character to convert.</param>
        /// <returns>The modified string with the specified character in lowercase.</returns>
        public static string ToLower(this string source, int index)
        {
            if (index < 0 || index >= source.Length)
            {
                return source;
            }

            char[] chars = source.ToCharArray();
            chars[index] = char.ToLower(chars[index]);
            return new string(chars);
        }

        /// <summary>
        /// Converts the character at the specified index of the string to uppercase.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="index">The index of the character to convert.</param>
        /// <returns>The modified string with the specified character in uppercase.</returns>
        public static string ToUpper(this string source, int index)
        {
            if (index < 0 || index >= source.Length)
            {
                return source;
            }

            char[] chars = source.ToCharArray();
            chars[index] = char.ToUpper(chars[index]);
            return new string(chars);
        }

        /// <summary>
        /// Safely retrieves a substring starting at the specified index.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="index">The starting index of the substring.</param>
        /// <returns>The substring, or an empty string if the index is out of bounds.</returns>
        public static string TrySub(this string source, int index)
        {
            if (index >= source.Length)
            {
                return string.Empty;
            }

            return source.Substring(index);
        }

        /// <summary>
        /// Safely retrieves a substring starting at the specified index and of the specified length.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="index">The starting index of the substring.</param>
        /// <param name="length">The length of the substring.</param>
        /// <returns>The substring, or an empty string if the index or length is out of bounds.</returns>
        public static string TrySub(this string source, int index, int length)
        {
            if (index < 0 || index + length > source.Length)
            {
                return string.Empty;
            }

            return source.Substring(index, length);
        }

        #endregion

        #region String Splitting

        /// <summary>
        /// Splits a string into substrings using a collection of separators, removing empty entries.
        /// </summary>
        public static string[] TrySplit(this string source, params string[] separators)
        {
            if (source.IsNullOrEmpty())
            {
                return Array.Empty<string>();
            }

            return source.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Splits a string into substrings using a collection of character separators, removing empty entries.
        /// </summary>
        public static string[] TrySplit(this string source, params char[] separators)
        {
            if (source.IsNullOrEmpty())
            {
                return Array.Empty<string>();
            }

            return source.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        }

        #endregion

        #region String Validations

        /// <summary>
        /// Determines whether a string represents a defined value in an enum type.
        /// </summary>
        public static bool IsDefined<TEnum>(this string str)
            where TEnum : Enum
        {
            return Enum.IsDefined(typeof(TEnum), str);
        }

        /// <summary>
        /// Checks if a string is null or empty.
        /// </summary>
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        /// <summary>
        /// Checks if a string is null, empty, or consists only of white-space characters.
        /// </summary>
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        /// <summary>
        /// Checks if a string contains only letters or digits.
        /// </summary>
        public static bool IsLetterOrDigit(this string str)
        {
            if (str == null)
            {
                return false;
            }

            foreach (char ch in str)
            {
                if (!char.IsLetterOrDigit(ch))
                {
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region StringBuilder

        /// <summary>
        /// Removes all occurrences of a specified string from the StringBuilder.
        /// </summary>
        /// <param name="source">The StringBuilder instance.</param>
        /// <param name="str">The string to remove.</param>
        public static void Remove(this StringBuilder source, string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return;
            }

            source.Replace(str, string.Empty);
        }

        #endregion
    }
}