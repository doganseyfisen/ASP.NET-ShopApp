using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShopApp.Infrastructure.Extensions
{
    public static class SessionExtension
    {
        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static void SetJson<Type>(this ISession session, string key, Type value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static Type? GetJson<Type>(this ISession session, string key)
        {
            var data = session.GetString(key);

            return data is null ? default(Type) : JsonSerializer.Deserialize<Type>(data);
        }
    }
}