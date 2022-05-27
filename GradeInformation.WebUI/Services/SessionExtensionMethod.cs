using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace GradeInformation.WebUI.Services
{
    public static class SessionExtensionMethod
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            var objectString = JsonConvert.SerializeObject(value);
            session.SetString(key, objectString);
        }

        public static T GetObject<T>(this ISession session, string key) where T : class
        {
            var objectString = session.GetString(key);
            if (string.IsNullOrEmpty(objectString))
            {
                return null;
            }
            T value = JsonConvert.DeserializeObject<T>(objectString);
            return value;
        }
    }
}
