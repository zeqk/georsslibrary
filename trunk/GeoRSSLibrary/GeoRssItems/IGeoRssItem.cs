using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace GeoRSSLibrary.GeoRssItems
{
    public interface IGeoRssItem
    {
        string Guid {get; set;}
        DateTime PubDate { get; set; }
        string Title { get; set; }
        string SubTitle { get; set; }
        string Description { get; set; }
        string Author { get; set; }
        string Link { get; set; }
        
    }
}
