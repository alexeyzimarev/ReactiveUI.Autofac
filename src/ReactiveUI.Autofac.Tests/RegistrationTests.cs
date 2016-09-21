using System.Reflection;
using Autofac;
using Shouldly;
using Splat;
using Xunit;

namespace ReactiveUI.Autofac.Tests
{
    public class RegistrationTests
    {
        [Fact]
        public void Should_resolve_views()
        {
            var builder = new ContainerBuilder();
            builder.RegisterViews(Assembly.GetExecutingAssembly());
            var container = builder.Build();
            RxAppAutofacExtension.UseAutofacDependencyResolver(container);

            var viewA = Locator.CurrentMutable.GetService(typeof(IViewFor<ViewModelA>));
            viewA.ShouldNotBeNull();
            viewA.ShouldBeOfType<ViewA>();

            var viewB = Locator.CurrentMutable.GetService(typeof(IViewFor<ViewModelB>));
            viewB.ShouldNotBeNull();
            viewB.ShouldBeOfType<ViewB>();
        }

        [Fact]
        public void Should_resolve_view_models()
        {
            var builder = new ContainerBuilder();
            builder.RegisterViewModels(Assembly.GetExecutingAssembly());
            RxAppAutofacExtension.UseAutofacDependencyResolver(builder.Build());

            var vmA = Locator.CurrentMutable.GetService<ViewModelA>();
            vmA.ShouldNotBeNull();

            var vmB = Locator.CurrentMutable.GetService<ViewModelB>();
            vmB.ShouldNotBeNull();
        }

        [Fact]
        public void Should_resolve_screen()
        {
            var builder = new ContainerBuilder();
            builder.RegisterScreen(Assembly.GetExecutingAssembly());
            RxAppAutofacExtension.UseAutofacDependencyResolver(builder.Build());

            var screen = Locator.CurrentMutable.GetService<IScreen>();
            screen.ShouldNotBeNull();
            screen.ShouldBeOfType<Screen>();
        }
    }
}