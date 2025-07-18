using System.Text.Json;

namespace CompanyName.MyProjectName.BuildingBlocks.Domain.Core;

// YourCompany.DDD.Abstractions/IIdentity.cs
public interface IStronglyTpeId<T>
    where T : notnull
{
    T Value { get; }
}

//// Example usage
//public record ProductId(int Value) : Identity<int>(Value);
//public record CustomerId(Guid Value) : Identity<Guid>(Value);


// ProductId.cs
//public record ProductId(int Value) : StronglyTypedId<int>(Value)
//{
//    public static ProductId Create(int value) => new(value);
//}

//// OrderId.cs
//public record OrderId(Guid Value) : StronglyTypedId<Guid>(Value)
//{
//    public static OrderId Create(Guid value) => new(value);
//}

/// Program.cs or Startup.cs
//builder.Services.AddControllers()
//    .AddJsonOptions(options =>
//    {
//    options.JsonSerializerOptions.Converters.Add(new StronglyTypedIdJsonConverterFactory());
//    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
//});