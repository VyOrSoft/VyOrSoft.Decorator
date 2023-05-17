using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace VyOrSoft.Decorator.IoC;

internal static class ServiceCollectionExtensions
{
    public static ReadOnlyCollection<ServiceDescriptor> ReplaceAll(this IServiceCollection services, Type serviceTypeBefore, Type serviceTypeAfter)
    {
        List<ServiceDescriptor> replacedDescriptors = new();
        int count = services.Count;
        for (int i = 0; i < count; i++)
        {
            if (services[i].ServiceType == serviceTypeBefore)
            {
                var updatedServiceDescriptor = services[i].UpdateServiceType(serviceTypeAfter);
                services[i] = updatedServiceDescriptor;
                replacedDescriptors.Add(updatedServiceDescriptor);
            }
        }

        return replacedDescriptors.AsReadOnly();
    }

    private static ServiceDescriptor UpdateServiceType(this ServiceDescriptor serviceDescriptor, Type serviceType)
    {
        if (serviceDescriptor.ImplementationType is not null)
            return ServiceDescriptor.Describe(serviceType, serviceDescriptor.ImplementationType, serviceDescriptor.Lifetime);

        if (serviceDescriptor.ImplementationFactory is not null)
            return ServiceDescriptor.Describe(serviceType, serviceDescriptor.ImplementationFactory, serviceDescriptor.Lifetime);

        if (serviceDescriptor.ImplementationInstance is not null)
            return ServiceDescriptor.Singleton(serviceType, serviceDescriptor.ImplementationInstance);

        throw new Exception("Unknown ServiceDescriptor Implementation");
    }

}
