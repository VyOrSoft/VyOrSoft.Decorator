using FluentAssertions;
using VyOrSoft.Decorator.Feature.DecoratorTypes.Domain;

namespace VyOrSoft.Decorator.UnitTests.Feature.DecoratorTypes.Domain;

public sealed class ServiceTypeDecoratorTests
{
    [Fact]
    public void GetHashCode_SimilarEquals_Code()
    {
        var testCases = new
        {
            InnerType = typeof(InnerTypeClass),
            Id = "qwerty"
        };
        //arrage
        var serviceTypeDecorator = new ServiceTypeDecorator(testCases.InnerType, testCases.Id);
        var serviceTypeDecorator2 = new ServiceTypeDecorator(testCases.InnerType, testCases.Id);

        //act
        var serviceTypeDecoratorHashCode = serviceTypeDecorator.GetHashCode();
        var serviceTypeDecorator2HashCode = serviceTypeDecorator2.GetHashCode();

        //assets
        var innerTypeHashCode = testCases.InnerType.GetHashCode();
        serviceTypeDecoratorHashCode.Should().NotBe(innerTypeHashCode);
        serviceTypeDecoratorHashCode.Should().Be(serviceTypeDecorator2HashCode);
    }

    [Fact]
    public void GetHashCode_DifferentNotEquals_Code()
    {
        var testCases = new
        {
            InnerType = typeof(InnerTypeClass),
            Id = "qwerty1",
            Id2 = "qwerty2"
        };
        //arrage
        var serviceTypeDecorator = new ServiceTypeDecorator(testCases.InnerType, testCases.Id);
        var serviceTypeDecorator2 = new ServiceTypeDecorator(testCases.InnerType, testCases.Id2);

        //act
        var serviceTypeDecoratorHashCode = serviceTypeDecorator.GetHashCode();
        var serviceTypeDecorator2HashCode = serviceTypeDecorator2.GetHashCode();

        //assets
        serviceTypeDecoratorHashCode.Should().NotBe(serviceTypeDecorator2HashCode);
    }

    [Fact]
    public void GetHashCode_InnerNotEquals_Code()
    {
        var testCases = new
        {
            InnerType = typeof(InnerTypeClass),
            Id = "qwerty1"
        };
        //arrage
        var serviceTypeDecorator = new ServiceTypeDecorator(testCases.InnerType, testCases.Id);
        var innerTypeHashCode = testCases.InnerType.GetHashCode();

        //act
        var serviceTypeDecoratorHashCode = serviceTypeDecorator.GetHashCode();

        //assets
        serviceTypeDecoratorHashCode.Should().NotBe(innerTypeHashCode);
    }

    [Fact]
    public void Equals_TypeEquals_True()
    {
        var testCases = new
        {
            InnerType = typeof(InnerTypeClass),
            Id = "qwerty"
        };
        //arrage
        var serviceTypeDecorator = new ServiceTypeDecorator(testCases.InnerType, testCases.Id);
        var serviceTypeDecorator2 = new ServiceTypeDecorator(testCases.InnerType, testCases.Id);

        //act
        var areServiceTypeDecoratorEquals = serviceTypeDecorator.Equals(serviceTypeDecorator2);
        var areServiceTypeDecoratorEqualsObject = serviceTypeDecorator.Equals((object)serviceTypeDecorator2);
        var areServiceTypeDecoratorEqualsIsEquivalentTo = serviceTypeDecorator.IsEquivalentTo(serviceTypeDecorator2);
        //assets
        areServiceTypeDecoratorEquals.Should().BeTrue();
        areServiceTypeDecoratorEqualsObject.Should().BeTrue();
        areServiceTypeDecoratorEqualsIsEquivalentTo.Should().BeTrue();
    }

    [Fact]
    public void Equals_TypeEquals_False()
    {
        var testCases = new
        {
            InnerType = typeof(InnerTypeClass),
            Id = "qwerty",
            Id2 = "qwerty2"
        };
        //arrage
        var serviceTypeDecorator = new ServiceTypeDecorator(testCases.InnerType, testCases.Id);
        var serviceTypeDecorator2 = new ServiceTypeDecorator(testCases.InnerType, testCases.Id2);

        //act
        var areServiceTypeDecoratorEquals = serviceTypeDecorator.Equals(serviceTypeDecorator2);
        var areServiceTypeDecoratorEqualsObject = serviceTypeDecorator.Equals((object)serviceTypeDecorator2);
        var areServiceTypeDecoratorEqualsIsEquivalentTo = serviceTypeDecorator.IsEquivalentTo(serviceTypeDecorator2);
        //assets
        areServiceTypeDecoratorEquals.Should().BeFalse();
        areServiceTypeDecoratorEqualsObject.Should().BeFalse();
        areServiceTypeDecoratorEqualsIsEquivalentTo.Should().BeFalse();
    }

    [Fact]
    public void Equals_TypeEqualsInner_False()
    {
        var testCases = new
        {
            InnerType = typeof(InnerTypeClass),
            Id = "qwerty"
        };
        //arrage
        var serviceTypeDecorator = new ServiceTypeDecorator(testCases.InnerType, testCases.Id);

        //act
        var areServiceTypeDecoratorEquals = serviceTypeDecorator.Equals(testCases.InnerType);
        var areServiceTypeDecoratorEqualsObject = serviceTypeDecorator.Equals((object)testCases.InnerType);
        var areServiceTypeDecoratorEqualsIsEquivalentTo = serviceTypeDecorator.IsEquivalentTo(testCases.InnerType);

        //assets
        areServiceTypeDecoratorEquals.Should().BeFalse();
        areServiceTypeDecoratorEqualsObject.Should().BeFalse();
        areServiceTypeDecoratorEqualsIsEquivalentTo.Should().BeFalse();
    }

    private sealed class InnerTypeClass { }
}
