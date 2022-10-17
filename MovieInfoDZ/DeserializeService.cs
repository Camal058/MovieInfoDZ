using MovieInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieInfoDZ
{
    public static class DeserializeService
    {
        public static Task<SearchRes?> Deserialize(string json)
        {
            return Task.FromResult(JsonSerializer.Deserialize<SearchRes>(json));
        }
    }
}