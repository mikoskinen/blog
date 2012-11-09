using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace WinRT_GridView_XAML_Performance_Problems.Data
{
    public class MovieService
    {
        private const string Uri = @"https://api.elisaviihde.fi/etvrecorder/vod.sl?data=true&category=popular&count=125";

        public async Task<List<MovieInfo>> GetMovies()
        {
            var client = new HttpClient();

            var jsonStream = await client.GetStreamAsync(Uri);
            var serializer = new DataContractJsonSerializer(typeof(MovieInfoCollectionDto));

            var collection = (MovieInfoCollectionDto)serializer.ReadObject(jsonStream);

            var result = collection.vods.Select(x => x).ToList();
            return result;
        }
    }

    [DataContract]
    public class MovieInfoCollectionDto
    {
        [DataMember]
        public List<MovieInfo> vods;
    }

    [DataContract]
    public class MovieInfo
    {
        [DataMember]
        private string title;
        [DataMember]
        private long id;
        [DataMember]
        private int length;
        [DataMember]
        private string agelimit;
        [DataMember]
        private int year;
        [DataMember]
        private int price;
        [DataMember]
        private string currency;
        [DataMember]
        private string trailer_url;
        [DataMember]
        private string cover;
        [DataMember]
        private string categoryid;

        public string Title
        {
            get { return title; }
        }

        public int Year
        {
            get { return year; }
        }

        public string Cover
        {
            get { return cover; }
        }
    }
}
