using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace GeoRSSLibrary
{
    public interface IGeoRssItem
    {
        string Id;
        DateTime PubDate;
        string Title;
        string SubTitle;
        string Description;
        string Author;
        string Link;
        
    }
}
