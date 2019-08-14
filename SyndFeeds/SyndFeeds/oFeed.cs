using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SyndFeeds
{
    public class oFeed
    {
        public string title { get; set; }
        public string link { get; set; }
        public string description { get; set; }
        public string lastBuildDate { get; set; }
        public string language { get; set; }
        public string generator { get; set; }
        public string item { get; set; }
        public string itemtitle { get; set; }
        public List<string> itemlink { get; set; }
        public string comments { get; set; }
        public DateTime pubDate { get; set; }
        public string creator { get; set; }
        public List<string> category { get; set; }
        public string id { get; set; }
        public string itemDescription { get; set; }
        public string content { get; set; }


        public oFeed() { }

    }
}
