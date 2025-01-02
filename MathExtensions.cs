
namespace System.Extensions
{
    public static class MathExtensions
    {
        #region Boolean

        /// <summary>
        /// Converts a boolean value to an integer (0 or 1).
        /// </summary>
        /// <param name="value">The boolean value.</param>
        /// <returns>An integer representation of the boolean value.</returns>
        public static int ToInt(this bool value)
        {
            return Convert.ToInt32(value);
        }

        /// <summary>
        /// Converts a boolean value to a float (0.0f or 1.0f).
        /// </summary>
        /// <param name="value">The boolean value.</param>
        /// <returns>A float representation of the boolean value.</returns>
        public static float ToFloat(this bool value)
        {
            return Convert.ToSingle(value);
        }

        #endregion

        #region Double

        /// <summary>
        /// Rounds a double value to the nearest integer, away from zero.
        /// </summary>
        /// <param name="value">The double value.</param>
        /// <returns>The rounded value.</returns>
        public static double Round(this double value)
        {
            return Math.Round(value, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Rounds a double value to the specified number of decimal places, away from zero.
        /// </summary>
        /// <param name="value">The double value.</param>
        /// <param name="digits">The number of decimal places.</param>
        /// <returns>The rounded value.</returns>
        public static double Round(this double value, int digits)
        {
            return Math.Round(value, digits, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Truncates a double value to the integer part.
        /// </summary>
        /// <param name="value">The double value.</param>
        /// <returns>The truncated value.</returns>
        public static double Truncate(this double value)
        {
            return Math.Truncate(value);
        }

        /// <summary>
        /// Converts a double value to a float.
        /// </summary>
        /// <param name="value">The double value.</param>
        /// <returns>A float representation of the double value.</returns>
        public static float ToFloat(this double value)
        {
            return Convert.ToSingle(value);
        }

        /// <summary>
        /// Converts a double value to an integer.
        /// </summary>
        /// <param name="value">The double value.</param>
        /// <returns>An integer representation of the double value.</returns>
        public static int ToInt(this double value)
        {
            return Convert.ToInt32(value);
        }

        #endregion

        #region Float

        /// <summary>
        /// Returns the absolute value of a float.
        /// </summary>
        /// <param name="value">The float value.</param>
        /// <returns>The absolute value.</returns>
        public static float Abs(this float value)
        {
            return Math.Abs(value);
        }

        /// <summary>
        /// Clamps a float value to the specified range.
        /// </summary>
        /// <param name="value">The float value.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>The clamped value.</returns>
        public static float Clamp(this float value, float min, float max)
        {
            return Math.Max(min, Math.Min(max, value));
        }

        /// <summary>
        /// Clamps a float value, returning 0.0f if it is NaN or infinity.
        /// </summary>
        /// <param name="value">The float value.</param>
        /// <returns>The clamped value or 0.0f if invalid.</returns>
        public static float ClampNaN(this float value)
        {
            return float.IsNaN(value) || float.IsInfinity(value) ? 0f : value;
        }

        /// <summary>
        /// Calculates the distance between two float values.
        /// </summary>
        /// <param name="source">The source value.</param>
        /// <param name="destination">The destination value.</param>
        /// <returns>The absolute difference.</returns>
        public static float Distance(this float source, float destination)
        {
            return Math.Abs(destination - source);
        }

        /// <summary>
        /// Rounds a float value to the nearest integer, away from zero.
        /// </summary>
        /// <param name="value">The float value.</param>
        /// <returns>The rounded value.</returns>
        public static float Round(this float value)
        {
            return Math.Round(value, MidpointRounding.AwayFromZero).ToFloat();
        }

        /// <summary>
        /// Rounds a float value to the specified number of decimal places, away from zero.
        /// </summary>
        /// <param name="value">The float value.</param>
        /// <param name="digits">The number of decimal places.</param>
        /// <returns>The rounded value.</returns>
        public static float Round(this float value, int digits)
        {
            return Math.Round(value, digits, MidpointRounding.AwayFromZero).ToFloat();
        }

        /// <summary>
        /// Truncates a float value to the integer part.
        /// </summary>
        /// <param name="value">The float value.</param>
        /// <returns>The truncated value.</returns>
        public static float Truncate(this float value)
        {
            return Math.Truncate(value).ToFloat();
        }

        /// <summary>
        /// Converts a float value to a boolean.
        /// </summary>
        /// <param name="value">The float value.</param>
        /// <returns>A boolean representation of the float value.</returns>
        public static bool ToBoolean(this float value)
        {
            return Convert.ToBoolean(value);
        }

        /// <summary>
        /// Converts a float value to an integer.
        /// </summary>
        /// <param name="value">The float value.</param>
        /// <returns>An integer representation of the float value.</returns>
        public static int ToInt(this float value)
        {
            return Convert.ToInt32(value);
        }

        #endregion

        #region Integer

        /// <summary>
        /// Returns the absolute value of an integer.
        /// </summary>
        /// <param name="value">The integer value.</param>
        /// <returns>The absolute value.</returns>
        public static int Abs(this int value)
        {
            return Math.Abs(value);
        }

        /// <summary>
        /// Clamps an integer value to the specified range.
        /// </summary>
        /// <param name="value">The integer value.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>The clamped value.</returns>
        public static int Clamp(this int value, int min, int max)
        {
            return Math.Max(min, Math.Min(max, value));
        }

        /// <summary>
        /// Checks if an integer corresponds to a defined value in a given enum type.
        /// </summary>
        /// <typeparam name="TEnum">The enum type.</typeparam>
        /// <param name="value">The integer value.</param>
        /// <returns>True if the value is defined in the enum; otherwise, false.</returns>
        public static bool IsDefined<TEnum>(this int value)
            where TEnum : Enum
        {
            return Enum.IsDefined(typeof(TEnum), value);
        }

        /// <summary>
        /// Converts an integer to a boolean.
        /// </summary>
        /// <param name="value">The integer value.</param>
        /// <returns>A boolean representation of the integer value.</returns>
        public static bool ToBoolean(this int value)
        {
            return Convert.ToBoolean(value);
        }

        /// <summary>
        /// Converts an integer to the corresponding enum value.
        /// </summary>
        /// <typeparam name="TEnum">The enum type.</typeparam>
        /// <param name="value">The integer value.</param>
        /// <returns>The enum value corresponding to the integer.</returns>
        public static TEnum ToEnum<TEnum>(this int value)
            where TEnum : Enum
        {
            return (TEnum)Enum.ToObject(typeof(TEnum), value);
        }

        #endregion

        #region Long

        /// <summary>
        /// Converts a long value to an integer.
        /// </summary>
        /// <param name="value">The long value.</param>
        /// <returns>An integer representation of the long value.</returns>
        public static int ToInt(this long value)
        {
            return Convert.ToInt32(value);
        }

        #endregion
    }
}