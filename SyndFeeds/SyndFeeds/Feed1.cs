using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;

namespace SyndFeeds
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Feed1" in both code and config file together.
    public class Feed1 : IFeed1
    {
        public SyndicationFeedFormatter CreateFeed()
        {
            // Create a new Syndication Feed.
            SyndicationFeed feed = new SyndicationFeed("Feed Title", "A WCF Syndication Feed", null);
            List<SyndicationItem> items = new List<SyndicationItem>();

            // Create a new Syndication Item.
            SyndicationItem item = new SyndicationItem("An item", "Item content", null);
            items.Add(item);
            feed.Items = items;

            // Return ATOM or RSS based on query string
            // rss -> http://localhost:8733/Design_Time_Addresses/SyndFeeds/Feed1/
            // atom -> http://localhost:8733/Design_Time_Addresses/SyndFeeds/Feed1/?format=atom
            string query = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters["format"];
            SyndicationFeedFormatter formatter = null;
            if (query == "atom")
            {
                formatter = new Atom10FeedFormatter(feed);
            }
            else
            {
                formatter = new Rss20FeedFormatter(feed);
            }

            return formatter;
        }

        public static List<oFeed> GetFeed(string _Path)
        {
            var rdFeed = XmlReader.Create(_Path);
            var _Feed = SyndicationFeed.Load(rdFeed);

            List<oFeed> lstFeeds = new List<oFeed>();

            foreach (var i in _Feed.Items) {
                oFeed of = new oFeed();
                of.category = new List<string>();
                of.id = i.Id;
                of.title = i.Title.Text;
                of.language = i.ElementExtensions[0].ToString();
                of.lastBuildDate = i.PublishDate.ToString();
                of.link = i.Links[0].Uri.OriginalString;
                foreach (var cat in i.Categories)
                {
                    if (cat.Name.ToString() != "")
                    {

                        of.category.Add(cat.Name.ToString());
                    }
                    else { break; }
                }
                of.description = i.ElementExtensions[1].ToString();
                of.content = i.ElementExtensions[2].ToString();
                lstFeeds.Add(of);
            }


            return lstFeeds;
        }

        
    }
}
