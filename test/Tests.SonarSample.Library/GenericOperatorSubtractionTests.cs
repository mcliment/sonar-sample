using System.Numerics;
using SonarSample.Library;

namespace Tests.SonarSample.Library;

public class GenericOperatorSubtractionTests
{
    [Test]
    public void GenericOperator_Addition()
    {
        var intOperator = GenericOperator<int>.Instance;
        var result = intOperator.Add(1, 2);

        Assert.That(result, Is.EqualTo(3));
    }

    [TestCase(1, 1, 2)]
    public void GenericOperator_Decimal_Addition(decimal a, decimal b, decimal expected)
    {
        var decimalOperator = GenericOperator<DecimalWrapper>.Instance;
        var result = decimalOperator.Add(new DecimalWrapper(a), new DecimalWrapper(b));

        Assert.That(result, Is.EqualTo(new DecimalWrapper(expected)));
    }

    [Test]
    public void GenericOperator_Subtraction()
    {
        var intOperator = GenericOperator<int>.Instance;
        var result = intOperator.Subtract(5, 3);

        Assert.That(result, Is.EqualTo(2));
    }

    [TestCase(5, 3, 2)]
    public void GenericOperator_Decimal_Subtraction(decimal a, decimal b, decimal expected)
    {
        var decimalOperator = GenericOperator<DecimalWrapper>.Instance;
        var result = decimalOperator.Subtract(new DecimalWrapper(a), new DecimalWrapper(b));

        Assert.That(result, Is.EqualTo(new DecimalWrapper(expected)));
    }
}

internal record DecimalWrapper(decimal Value)
    : IAdditionOperators<DecimalWrapper, DecimalWrapper, DecimalWrapper>,
        ISubtractionOperators<DecimalWrapper, DecimalWrapper, DecimalWrapper>
{
    public static DecimalWrapper operator +(DecimalWrapper left, DecimalWrapper right)
    {
        return new DecimalWrapper(left.Value + right.Value);
    }

    public static DecimalWrapper operator -(DecimalWrapper left, DecimalWrapper right)
    {
        return new DecimalWrapper(left.Value - right.Value);
    }
}
