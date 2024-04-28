using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RecipeRepository;
public static class DevExtensions
{
    public static void Inspect(this object obj) => obj.Inspect<object>();

    static readonly JsonSerializerOptions options = new()
    {
        WriteIndented = true,
        ReferenceHandler = ReferenceHandler.Preserve
    };

    static T Inspect<T>(this T obj)
    {
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