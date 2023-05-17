namespace VyOrSoft.Decorator.Feature.DecoratorTypes.Domain;

internal static class ServiceTypeDecoratorFactory
{
    public static ServiceTypeDecorator CreateServiceTypeDecorator(Type type)
        => new(type, GenerateId());

    private static string GenerateId()
        => Guid.NewGuid().ToString();
}
