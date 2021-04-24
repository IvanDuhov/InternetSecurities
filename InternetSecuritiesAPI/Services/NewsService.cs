﻿using InternetSecuritiesAPI.Data;
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
            _context.News.Remove(FindById(story.Id));
            _context.News.Add(story);
            _context.SaveChanges();
        }
    }
}