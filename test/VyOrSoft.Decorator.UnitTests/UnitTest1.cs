using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using VyOrSoft.Decorator.IoC;

namespace VyOrSoft.Decorator.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test2()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<IDecorated1, Decorated1>();
            services.AddTransient<IDecorated1, Decorated1>();
            services.AddTransient<IDecorated1, Decorated1>();
            services.Decorate<IDecorated1, DecoratorSingleClass>((inner, sp) => new DecoratorSingleClass(inner));
            services.Decorate<IDecorated1, DecoratorSingleClass>((inner, sp) => new DecoratorSingleClass(inner));
            services.Decorate<IDecorated1, DecoratorSingleClass>((inner, sp) => new DecoratorSingleClass(inner));
            services.Decorate<IDecorated1, DecoratorSingleClass>((inner, sp) => new DecoratorSingleClass(inner));

            var sp = services.BuildServiceProvider();

            var dec1 = sp.GetRequiredService<IDecorated1>();
            var t = dec1.ResolveClassName1();


           
        }

        [Fact]
        public void Test1()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<IDecorated1>(sp => new Decorated1());
            services.AddTransient<IDecorated1>(sp => new Decorated1());
            services.AddTransient<IDecorated1>(sp => new Decorated1());
            services.AddTransient<IDecorated2>(sp => new Decorated2());
            //services.Decorate<IDecorated1, IDecorated2, DecoratorClass>((inner1, inner2, sp) => new DecoratorClass(inner1, inner2));
            //services.Decorate<IDecorated1, IDecorated2, DecoratorClass2>((inner1, inner2, sp) => new DecoratorClass2(inner1, inner2));
            var sp = services.BuildServiceProvider();

            var yy = sp.GetRequiredService<IEnumerable<IDecorated1>>();
            var dec3 = sp.GetRequiredService<DecoratorClass>();

            var dec1 = sp.GetRequiredService<IDecorated1>();
            var dec1ResolvedClassName1 = dec1.ResolveClassName1();
            //dec1ResolvedClassName1.Should().BeEquivalentTo("DecoratorClass Decorated1");

            var dec2 = sp.GetRequiredService<IDecorated2>();
            var dec1ResolvedClassName2 = dec2.ResolveClassName2();
            //dec1ResolvedClassName2.Should().BeEquivalentTo("DecoratorClass Decorated2");
        }

        private interface IDecorated1
        {
            string ResolveClassName1();
        }
        private sealed class Decorated1 : IDecorated1
        {
            public string ResolveClassName1()
                => nameof(Decorated1);
        }

        private interface IDecorated2
        {
            string ResolveClassName2();
        }
        private sealed class Decorated2 : IDecorated2
        {
            public string ResolveClassName2()
                => nameof(Decorated2);
        }

        private sealed class DecoratorSingleClass : IDecorated1
        {
            private readonly IDecorated1 _decorated1;

            public DecoratorSingleClass(IDecorated1 decorated1)
            {
                _decorated1 = decorated1;
            }

            public string ResolveClassName1()
                => $"{nameof(DecoratorClass)} {_decorated1.ResolveClassName1()}";
        }

        private sealed class DecoratorClass : IDecorated1, IDecorated2
        {
            private readonly IDecorated1 _decorated1;
            private readonly IDecorated2 _decorated2;

            public DecoratorClass(IDecorated1 decorated1, IDecorated2 decorated2)
            {
                _decorated1 = decorated1;
                _decorated2 = decorated2;
            }

            public string ResolveClassName1()
                => $"{nameof(DecoratorClass)} {_decorated1.ResolveClassName1()}";

            public string ResolveClassName2()
                => $"{nameof(DecoratorClass)} {_decorated2.ResolveClassName2()}";
        }

        private sealed class DecoratorClass2 : IDecorated1, IDecorated2
        {
            private readonly IDecorated1 _decorated1;
            private readonly IDecorated2 _decorated2;

            public DecoratorClass2(IDecorated1 decorated1, IDecorated2 decorated2)
            {
                _decorated1 = decorated1;
                _decorated2 = decorated2;
            }

            public string ResolveClassName1()
                => $"{nameof(DecoratorClass2)} {_decorated1.ResolveClassName1()}";

            public string ResolveClassName2()
                => $"{nameof(DecoratorClass2)} {_decorated2.ResolveClassName2()}";
        }
    }
}