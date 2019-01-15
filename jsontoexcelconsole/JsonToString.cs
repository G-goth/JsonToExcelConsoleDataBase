using System;
using System.Net;
using System.IO;
using System.Text;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace JsonToString
{
    [DataContract]
    public class Rootobject
    {
        [DataMember]
        public Feed feed { get; set; }
    }

    [DataContract]
    public class Feed
    {
        [DataMember]
        public Author author { get; set; }
        [DataMember]
        public Entry[] entry { get; set; }
        [DataMember]
        public Updated updated { get; set; }
        [DataMember]
        public Rights rights { get; set; }
        [DataMember]
        public Title title { get; set; }
        [DataMember]
        public Icon icon { get; set; }
        [DataMember]
        public Link1[] link { get; set; }
        [DataMember]
        public Id id { get; set; }
    }

    [DataContract]
    public class Author
    {
        [DataMember]
        public Name name { get; set; }
        [DataMember]
        public Uri uri { get; set; }
    }

    [DataContract]
    public class Name
    {
        [DataMember]
        public string label { get; set; }
    }

    [DataContract]
    public class Uri
    {
        [DataMember]
        public string label { get; set; }
    }

    [DataContract]
    public class Updated
    {
        [DataMember]
        public DateTime label { get; set; }
    }

    [DataContract]
    public class Rights
    {
        [DataMember]
        public string label { get; set; }
    }

    [DataContract]
    public class Title
    {
        [DataMember]
        public string label { get; set; }
    }

    [DataContract]
    public class Icon
    {
        [DataMember]
        public string label { get; set; }
    }

    [DataContract]
    public class Id
    {
        [DataMember]
        public string label { get; set; }
    }

    [DataContract]
    public class Entry
    {
        [DataMember(Name = "im:name")]
        public ImName imname { get; set; }
        public ImImage[] imimage { get; set; }
        [DataMember]
        public Summary summary { get; set; }
        [DataMember(Name = "im:price")]
        public ImPrice imprice { get; set; }
        [DataMember]
        public ImContenttype imcontentType { get; set; }
        [DataMember]
        public Rights1 rights { get; set; }
        [DataMember]
        public Title1 title { get; set; }
        [DataMember]
        public Link link { get; set; }
        [DataMember]
        public Id1 id { get; set; }
        [DataMember]
        public ImArtist imartist { get; set; }
        [DataMember]
        public Category category { get; set; }
        [DataMember]
        public ImReleasedate imreleaseDate { get; set; }
    }

    [DataContract]
    public class ImName
    {
        [DataMember]
        public string label { get; set; }
    }

    public class Summary
    {
        public string label { get; set; }
    }

    public class ImPrice
    {
        public string label { get; set; }
        public Attributes attributes { get; set; }
    }

    public class Attributes
    {
        public string amount { get; set; }
        public string currency { get; set; }
    }

    public class ImContenttype
    {
        public Attributes1 attributes { get; set; }
    }

    public class Attributes1
    {
        public string term { get; set; }
        public string label { get; set; }
    }

    public class Rights1
    {
        public string label { get; set; }
    }

    public class Title1
    {
        public string label { get; set; }
    }

    public class Link
    {
        public Attributes2 attributes { get; set; }
    }

    public class Attributes2
    {
        public string rel { get; set; }
        public string type { get; set; }
        public string href { get; set; }
    }

    public class Id1
    {
        public string label { get; set; }
        public Attributes3 attributes { get; set; }
    }

    public class Attributes3
    {
        public string imid { get; set; }
        public string imbundleId { get; set; }
    }

    public class ImArtist
    {
        public string label { get; set; }
        public Attributes4 attributes { get; set; }
    }

    public class Attributes4
    {
        public string href { get; set; }
    }

    public class Category
    {
        public Attributes5 attributes { get; set; }
    }

    public class Attributes5
    {
        public string imid { get; set; }
        public string term { get; set; }
        public string scheme { get; set; }
        public string label { get; set; }
    }

    public class ImReleasedate
    {
        public DateTime label { get; set; }
        public Attributes6 attributes { get; set; }
    }

    public class Attributes6
    {
        public string label { get; set; }
    }

    public class ImImage
    {
        public string label { get; set; }
        public Attributes7 attributes { get; set; }
    }

    public class Attributes7
    {
        public string height { get; set; }
    }

    public class Link1
    {
        public Attributes8 attributes { get; set; }
    }

    public class Attributes8
    {
        public string rel { get; set; }
        public string type { get; set; }
        public string href { get; set; }
    }
    class JsonToStringClass
    {
        public List<string> JsonToString(string url, int retval)
        {
            //URL
            //url = "https://itunes.apple.com/jp/rss/topfreeapplications/limit=100/genre=6014/json";
            //url = "https://itunes.apple.com/jp/rss/toppaidapplications/limit=100/genre=6014/json";
            //url = "https://itunes.apple.com/jp/rss/topgrossingapplications/limit=100/genre=6014/json";

            //HTTPアクセス
            string text;
            List<string> appName = new List<string>();
            List<string> appURL = new List<string>();
            List<string> appPrice = new List<string>();

            var req = WebRequest.Create(url);
            using (var res = req.GetResponse())
            using (var sr = new StreamReader(res.GetResponseStream(), Encoding.UTF8))
            {
                text = sr.ReadToEnd();
            }
            var list = JsonConvert.DeserializeObject<Rootobject>(text);
            for (int i = 0; i < 100; ++i)
            {
                appName.Add(list.feed.entry[i].imname.label);
                appPrice.Add(list.feed.entry[i].imprice.label);
                appURL.Add(list.feed.entry[i].link.attributes.href);
            }

            if (retval == 0)
            {
                return appName;
            }
            else if (retval == 1)
            {
                return appPrice;
            }
            else
            {
                return appURL;
            }
        }
    }
}
