using System.Reflection;

namespace System.Extensions.Reflection
{
    public static class ReflectionExtensions
    {
        #region Object

        /// <summary>
        /// Gets the value of a field from an object and casts it to the specified type.
        /// </summary>
        /// <typeparam name="TSource">The expected type of the field value.</typeparam>
        /// <param name="obj">The object containing the field.</param>
        /// <param name="name">The name of the field.</param>
        /// <returns>The value of the field cast to the specified type.</returns>
        public static TSource GetFieldValue<TSource>(this object obj, string name)
        {
            return (TSource)obj.GetFieldValue(name);
        }

        /// <summary>
        /// Gets the value of a field from an object.
        /// </summary>
        /// <param name="obj">The object containing the field.</param>
        /// <param name="name">The name of the field.</param>
        /// <returns>The value of the field.</returns>
        public static object GetFieldValue(this object obj, string name)
        {
            Type type = obj.GetType();
            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            FieldInfo fieldInfo = type.GetField(name, flags);

            if (fieldInfo == null)
            {
                throw new ArgumentException($"Field '{name}' not found in type '{type.FullName}'.");
            }

            return fieldInfo.GetValue(obj);
        }

        /// <summary>
        /// Gets the value of a property from an object and casts it to the specified type.
        /// </summary>
        /// <typeparam name="TSource">The expected type of the property value.</typeparam>
        /// <param name="obj">The object containing the property.</param>
        /// <param name="name">The name of the property.</param>
        /// <returns>The value of the property cast to the specified type.</returns>
        public static TSource GetPropertyValue<TSource>(this object obj, string name)
        {
            return (TSource)obj.GetPropertyValue(name);
        }

        /// <summary>
        /// Gets the value of a property from an object.
        /// </summary>
        /// <param name="obj">The object containing the property.</param>
        /// <param name="name">The name of the property.</param>
        /// <returns>The value of the property.</returns>
        public static object GetPropertyValue(this object obj, string name)
        {
            Type type = obj.GetType();
            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            PropertyInfo propertyInfo = type.GetProperty(name, flags);

            if (propertyInfo == null)
            {
                throw new ArgumentException($"Property '{name}' not found in type '{type.FullName}'.");
            }

            return propertyInfo.GetValue(obj);
        }

        /// <summary>
        /// Sets the value of a field in a struct.
        /// </summary>
        /// <typeparam name="TSource">The type of the struct.</typeparam>
        /// <param name="obj">The struct to modify.</param>
        /// <param name="name">The name of the field.</param>
        /// <param name="value">The new value for the field.</param>
        public static void SetFieldValue<TSource>(this ref TSource obj, string name, object value)
            where TSource : struct
        {
            object boxed = obj;
            boxed.SetFieldValue(name, value);
            obj = (TSource)boxed;
        }

        /// <summary>
        /// Sets the value of a field in an object.
        /// </summary>
        public static void SetFieldValue(this object obj, string name, object value)
        {
            Type type = obj.GetType();
            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            FieldInfo fieldInfo = type.GetField(name, flags);

            if (fieldInfo == null)
            {
                throw new ArgumentException($"Field '{name}' not found in type '{type.FullName}'.");
            }

            fieldInfo.SetValue(obj, value);
        }

        /// <summary>
        /// Sets the value of a property in a struct.
        /// </summary>
        public static void SetPropertyValue<TSource>(this ref TSource obj, string name, object value)
            where TSource : struct
        {
            object boxed = obj;
            boxed.SetPropertyValue(name, value);
            obj = (TSource)boxed;
        }

        /// <summary>
        /// Sets the value of a property in an object.
        /// </summary>
        public static void SetPropertyValue(this object obj, string name, object value)
        {
            Type type = obj.GetType();
            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            PropertyInfo propertyInfo = type.GetProperty(name, flags);

            if (propertyInfo == null)
            {
                throw new ArgumentException($"Property '{name}' not found in type '{type.FullName}'.");
            }

            propertyInfo.SetValue(obj, value);
        }

        #endregion

        #region Type

        /// <summary>
        /// Gets a custom attribute of the specified type from a type.
        /// </summary>
        /// <typeparam name="TSource">The type of the attribute.</typeparam>
        /// <param name="type">The type to inspect.</param>
        /// <returns>The attribute if found; otherwise, null.</returns>
        public static TSource GetAttribute<TSource>(this Type type)
            where TSource : Attribute
        {
            return Attribute.GetCustomAttribute(type, typeof(TSource)) as TSource;
        }

        #endregion
    }
}