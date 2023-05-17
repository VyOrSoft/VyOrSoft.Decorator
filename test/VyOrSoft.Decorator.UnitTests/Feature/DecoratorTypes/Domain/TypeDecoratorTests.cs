using FluentAssertions;
using VyOrSoft.Decorator.Feature.DecoratorTypes.Domain;

namespace VyOrSoft.Decorator.UnitTests.Feature.DecoratorTypes.Domain;

public class TypeDecoratorTests
{
    [Fact]
    public void GetHashCode_Equals_Code()
    {
        var testCases = new
        {
            InnerType = typeof(InnerTypeClass)
        };
        //arrage
        var decoratedType = new TypeDecorator(testCases.InnerType);

        //act
        var actual = decoratedType.GetHashCode();

        //assets
        var expected = testCases.InnerType.GetHashCode();
        actual.Should().Be(expected);
    }

    [Fact]
    public void Equals_EqualsType_True()
    {
        var testCases = new
        {
            InnerType = typeof(InnerTypeClass)
        };
        //arrage
        var decoratedType1 = new TypeDecorator(testCases.InnerType);
        var decoratedType2 = new TypeDecorator(testCases.InnerType);

        //act
        var actual1 = decoratedType1.Equals(decoratedType2);
        var actual2 = decoratedType1.Equals(testCases.InnerType);

        //assets
        actual1.Should().BeTrue();
        actual2.Should().BeTrue();
    }

    [Fact]
    public void Equals_NotEqualsType_False()
    {
        var testCases = new
        {
            InnerType = typeof(InnerTypeClass),
            InnerType2 = typeof(InnerTypeClass2)
        };
        //arrage
        var decoratedType1 = new TypeDecorator(testCases.InnerType);
        var decoratedType2 = new TypeDecorator(testCases.InnerType2);

        //act
        var actual1 = decoratedType1.Equals(decoratedType2);
        var actual2 = decoratedType1.Equals(testCases.InnerType2);

        //assets
        actual1.Should().BeFalse();
        actual2.Should().BeFalse();
    }

    [Fact]
    public void Equals_EqualsObject_True()
    {
        var testCases = new
        {
            InnerType = typeof(InnerTypeClass)
        };
        //arrage
        var decoratedType1 = new TypeDecorator(testCases.InnerType);
        var decoratedType2 = new TypeDecorator(testCases.InnerType);

        //act
        var actual1 = decoratedType1.Equals((object)decoratedType2);
        var actual2 = decoratedType1.Equals((object)testCases.InnerType);

        //assets
        actual1.Should().BeTrue();
        actual2.Should().BeTrue();
    }

    [Fact]
    public void Equals_NotEqualsObject_False()
    {
        var testCases = new
        {
            InnerType = typeof(InnerTypeClass),
            InnerType2 = typeof(InnerTypeClass2)
        };
        //arrage
        var decoratedType1 = new TypeDecorator(testCases.InnerType);
        var decoratedType2 = new TypeDecorator(testCases.InnerType2);

        //act
        var actual1 = decoratedType1.Equals((object)decoratedType2);
        var actual2 = decoratedType1.Equals((object)testCases.InnerType2);

        //assets
        actual1.Should().BeFalse();
        actual2.Should().BeFalse();
    }

    [Fact]
    public void IsEquivalentTo_Equals_True()
    {
        var testCases = new
        {
            InnerType = typeof(InnerTypeClass)
        };
        //arrage
        var decoratedType1 = new TypeDecorator(testCases.InnerType);
        var decoratedType2 = new TypeDecorator(testCases.InnerType);

        //act
        var actual1 = decoratedType1.IsEquivalentTo(decoratedType2);
        var actual2 = decoratedType1.IsEquivalentTo(testCases.InnerType);

        //assets
        actual1.Should().BeTrue();
        actual2.Should().BeTrue();
    }

    [Fact]
    public void IsEquivalentTo_OperatorEquals_True()
    {
        var testCases = new
        {
            InnerType = typeof(InnerTypeClass)
        };
        //arrage
        var decoratedType1 = new TypeDecorator(testCases.InnerType);
        var decoratedType2 = new TypeDecorator(testCases.InnerType);

        //act
        var actualDecoratedTypeEqDecoratedType = decoratedType1 == decoratedType2;
        var actualDecoratedTypeEqDecoratedTypeReverse = decoratedType2 == decoratedType1;
        var actualDecoratedTypeEqInnerType = decoratedType1 == testCases.InnerType;
        var actualDecoratedTypeEqInnerTypeReverse = testCases.InnerType == decoratedType1;

        //assets
        actualDecoratedTypeEqDecoratedType.Should().BeTrue();
        actualDecoratedTypeEqDecoratedTypeReverse.Should().BeTrue();
        actualDecoratedTypeEqInnerType.Should().BeTrue();
        actualDecoratedTypeEqInnerTypeReverse.Should().BeTrue();
    }

    [Fact]
    public void IsEquivalentTo_OperatorNotEquals_False()
    {
        var testCases = new
        {
            InnerType = typeof(InnerTypeClass)
        };
        //arrage
        var decoratedType1 = new TypeDecorator(testCases.InnerType);
        var decoratedType2 = new TypeDecorator(testCases.InnerType);

        //act
        var actualDecoratedTypeNotEqDecoratedType = decoratedType1 != decoratedType2;
        var actualDecoratedTypeNotEqDecoratedTypeReverse = decoratedType2 != decoratedType1;
        var actualDecoratedTypeNotEqInnerType = decoratedType1 != testCases.InnerType;
        var actualDecoratedTypeNotEqInnerTypeReverse = testCases.InnerType != decoratedType1;

        //assets
        actualDecoratedTypeNotEqDecoratedType.Should().BeFalse();
        actualDecoratedTypeNotEqDecoratedTypeReverse.Should().BeFalse();
        actualDecoratedTypeNotEqInnerType.Should().BeFalse();
        actualDecoratedTypeNotEqInnerTypeReverse.Should().BeFalse();
    }

    private sealed class InnerTypeClass { }
    private sealed class InnerTypeClass2 { }
}
