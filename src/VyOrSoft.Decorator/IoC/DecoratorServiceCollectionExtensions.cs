using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Diagnostics.CodeAnalysis;
using VyOrSoft.Decorator.Feature.DecoratorTypes.Domain;

namespace VyOrSoft.Decorator.IoC;

public static class DecoratorServiceCollectionExtensions
{
    public static IServiceCollection Decorate<TDecorated1, TDecorator>(this IServiceCollection services,
        Func<TDecorated1, IServiceProvider, TDecorator> decoratorImplementationFactory,
        ServiceLifetime? decoratorServiceLifetime = default)
        where TDecorated1 : notnull
        where TDecorator : TDecorated1
    {
        var serviceTypeDecorator = ServiceTypeDecoratorFactory.CreateServiceTypeDecorator(typeof(TDecorated1));
        var serviceDescriptors = services.ReplaceAll(typeof(TDecorated1), serviceTypeDecorator);
        var decoratorLifetime = ResolveOptimalServiceLifetime(serviceDescriptors.ToArray());

        var decoratorServiceTypeDecorator = ServiceTypeDecoratorFactory.CreateServiceTypeDecorator(typeof(TDecorator));
        services.Add(ServiceDescriptor.Describe(decoratorServiceTypeDecorator, sp => decoratorImplementationFactory((TDecorated1)sp.GetRequiredService(serviceTypeDecorator), sp), decoratorLifetime));
        services.Add(ServiceDescriptor.Describe(typeof(TDecorated1), sp => sp.GetRequiredService(decoratorServiceTypeDecorator), decoratorLifetime));

        return services;
    }


    public static IServiceCollection Decorate<TDecorated1, TDecorated2, TDecorator>(this IServiceCollection services, 
        Func<TDecorated1, TDecorated2, IServiceProvider, TDecorator> decoratorImplementationFactory,
        ServiceLifetime? decoratorServiceLifetime = default)
        where TDecorated1 : notnull
        where TDecorated2 : notnull
        where TDecorator : TDecorated1, TDecorated2
    {
        //services.AddSingleton();
        //ServiceDescriptor.
        //services.TryRetrieveServiceDescriptor<TService>(out var serviceDescriptor);
        //var descriptor =  new ServiceDescriptor(typeof(TService), typeof(TDecorator), ServiceLifetime.Singleton);
        //services.Add(descriptor);
        //services.BuildServiceProvider();

        //if (!services.TryRetrieveServiceDescriptor<TDecorated1>(out var serviceDescriptor1))
        //{
        //    throw new Exception($"{typeof(TDecorated1)} not found");
        //}

        //if (!services.TryRetrieveServiceDescriptor<TDecorated2>(out var serviceDescriptor2))
        //{
        //    throw new Exception($"{typeof(TDecorated2)} not found");
        //}
        var decorated1 = services.RetrieveServiceDescriptor<TDecorated1>();
        var decorated2 = services.RetrieveServiceDescriptor<TDecorated2>();
        var decoratorLifetime = ResolveOptimalServiceLifetime(decorated1, decorated2);

        services.Remove(decorated1);
        var decoratedType1 = new ServiceTypeDecorator(typeof(TDecorated1), $"1_{Guid.NewGuid()}");
        services.Add(ServiceDescriptor.Describe(decoratedType1, decorated1.ImplementationFactory, decoratorLifetime));

        services.Remove(decorated2);
        var decoratedType2 = new ServiceTypeDecorator(typeof(TDecorated2), $"2_{Guid.NewGuid()}");
        services.Add(ServiceDescriptor.Describe(decoratedType2, decorated2.ImplementationFactory, decoratorLifetime));

        services.Add(ServiceDescriptor.Describe(typeof(TDecorator), sp => decoratorImplementationFactory((TDecorated1)sp.GetRequiredService(decoratedType1), (TDecorated2)sp.GetRequiredService(decoratedType2), sp), decoratorLifetime));
        services.Add(ServiceDescriptor.Describe(typeof(TDecorated1), sp => sp.GetRequiredService(typeof(TDecorator)), decoratorLifetime));
        services.Add(ServiceDescriptor.Describe(typeof(TDecorated2), sp => sp.GetRequiredService(typeof(TDecorator)), decoratorLifetime));

        return services;

        //singletone -> scoped -> transient
    }

    //services.Add(ServiceDescriptor.Describe(decoratorServiceTypeDecorator, sp => ActivatorUtilities.CreateInstance<TDecorator>(sp, sp.GetRequiredService(serviceTypeDecorator)), decoratorLifetime));

    private static void DecoratedExists()
    {

    }

    private static ServiceLifetime ResolveOptimalServiceLifetime(params ServiceDescriptor[] serviceDescriptors)
    {
        //todo: not optimal one
        //provide comparer to make ordering singletone -> scoped -> transient

        if (serviceDescriptors.Any(sd => sd.Lifetime == ServiceLifetime.Transient))
        {
            return ServiceLifetime.Transient;
        }

        if (serviceDescriptors.Any(sd => sd.Lifetime == ServiceLifetime.Scoped))
        {
            return ServiceLifetime.Scoped;
        }

        return ServiceLifetime.Singleton;
    }


    private static bool TryRetrieveServiceDescriptor<TService>(this IServiceCollection services, [NotNullWhen(true)] out ServiceDescriptor? serviceDescriptor)
    {
        serviceDescriptor = services.RetrieveServiceDescriptor<TService>();
        return serviceDescriptor != null;
    }
    private static ServiceDescriptor? RetrieveServiceDescriptor<TService>(this IServiceCollection services)
        => services.FirstOrDefault(d => d.ServiceType == typeof(TService));
}
