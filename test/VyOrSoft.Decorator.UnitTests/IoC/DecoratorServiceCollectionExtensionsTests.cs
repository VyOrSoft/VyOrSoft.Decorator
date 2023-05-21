using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using VyOrSoft.Decorator.IoC;

namespace VyOrSoft.Decorator.UnitTests.IoC
{
    public sealed class DecoratorServiceCollectionExtensionsTests
    {
        [Fact]
        public void Decorate_Factory_SingleDecorated_ExpectedHierarchy()
        {
            // arrange
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<IDecorated, Decorated>();
            services.Decorate<IDecorated, DecoratorClass>((inner, sp) => new DecoratorClass(inner));
            services.Decorate<IDecorated, Decorator2Class>((inner, sp) => new Decorator2Class(inner));

            var sp = services.BuildServiceProvider();

            //  act
            var actual = sp.GetRequiredService<IDecorated>();

            // asserts
            actual.Should().BeOfType<Decorator2Class>()
                .Subject.Decorated.Should().BeOfType<DecoratorClass>()
                .Subject.Decorated.Should().BeOfType<Decorated>();
        }

        [Fact]
        public void Decorate_Factory_SingleDecorated_ExpectedSingletonLifetime()
        {
            // arrange
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<IDecorated, Decorated>();
            services.Decorate<IDecorated, DecoratorClass>((inner, sp) => new DecoratorClass(inner));
            services.Decorate<IDecorated, Decorator2Class>((inner, sp) => new Decorator2Class(inner));

            var sp = services.BuildServiceProvider();
            //  act
            var actual = sp.CreateScope().ServiceProvider.GetRequiredService<IDecorated>();
            var actual2 = sp.CreateScope().ServiceProvider.GetRequiredService<IDecorated>();

            // asserts
            var decorator2ClassInst = actual.Should().BeOfType<Decorator2Class>().Subject;
            var decoratorClassInst = decorator2ClassInst.Decorated.Should().BeOfType<DecoratorClass>().Subject;
            var decoratedInst = decoratorClassInst.Decorated.Should().BeOfType<Decorated>().Subject;

            var decorator2ClassInst2 = actual2.Should().BeOfType<Decorator2Class>().Subject;
            var decoratorClassInst2 = decorator2ClassInst2.Decorated.Should().BeOfType<DecoratorClass>().Subject;
            var decoratedInst2 = decoratorClassInst2.Decorated.Should().BeOfType<Decorated>().Subject;

            decorator2ClassInst.Should().BeSameAs(decorator2ClassInst2);
            decoratorClassInst.Should().BeSameAs(decoratorClassInst2);
            decoratedInst.Should().BeSameAs(decoratedInst2);
        }

        [Fact]
        public void Decorate_Factory_SingleDecorated_ExpectedTransientLifetime()
        {
            // arrange
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<IDecorated, Decorated>();
            services.Decorate<IDecorated, DecoratorClass>((inner, sp) => new DecoratorClass(inner));
            services.Decorate<IDecorated, Decorator2Class>((inner, sp) => new Decorator2Class(inner));

            var sp = services.BuildServiceProvider();
            //  act
            var actual = sp.GetRequiredService<IDecorated>();
            var actual2 = sp.GetRequiredService<IDecorated>();

            // asserts
            var decorator2ClassInst = actual.Should().BeOfType<Decorator2Class>().Subject;
            var decoratorClassInst = decorator2ClassInst.Decorated.Should().BeOfType<DecoratorClass>().Subject;
            var decoratedInst = decoratorClassInst.Decorated.Should().BeOfType<Decorated>().Subject;

            var decorator2ClassInst2 = actual2.Should().BeOfType<Decorator2Class>().Subject;
            var decoratorClassInst2 = decorator2ClassInst2.Decorated.Should().BeOfType<DecoratorClass>().Subject;
            var decoratedInst2 = decoratorClassInst2.Decorated.Should().BeOfType<Decorated>().Subject;

            decorator2ClassInst.Should().NotBeSameAs(decorator2ClassInst2);
            decoratorClassInst.Should().NotBeSameAs(decoratorClassInst2);
            decoratedInst.Should().NotBeSameAs(decoratedInst2);
        }

        [Fact]
        public void Decorate_Factory_SingleDecorated_ExpectedScopedLifetime()
        {
            // arrange
            IServiceCollection services = new ServiceCollection();

            services.AddScoped<IDecorated, Decorated>();
            services.Decorate<IDecorated, DecoratorClass>((inner, sp) => new DecoratorClass(inner));
            services.Decorate<IDecorated, Decorator2Class>((inner, sp) => new Decorator2Class(inner));

            var sp = services.BuildServiceProvider().CreateScope().ServiceProvider;
            //  act
            var actual = sp.CreateScope().ServiceProvider.GetRequiredService<IDecorated>();
            var spScoped = sp.CreateScope().ServiceProvider;
            var actual2 = spScoped.GetRequiredService<IDecorated>();
            var actual3 = spScoped.GetRequiredService<IDecorated>();

            // asserts
            var decorator2ClassInst = actual.Should().BeOfType<Decorator2Class>().Subject;
            var decoratorClassInst = decorator2ClassInst.Decorated.Should().BeOfType<DecoratorClass>().Subject;
            var decoratedInst = decoratorClassInst.Decorated.Should().BeOfType<Decorated>().Subject;

            var decorator2ClassInst2 = actual2.Should().BeOfType<Decorator2Class>().Subject;
            var decoratorClassInst2 = decorator2ClassInst2.Decorated.Should().BeOfType<DecoratorClass>().Subject;
            var decoratedInst2 = decoratorClassInst2.Decorated.Should().BeOfType<Decorated>().Subject;

            var decorator2ClassInst3 = actual3.Should().BeOfType<Decorator2Class>().Subject;
            var decoratorClassInst3 = decorator2ClassInst3.Decorated.Should().BeOfType<DecoratorClass>().Subject;
            var decoratedInst3 = decoratorClassInst3.Decorated.Should().BeOfType<Decorated>().Subject;

            decorator2ClassInst.Should().NotBeSameAs(decorator2ClassInst2);
            decoratorClassInst.Should().NotBeSameAs(decoratorClassInst2);
            decoratedInst.Should().NotBeSameAs(decoratedInst2);

            decorator2ClassInst3.Should().BeSameAs(decorator2ClassInst2);
            decoratorClassInst3.Should().BeSameAs(decoratorClassInst2);
            decoratedInst3.Should().BeSameAs(decoratedInst2);
        }


        private interface IDecorated
        {
        }

        private sealed class Decorated : IDecorated
        {
        }

        private sealed class DecoratorClass : IDecorated
        {
            public DecoratorClass(IDecorated decorated)
            {
                Decorated = decorated;
            }

            internal IDecorated Decorated { get; }
        }

        private sealed class Decorator2Class : IDecorated
        {
            public Decorator2Class(IDecorated decorated)
            {
                Decorated = decorated;
            }

            internal IDecorated Decorated { get; }
        }
    }
}
