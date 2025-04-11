using System.Numerics;

namespace SonarSample.Library;

public class GenericOperator<T>
    where T : IAdditionOperators<T, T, T>, ISubtractionOperators<T, T, T>
{
    public T Add(T left, T right) => left + right;

    public T Subtract(T left, T right) => left - right;

    public static GenericOperator<T> Instance { get; } = new GenericOperator<T>();
}
