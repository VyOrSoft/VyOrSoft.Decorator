using System.Diagnostics.CodeAnalysis;

namespace VyOrSoft.Decorator.Feature.DecoratorTypes.Domain;

internal sealed class ServiceTypeDecorator : TypeDecorator
{
    private readonly string _id;
    public ServiceTypeDecorator(Type innerType, string id) : base(innerType)
    {
        _id = id;
    }

    public override bool Equals(object? o)
        => EqualsServiceTypeDecorator(o);

    public override bool Equals(Type? o)
        => EqualsServiceTypeDecorator(o);

    public override bool IsEquivalentTo([NotNullWhen(true)] Type? other)
        => EqualsServiceTypeDecorator(other);

    private bool EqualsServiceTypeDecorator(object? o)
    {
        if (o is null) return false;
        if (o is not ServiceTypeDecorator serviceTypeDecorator) return false;
        return Equals(serviceTypeDecorator);
    }

    private bool Equals(ServiceTypeDecorator serviceTypeDecorator)
        =>  this._id == serviceTypeDecorator._id &&
            base.Equals(serviceTypeDecorator);

    public override int GetHashCode()
        => HashCode.Combine(base.GetHashCode(), _id);
}
