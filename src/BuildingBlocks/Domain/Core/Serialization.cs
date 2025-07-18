using System.Text.Json;
using System.Text.Json.Serialization;

namespace CompanyName.MyProjectName.BuildingBlocks.Domain.Core;

public class StronglyTypedIdJsonConverter<TStronglyTypedId, TValue> : JsonConverter<TStronglyTypedId>
    where TStronglyTypedId : StronglyTypedId<TValue>
    where TValue : IComparable<TValue>
{
    public override TStronglyTypedId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
            return null;

        try
        {
            var value = JsonSerializer.Deserialize<TValue>(ref reader, options);
            return CreateStronglyTypedId(typeToConvert, value);
        }
        catch (JsonException ex)
        {
            throw new JsonException($"Failed to deserialize {typeToConvert.Name}", ex);
        }
    }

    public override void Write(Utf8JsonWriter writer, TStronglyTypedId value, JsonSerializerOptions options)
    {
        if (value is null)
            writer.WriteNullValue();
        else
            JsonSerializer.Serialize(writer, value.Value, options);
    }

    private static TStronglyTypedId CreateStronglyTypedId(Type type, TValue value)
    {
        // Try to find a static Create method first
        var createMethod = type.GetMethod("Create", new[] { typeof(TValue) });
        if (createMethod != null)
            return (TStronglyTypedId)createMethod.Invoke(null, new object[] { value });

        // Fall back to constructor
        var constructor = type.GetConstructor(new[] { typeof(TValue) });
        if (constructor == null)
            throw new InvalidOperationException($"No suitable constructor or Create method found for {type.Name}");

        return (TStronglyTypedId)constructor.Invoke(new object[] { value });
    }
}
public class StronglyTypedIdJsonConverterFactory : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
    {
        return IsStronglyTypedId(typeToConvert);
    }

    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        if (!IsStronglyTypedId(typeToConvert))
            throw new InvalidOperationException($"Cannot create converter for {typeToConvert.Name}");

        var valueType = GetValueType(typeToConvert);
        var converterType = typeof(StronglyTypedIdJsonConverter<,>).MakeGenericType(typeToConvert, valueType);

        return (JsonConverter)Activator.CreateInstance(converterType);
    }

    private static bool IsStronglyTypedId(Type type)
    {
        while (type != null)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(StronglyTypedId<>))
                return true;

            type = type.BaseType;
        }
        return false;
    }

    private static Type GetValueType(Type stronglyTypedIdType)
    {
        var baseType = stronglyTypedIdType;
        while (baseType != null)
        {
            if (baseType.IsGenericType && baseType.GetGenericTypeDefinition() == typeof(StronglyTypedId<>))
                return baseType.GetGenericArguments()[0];

            baseType = baseType.BaseType;
        }
        throw new InvalidOperationException($"Could not find value type for {stronglyTypedIdType.Name}");
    }
}
