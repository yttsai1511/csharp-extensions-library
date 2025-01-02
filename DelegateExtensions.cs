using System.Collections.Generic;

namespace System.Extensions
{
    public static class DelegateExtensions
    {
        /// <summary>
        /// Combines two delegates into one.
        /// </summary>
        public static TSource Combine<TSource>(this TSource first, TSource second)
            where TSource : Delegate
        {
            if (first == null)
            {
                return second;
            }

            if (second == null)
            {
                return first;
            }

            foreach (Delegate existingDelegate in first.GetInvocationList())
            {
                if (existingDelegate.Target == second.Target && existingDelegate.Method == second.Method)
                {
                    return first;
                }
            }

            return Delegate.Combine(first, second) as TSource;
        }

        /// <summary>
        /// Removes a delegate from another delegate.
        /// </summary>
        public static TSource Remove<TSource>(this TSource source, TSource toRemove)
            where TSource : Delegate
        {
            if (source == null || toRemove == null)
            {
                return source;
            }

            foreach (Delegate existingDelegate in source.GetInvocationList())
            {
                if (existingDelegate.Target == toRemove.Target && existingDelegate.Method == toRemove.Method)
                {
                    return Delegate.Remove(source, existingDelegate) as TSource;
                }
            }

            return source;
        }

        /// <summary>
        /// Registers or unregisters a delegate based on a condition.
        /// </summary>
        public static TSource Register<TSource>(this TSource source, TSource toRegister, bool isEnable)
            where TSource : Delegate
        {
            if (isEnable)
            {
                return source.Combine(toRegister);
            }

            return source.Remove(toRegister);
        }

        /// <summary>
        /// Safely invokes a delegate that returns a result.
        /// </summary>
        public static TResult TryInvoke<TResult>(this Func<TResult> func)
        {
            if (func == null)
            {
                return default;
            }

            return func.Invoke();
        }

        /// <summary>
        /// Safely invokes a delegate with one argument and returns a result.
        /// </summary>
        public static TResult TryInvoke<TSource, TResult>(this Func<TSource, TResult> func, TSource arg)
        {
            if (func == null)
            {
                return default;
            }

            return func.Invoke(arg);
        }

        /// <summary>
        /// Safely invokes a delegate with two arguments and returns a result.
        /// </summary>
        public static TResult TryInvoke<T1, T2, TResult>(this Func<T1, T2, TResult> func, T1 arg1, T2 arg2)
        {
            if (func == null)
            {
                return default;
            }

            return func.Invoke(arg1, arg2);
        }

        /// <summary>
        /// Safely invokes a delegate with three arguments and returns a result.
        /// </summary>
        public static TResult TryInvoke<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func, T1 arg1, T2 arg2, T3 arg3)
        {
            if (func == null)
            {
                return default;
            }

            return func.Invoke(arg1, arg2, arg3);
        }

        /// <summary>
        /// Invokes all delegates in the invocation list and collects their results.
        /// </summary>
        public static void GetResults<TResult>(this Func<TResult> func, List<TResult> results)
        {
            if (func == null || results == null)
            {
                return;
            }

            Delegate[] invocationList = func.GetInvocationList();

            foreach (Delegate item in invocationList)
            {
                Func<TResult> subFunc = item as Func<TResult>;
                if (subFunc != null)
                {
                    results.Add(subFunc.TryInvoke());
                }
            }
        }

        /// <summary>
        /// Invokes all delegates with one argument and collects their results.
        /// </summary>
        public static void GetResults<TSource, TResult>(this Func<TSource, TResult> func, List<TResult> results, TSource arg)
        {
            if (func == null || results == null)
            {
                return;
            }

            Delegate[] invocationList = func.GetInvocationList();

            foreach (Delegate item in invocationList)
            {
                Func<TSource, TResult> subFunc = item as Func<TSource, TResult>;
                if (subFunc != null)
                {
                    results.Add(subFunc.TryInvoke(arg));
                }
            }
        }

        /// <summary>
        /// Invokes all delegates with two arguments and collects their results.
        /// </summary>
        public static void GetResults<T1, T2, TResult>(this Func<T1, T2, TResult> func, List<TResult> results, T1 arg1, T2 arg2)
        {
            if (func == null || results == null)
            {
                return;
            }

            Delegate[] invocationList = func.GetInvocationList();

            foreach (Delegate item in invocationList)
            {
                Func<T1, T2, TResult> subFunc = item as Func<T1, T2, TResult>;
                if (subFunc != null)
                {
                    results.Add(subFunc.TryInvoke(arg1, arg2));
                }
            }
        }

        /// <summary>
        /// Invokes all delegates with three arguments and collects their results.
        /// </summary>
        public static void GetResults<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func, List<TResult> results, T1 arg1, T2 arg2, T3 arg3)
        {
            if (func == null || results == null)
            {
                return;
            }

            Delegate[] invocationList = func.GetInvocationList();

            foreach (Delegate item in invocationList)
            {
                Func<T1, T2, T3, TResult> subFunc = item as Func<T1, T2, T3, TResult>;
                if (subFunc != null)
                {
                    results.Add(subFunc.TryInvoke(arg1, arg2, arg3));
                }
            }
        }
    }
}