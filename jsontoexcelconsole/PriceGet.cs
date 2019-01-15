﻿using System;
using System.Net;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PriceGet
{

    public class Rootobject
    {
        public int resultCount { get; set; }
        public Result[] results { get; set; }
    }

    public class Result
    {
        public string[] ipadScreenshotUrls { get; set; }
        public object[] appletvScreenshotUrls { get; set; }
        public string[] screenshotUrls { get; set; }
        public string artworkUrl60 { get; set; }
        public string artworkUrl512 { get; set; }
        public string artworkUrl100 { get; set; }
        public string artistViewUrl { get; set; }
        public bool isGameCenterEnabled { get; set; }
        public string kind { get; set; }
        public string[] features { get; set; }
        public string[] supportedDevices { get; set; }
        public object[] advisories { get; set; }
        public float averageUserRatingForCurrentVersion { get; set; }
        public string trackCensoredName { get; set; }
        public string[] languageCodesISO2A { get; set; }
        public string fileSizeBytes { get; set; }
        public string sellerUrl { get; set; }
        public string contentAdvisoryRating { get; set; }
        public int userRatingCountForCurrentVersion { get; set; }
        public string trackViewUrl { get; set; }
        public string trackContentRating { get; set; }
        public string minimumOsVersion { get; set; }
        public DateTime currentVersionReleaseDate { get; set; }
        public string releaseNotes { get; set; }
        public string primaryGenreName { get; set; }
        public string formattedPrice { get; set; }
        public string wrapperType { get; set; }
        public string version { get; set; }
        public string currency { get; set; }
        public int artistId { get; set; }
        public string artistName { get; set; }
        public string[] genres { get; set; }
        public float price { get; set; }
        public string description { get; set; }
        public string bundleId { get; set; }
        public DateTime releaseDate { get; set; }
        public bool isVppDeviceBasedLicensingEnabled { get; set; }
        public string[] genreIds { get; set; }
        public string sellerName { get; set; }
        public int trackId { get; set; }
        public string trackName { get; set; }
        public int primaryGenreId { get; set; }
        public float averageUserRating { get; set; }
        public int userRatingCount { get; set; }
    }

    class AppPriceGet
    {
        public float GetAppPrice(string id)
        {
            string url = "https://itunes.apple.com/lookup?id=";
            url += id;
            url += "&country=JP";
            string text;
            var req = WebRequest.Create(url);
            using (var res = req.GetResponse())
            using (var sr = new StreamReader(res.GetResponseStream(), Encoding.UTF8))
            {
                text = sr.ReadToEnd();
            }
            var list = JsonConvert.DeserializeObject<Rootobject>(text);
            if (list.resultCount == 0)
            {
                return 0;
            }
            else
            {
                return list.results[0].price;
            }
        }
    }
}
