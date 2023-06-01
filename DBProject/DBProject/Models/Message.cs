using System;
using System.Collections.Generic;
using System.Linq;


namespace DBProject.Models
{
    public class Message
    {
        public Message()
        {
            MessageText = "";
            Succes = true;
            Title = "";
            Url = "";
            UrlTitle = "";
        }
        public string MessageText { get; set; }
        public bool Succes { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string UrlTitle { get; set; }
    }
}