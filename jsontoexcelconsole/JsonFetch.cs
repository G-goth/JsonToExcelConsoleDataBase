using System;
using System.Net;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace JsonFetchFree
{
    public class Rootobject
    {
        public Feed feed { get; set; }
    }

    public class Feed
    {
        public string title { get; set; }
        public string id { get; set; }
        public Author author { get; set; }
        public Link[] links { get; set; }
        public string copyright { get; set; }
        public string country { get; set; }
        public string icon { get; set; }
        public DateTime updated { get; set; }
        public Result[] results { get; set; }
    }

    public class Author
    {
        public string name { get; set; }
        public string uri { get; set; }
    }

    public class Link
    {
        public string self { get; set; }
        public string alternate { get; set; }
    }

    public class Result
    {
        public string artistName { get; set; }
        public string id { get; set; }
        public string releaseDate { get; set; }
        public string name { get; set; }
        public string kind { get; set; }
        public string copyright { get; set; }
        public string artistId { get; set; }
        public string artistUrl { get; set; }
        public string artworkUrl100 { get; set; }
        public Genre[] genres { get; set; }
        public string url { get; set; }
    }

    public class Genre
    {
        public string genreId { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class JsonFetch
    {
        public List<string> JsonToStringFree(string url, bool swh)
        {
            //HTTPアクセス
            string text;
            List<string> appName = new List<string>();
            List<string> appURL = new List<string>();
            var req = WebRequest.Create(url);
            using (var res = req.GetResponse())
            using (var sr = new StreamReader(res.GetResponseStream(), Encoding.UTF8))
            {
                text = sr.ReadToEnd();
            }
            var list = JsonConvert.DeserializeObject<Rootobject>(text);
            for(int i = 0; i < 100; ++i)
            {
                appName.Add(list.feed.results[i].name);
                appURL.Add(list.feed.results[i].url);
            }


            if(swh == true)
            {
                return appName;
            }
            else
            {
                return appURL;
            }
        }
    }
}
