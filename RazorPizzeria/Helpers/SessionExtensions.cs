using System.Text.Json;
using System.Text.Json.Serialization;

namespace RazorPizzeria.Helpers
{
    public static class SessionExtensions
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };
            session.SetString(key, JsonSerializer.Serialize(value, options));
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };
            return value == null ? default(T) : JsonSerializer.Deserialize<T>(value, options);
        }
    }
}
