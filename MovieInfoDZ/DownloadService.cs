using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace MovieInfoDZ
{
    public static class DownloadService
    {
        public static async Task<string> FindMovie(string? name)
        {
            WebClient client = new();

            string uri = $@"https://movie-database-alternative.p.rapidapi.com/";

            client.Headers.Add("X-RapidAPI-Key", "c52411603dmshd65fa5910020029p164ceajsna440e9e02bb3");
            client.Headers.Add("X-RapidAPI-Host", "movie-database-alternative.p.rapidapi.com");

            return await client.DownloadStringTaskAsync(new Uri(uri));
            //return client.DownloadString($"{uri}{name}");
        }

    }
}