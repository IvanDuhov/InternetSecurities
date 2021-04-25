using InternetSecurities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetSecurities
{
    public interface INewsService
    {
        List<News> GetAllNews();

        News GetStory(int id);

        News CreateStory(News story);

        void DeleteStory(int id);

        void EditStory(int id, News story);
        List<News> SearchStories(string keyword);
    }
}
