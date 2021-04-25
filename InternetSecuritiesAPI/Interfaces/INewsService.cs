using InternetSecuritiesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetSecuritiesAPI.Interfaces
{
    public interface INewsService
    {
        News FindById(int id);

        void SaveInDatabase(News story);

        void DeleteStory(News story);

        List<News> GetAllNewsToList();

        List<News> SearchForStories(string keyword);
    }
}
