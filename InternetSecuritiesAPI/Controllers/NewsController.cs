using InternetSecuritiesAPI.Data;
using InternetSecuritiesAPI.DTOs;
using InternetSecuritiesAPI.Interfaces;
using InternetSecuritiesAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace InternetSecuritiesAPI.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        /// <summary>
        /// Gets all the news from the database. // GET /api/stories
        /// </summary>
        /// <returns></returns>
        /// /api/news/1
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public IEnumerable<NewsDTO> GetNews()
        {
            List<NewsDTO> result = new List<NewsDTO>();

            var stories = _newsService.GetAllNewsToList();

            foreach (var story in stories)
            {
                result.Add(new NewsDTO(story.Title, story.Body, story.Id));
            }

            return result;
        }

        /// <summary>
        /// Gets a single story. /api/news/1
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpGet("{id}/")]
        public NewsDTO GetStory(int id)
        {
            var story = _newsService.FindById(id);

            if (story == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            NewsDTO result = new NewsDTO(story.Title, story.Body, story.Id);

            return result;
        }

        // POST /api/news
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public News CreateStory(News story)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _newsService.SaveInDatabase(story);

            return story;
        }

        // PUT /api/news/1
        [Microsoft.AspNetCore.Mvc.HttpPut("{id}/")]
        public void UpdateStory(int id, News story)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var storyInDb = _newsService.FindById(id);

            if (storyInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            // Create story from the DTO object
            // News story = _newsService.DTOToModel(storyDTO);

            _newsService.SaveInDatabase(story);
        }

        // DELETE /api/news/1
        [Microsoft.AspNetCore.Mvc.HttpDelete("{id}/")]
        public void DeleteStory(int id)
        {
            var storyInDb = _newsService.FindById(id);

            if (storyInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _newsService.DeleteStory(storyInDb);
        }

        // GET /api/news/search/{keyword}
        [Microsoft.AspNetCore.Mvc.HttpGet("search/{keyword}")]
        public IEnumerable<NewsDTO> SearchForStoriesByKeyWord(string keyword)
        {
            List<NewsDTO> result = new List<NewsDTO>();

            var stories = _newsService.SearchForStories(keyword);

            foreach (var story in stories)
            {
                result.Add(new NewsDTO(story.Title, story.Body, story.Id));
            }

            return result;
        }

    }
}
