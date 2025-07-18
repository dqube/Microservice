using System.Text.Json.Serialization;

namespace CompanyName.MyProjectName.BuildingBlocks.Domain.Core;

// YourCompany.DDD.Core/Identity.cs
public abstract record StronglyTypedId<TValue>(TValue Value) : IStronglyTpeId<TValue>, IComparable<StronglyTypedId<TValue>>
    where TValue : notnull, IComparable<TValue>
{
    public static implicit operator TValue(StronglyTypedId<TValue> id) => id.Value;

    public override string ToString() => Value.ToString() ?? string.Empty;

    public int CompareTo(StronglyTypedId<TValue> other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (other is null) return 1;
        return Value.CompareTo(other.Value);
    }

    public virtual bool Equals(StronglyTypedId<TValue> other)
    {
        if (ReferenceEquals(this, other)) return true;
        if (other is null) return false;
        return Value.Equals(other.Value);
    }

    public override int GetHashCode() => Value.GetHashCode();
}
