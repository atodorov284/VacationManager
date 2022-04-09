using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Text.Json;

namespace VacationManager.ExtentionMethods
{
    /// <summary>
    /// Class SessionExtentions.
    /// </summary>
    public static class SessionExtentions
    {
        /// <summary>
        /// Sets the object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance">The instance.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public static void SetObject<T>(this ISession instance, string key, T value)
            where T : class
        {
            if (value == null)
            {
                instance.Remove(key);
                return;
            }

            string jsonData = JsonSerializer.Serialize(value);
            instance.SetString(key, jsonData);
        }

        /// <summary>
        /// Gets the object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance">The instance.</param>
        /// <param name="key">The key.</param>
        /// <returns>T.</returns>
        public static T GetObject<T>(this ISession instance, string key)
            where T : class
        {
            if (!instance.Keys.Contains(key))
                return null;

            string jsonData = instance.GetString(key);

            if (String.IsNullOrEmpty(jsonData))
                return null;

            return JsonSerializer.Deserialize<T>(jsonData);
        }
    }
}
