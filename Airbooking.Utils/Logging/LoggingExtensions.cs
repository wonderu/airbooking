using Newtonsoft.Json;
using System.Web;

namespace Airbooking.Utils.Logging
{
    /// <summary>
    /// Logging Extensions class
    /// </summary>
    public static class LoggingExtensions
    {
        /// <summary>
        /// To the json.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string ToJson(this object value)
        {
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            return JsonConvert.SerializeObject(value, Formatting.Indented, settings);
        }

        /// <summary>
        /// Adds the request identifier.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string AddRequestId(this string value)
        {
            if (HttpContext.Current==null)
                return value;

            string requestId = HttpContext.Current.Items["RequestId"]?.ToString();
            if (string.IsNullOrEmpty(requestId))
                return value;

            return $"{value} RequestId='{requestId}'";
        }
    }
}
