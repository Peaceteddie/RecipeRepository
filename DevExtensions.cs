using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RecipeRepository;
public static class DevExtensions
{
    private static readonly JsonSerializerOptions _jsonOptions = new() { WriteIndented = true };
    public static T Inspect<T>(this T obj)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            ReferenceHandler = ReferenceHandler.Preserve
        };

        switch (obj)
        {
            case string stringValue:
                Console.WriteLine(stringValue);
                break;
            case IEnumerable enumerableValue:
                foreach (var item in enumerableValue)
                    Console.WriteLine(JsonSerializer.Serialize(item, options));
                break;
            default:
                Console.WriteLine(JsonSerializer.Serialize(obj, options));
                break;
        }

        return obj;
    }
}