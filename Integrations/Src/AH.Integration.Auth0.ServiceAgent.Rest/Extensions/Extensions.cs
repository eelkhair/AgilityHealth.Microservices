using AH.Integration.Auth0.ServiceAgent.Dtos;
using Newtonsoft.Json;

namespace AH.Integration.Auth0.ServiceAgent.Rest.Extensions;

public static class SerializationExtensions
{
    public static JsonSerializerSettings GetIgnoreSerializerSettings<TDto>(IEnumerable<string>? propertiesToIgnore)
    {
        var jsonResolver = new PropertyRenameAndIgnoreSerializerContractResolver();

        if (propertiesToIgnore != null)
        {
            foreach (var item in propertiesToIgnore)
            {
                var split = item.Split(":");
                if (split.Length > 1)
                {
                    var assembly = typeof(UserDto).Assembly;
                    var typeName = $"Fms.Integration.Auth0.ServiceAgent.Dtos.{split[0]}";
                    jsonResolver.IgnoreProperty(assembly.GetType(typeName), split[1]);
                }
                else
                {
                    jsonResolver.IgnoreProperty(typeof(TDto), item);
                }
                    
            }
        }

        var serializerSettings = new JsonSerializerSettings
        {
            ContractResolver = jsonResolver
        };
        return serializerSettings;
    }

    public static TDto Mask<TDto>(TDto dto, IEnumerable<string>? properties)
    {
        var serialized = JsonConvert.SerializeObject(dto, GetIgnoreSerializerSettings<TDto>(properties));
        return JsonConvert.DeserializeObject<TDto>(serialized);
    }
}