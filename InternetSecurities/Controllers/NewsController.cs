using InternetSecurities.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace InternetSecurities.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewStory()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            var story = _newsService.GetStory(id);

            return View("NewStory", story);
        }

        public IActionResult SaveStory(News story)
        {
            if (story.Id != 0)
            {
                _newsService.EditStory(story.Id, story);
            }
            else
            {
                _newsService.CreateStory(story);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
