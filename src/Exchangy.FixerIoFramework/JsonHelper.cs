using System.Text.Json;

namespace Exchangy.FixerIoFramework
{
    internal static class JsonHelper
    {
        public static JsonSerializerOptions DefaultOptions { get; } = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            AllowTrailingCommas = true
        };
    }
}
