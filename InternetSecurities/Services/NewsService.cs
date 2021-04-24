using InternetSecurities.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace InternetSecurities.Services
{
    public class NewsService : INewsService
    {
        private readonly string apiUrl = "https://localhost:44361/api/news/";

        public News CreateStory(News story)
        {
            WebRequest requestObject = WebRequest.Create(apiUrl);
            requestObject.Method = "POST";
            requestObject.ContentType = "application/json";

            string jsonObject = JsonConvert.SerializeObject(story);

            using (var writer = new StreamWriter(requestObject.GetRequestStream()))
            {
                writer.Write(jsonObject);
                writer.Flush();
                writer.Close();

                var httpResponse = (HttpWebResponse)requestObject.GetResponse();

                using (var reader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var res2 = reader.ReadToEnd();
                }
            }

            return story;
        }

        public void DeleteStory(int id)
        {
            WebRequest requestObject = WebRequest.Create(apiUrl + id);
            requestObject.Method = "DELETE";
            requestObject.ContentType = "application/json";

            var httpResponse = (HttpWebResponse)requestObject.GetResponse();
        }

        public void EditStory(int id, News story)
        {
            WebRequest requestObject = WebRequest.Create(apiUrl + story.Id);
            requestObject.Method = "PUT";
            requestObject.ContentType = "application/json";

            string jsonObject = JsonConvert.SerializeObject(story);

            using (var writer = new StreamWriter(requestObject.GetRequestStream()))
            {
                writer.Write(jsonObject);
                writer.Flush();
                writer.Close();

                var httpResponse = (HttpWebResponse)requestObject.GetResponse();
            }
        }

        public List<News> GetAllNews()
        {
            WebRequest requestObject = WebRequest.Create(apiUrl);
            requestObject.Method = "GET";

            HttpWebResponse responseObject = null;
            responseObject = (HttpWebResponse)requestObject.GetResponse();

            string stringResult = "";

            using (Stream stream = responseObject.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                stringResult = sr.ReadToEnd();
                sr.Close();
            }

            return JsonConvert.DeserializeObject<List<News>>(stringResult);
        }

        public News GetStory(int id)
        {
            WebRequest requestObject = WebRequest.Create(apiUrl + id);
            requestObject.Method = "GET";

            HttpWebResponse responseObject = null;
            responseObject = (HttpWebResponse)requestObject.GetResponse();

            string stringResult = "";

            using (Stream stream = responseObject.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                stringResult = sr.ReadToEnd();
                sr.Close();
            }

            return JsonConvert.DeserializeObject<News>(stringResult);
        }
    }
}
