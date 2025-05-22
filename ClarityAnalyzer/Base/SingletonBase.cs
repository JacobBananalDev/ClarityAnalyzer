using System;

namespace ClarityAnalyzer.Base
{
    internal abstract class SingletonBase<T> where T : class
    {
        internal static T Instance
        {
            get { return m_singleInstance.Value; }
        }

        private static readonly Lazy<T> m_singleInstance = new Lazy<T>(() => CreateInstanceOfT());

        private static T CreateInstanceOfT()
        {
            return Activator.CreateInstance(typeof(T), true) as T;
        }

    }
}
