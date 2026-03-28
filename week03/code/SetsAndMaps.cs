using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    public static string[] FindPairs(string[] words)
    {
        var result = new List<string>();
        var seen = new HashSet<string>();

        foreach (var word in words)
        {
            string reversed = new string([word[1], word[0]]);
            if (seen.Contains(reversed))
            {
                result.Add($"{reversed} & {word}");
            }
            else
            {
                seen.Add(word);
            }
        }
        return result.ToArray();
    }
    
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            string degree = fields[3].Trim();

            if (degrees.ContainsKey(degree))
                degrees[degree]++;
            else
                degrees[degree] = 1;
        }
        return degrees;
    }

    public static bool IsAnagram(string word1, string word2)
    {
        string w1 = word1.Replace(" ", "").ToLower();
        string w2 = word2.Replace(" ", "").ToLower();

        if (w1.Length != w2.Length) return false;

        var charCounts = new Dictionary<char, int>();

        foreach (char c in w1)
        {
            charCounts[c] = charCounts.GetValueOrDefault(c) + 1;
        }

        foreach (char c in w2)
        {
            if (!charCounts.ContainsKey(c) || charCounts[c] == 0)
                return false;
            charCounts[c]--;
        }

        return true;
    }

    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Add("User-Agent", "C# HttpClient/1.0");
        
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        var response = client.Send(getRequestMessage);
        response.EnsureSuccessStatusCode();

        using var jsonStream = response.Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var summaries = new List<string>();
        if (featureCollection?.Features != null)
        {
            foreach (var feature in featureCollection.Features)
            {
                summaries.Add($"{feature.Properties.Place} - Mag {feature.Properties.Mag}");
            }
        }

        return summaries.ToArray();
    }
}
