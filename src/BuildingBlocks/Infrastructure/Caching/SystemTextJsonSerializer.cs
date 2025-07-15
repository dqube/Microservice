using CompanyName.MyProjectName.BuildingBlocks.Application.Caching;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CompanyName.MyProjectName.BuildingBlocks.Infrastructure.Caching;

public sealed class SystemTextJsonSerializer : IHybridCacheSerializer
{
    private readonly JsonSerializerOptions _options;

    public SystemTextJsonSerializer(JsonSerializerOptions options = null)
    {
        _options = options ?? new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            WriteIndented = false
        };
    }

    public byte[] Serialize<T>(T value)
    {
        return JsonSerializer.SerializeToUtf8Bytes(value, _options);
    }

    public T? Deserialize<T>(byte[] bytes)
    {
        return JsonSerializer.Deserialize<T>(bytes.AsSpan(), _options);
    }
}