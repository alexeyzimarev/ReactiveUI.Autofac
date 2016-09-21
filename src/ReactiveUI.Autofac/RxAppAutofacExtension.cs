using Autofac;
using Splat;

namespace ReactiveUI.Autofac
{
    /// <summary>
    /// Extension methods for the Autofac adapter
    /// </summary>
    public static class RxAppAutofacExtension
    {
        /// <summary>
        /// Build a container in your bootstrapper class and call this method to replace RxApp
        /// internal resolver (Splat ServiceLocator) by Autofac
        /// </summary>
        /// <param name="container">Autofac container</param>
        public static void UseAutofacDependencyResolver(IContainer container)
        {
            var resolver = new AutofacDependencyResolver(container);
            Locator.Current = resolver;
        }
    }
}