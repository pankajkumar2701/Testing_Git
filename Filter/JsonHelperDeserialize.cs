using System;
using System.Text.Json;

namespace Testing_Git.Filter
{
    public static class JsonHelper
    {
        public static T Deserialize<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}