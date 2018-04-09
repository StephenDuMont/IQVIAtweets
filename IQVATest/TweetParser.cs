using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;

namespace IQVATest
{
    public class TweetParser
    {
        //static IEnumerable<Tweet> tweets = new List<Tweet>();
        static string url = @"https://badapi.iqvia.io/api/v1/Tweets?";
        

        public static List<Tweet> GetFullRange(DateTime startDate, DateTime endDate)
        {
            IEnumerable<Tweet> allTweets = new List<Tweet>();
            IEnumerable<Tweet> tweets = new List<Tweet>();
            DateTime indexDate = startDate;
            while ((tweets = GetRange(indexDate, endDate)).Count()==100)
            {
                allTweets = allTweets.Concat(tweets);
                indexDate = tweets.Last().stamp.Add(TimeSpan.FromMilliseconds(1));
            }
            allTweets = allTweets.Concat(tweets);
            return allTweets.ToList<Tweet>();
        }
        private static  List<Tweet> GetRange(DateTime startDate, DateTime endDate)
        {
            string uriString = String.Format(url + "startDate={0}&endDate={1}", startDate, endDate);

            var httpClient = new HttpClient();
            var content =  httpClient.GetStringAsync(uriString);
            return  JsonConvert.DeserializeObject<List<Tweet>>(content.Result);

        }
    }
}
