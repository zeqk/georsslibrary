using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
namespace GeoRSSLibrary
{
    public class GeoRssFeed
    {
        private List<GeoRssChannel> _channels;

        #region Methods
        public GeoRssFeed(string path)
        {
            this._channels = new List<GeoRssChannel>();
            StreamReader sr = new StreamReader(path);
            XmlTextReader xr = new XmlTextReader(sr);
            XmlDocument rssDoc = new XmlDocument();
            try
            {
                rssDoc.Load(xr);

                XmlNode rssNode = rssDoc.SelectSingleNode("rss");
                                
                XmlNodeList channelNodes = rssNode.ChildNodes;
                foreach (XmlNode channelNode in channelNodes)
                {
                    GeoRssChannel newChannel = new GeoRssChannel(channelNode);
                    this._channels.Add(newChannel);
                }
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        #endregion


        public List<GeoRssChannel> Channels
        {
            get
            {
                return this._channels;
            }
            set
            {
                this._channels = value;
            }
        }

        public GeoRssChannel MainChannel
        {
            get
            {
                return this._channels[0];
            }
        }


    }
}
