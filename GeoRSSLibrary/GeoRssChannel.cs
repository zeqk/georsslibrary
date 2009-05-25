using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;


namespace GeoRSSLibrary
{
    public class GeoRssChannel
    {

        private string _title;
        private string _link;
        private List<GeoRssItem> _items;


        #region Constructors
        public GeoRssChannel(XmlNode channelNode)
        {
            this._items = new List<GeoRssItem>();
            this._title = channelNode.SelectSingleNode("title").InnerText;
            this._link = channelNode.SelectSingleNode("link").InnerText;

            XmlNodeList itemNodes = channelNode.SelectNodes("item");

            foreach (XmlNode item in itemNodes)
            {
                     this._items.Add(new GeoRssItem(item));                
            }
        }


        #endregion


        public string Title
        {
            get
            {
                return this._title;
            }
            set
            {
                this._title = value;
            }
        }

        public string Link
        {
            get
            {
                return this._link;
            }
            set
            {
                this._link = value;
            }
        }

        public List<GeoRssItem> Items
        {
            get
            {
                return this._items;
            }
            set
            {
                this._items = value;
            }
        }

        
    }
}
