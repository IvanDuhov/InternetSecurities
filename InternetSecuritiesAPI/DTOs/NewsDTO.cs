using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetSecuritiesAPI.DTOs
{
    public class NewsDTO
    {
        public NewsDTO(string title, string body, int id = 0)
        {
            Title = title;
            Body = body;
            Id = id;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}