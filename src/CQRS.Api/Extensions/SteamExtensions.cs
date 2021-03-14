using Newtonsoft.Json;
using System;
using System.IO;

namespace CQRS.Api.Extensions
{
    public static class SteamExtensions
    {
        public static T ReadAndDeserializeFromJson<T>(this Stream stream) where T : new()
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (stream.CanRead && stream.CanSeek)
            {
                using (StreamReader streamReader = new StreamReader(stream))
                {
                    using (JsonTextReader jsonTextReader = new JsonTextReader(streamReader))
                    {
                        var jsonSerializer = new JsonSerializer();
                        return jsonSerializer.Deserialize<T>(jsonTextReader);
                    }
                }
            }

            return new T();
        }
    }
}
