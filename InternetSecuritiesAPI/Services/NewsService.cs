using InternetSecuritiesAPI.Data;
using InternetSecuritiesAPI.Interfaces;
using InternetSecuritiesAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace InternetSecuritiesAPI.Services
{
    public class NewsService : INewsService
    {
        private ApplicationDbContext _context;

        public NewsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void DeleteStory(News story)
        {
            _context.News.Remove(story);
            _context.SaveChanges();
        }

        public News FindById(int id)
        {
            var story = _context.News.SingleOrDefault(s => s.Id == id);

            return story;
        }

        public List<News> GetAllNewsToList()
        {
            return _context.News.ToList();
        }

        public void SaveInDatabase(News story)
        {
            if (FindById(story.Id) != null)
            {
                _context.News.Remove(FindById(story.Id));
            }

            _context.News.Add(story);
            _context.SaveChanges();
        }

        // GET /api/news/
        public List<News> SearchForStories(string keyword)
        {
            var result = _context.News.Where(s => s.Title.Contains(keyword) || s.Body.Contains(keyword)).ToList();

            if (result == null)
            {
                return new List<News>();
            }

            return result;
        }
    }
}
