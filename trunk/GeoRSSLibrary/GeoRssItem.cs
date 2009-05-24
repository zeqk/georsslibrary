using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace GeoRSSLibrary
{
    public class GeoRssItem : IGeoRssItem
    {
        #region Fields
        protected string _id;

        protected DateTime _pubDate;

        protected string _title;

        protected string _subTitle;

        protected string _description;

        protected string _author;

        protected string _link;

        #endregion

        #region Constructors
        
        /// <summary>
        /// Default constructor
        /// </summary>
        public GeoRssItem() { }

        public GeoRssItem(string id, DateTime pubDate, string title, string subTitle, 
            string description, string author, string link)
        {
            this._id = id;
            this._pubDate = pubDate;
            this._title = title;
            this._subTitle = subTitle;
            this._description = description;
            this._author = author;
            this._link = link;
        }

        public GeoRssItem(XmlNode itemNode)
        {
            XmlNode selected;

            selected = itemNode.SelectSingleNode("guid");
            if (selected != null)
                this._id = selected.InnerText;

            selected = itemNode.SelectSingleNode("pubDate");
            if (selected != null)
            {
                DateTime pubDate = DateTime.Parse(selected.InnerText);
                this._pubDate = pubDate;
            }

            selected = itemNode.SelectSingleNode("title");
            if (selected != null)
                this._title = selected.InnerText;

            selected = itemNode.SelectSingleNode("subtitle");
            if (selected != null)
                this._subTitle = selected.InnerText;

            selected = itemNode.SelectSingleNode("description");
            if (selected != null)
                this._description = selected.InnerText;

            selected = itemNode.SelectSingleNode("author");
            if (selected != null)
                this._author = selected.InnerText;

            selected = itemNode.SelectSingleNode("link");
            if (selected != null)
                this._link = selected.InnerText;

            selected = itemNode.SelectSingleNode("link");
            if (selected != null)
                this._link = selected.InnerText;
        }


        #endregion

        #region Properties
        public string Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }


        public DateTime PubDate 
        {
            get
            {
                return this._pubDate;
            }
            set
            {
                this._pubDate = value;
            }
        }

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

        public string SubTitle
        {
            get
            {
                return this._subTitle;
            }
            set
            {
                this._subTitle = value;
            }
        }

        public string Description
        {
            get
            {
                return this._description;
            }
            set
            {
                this._description = value;
            }
        }

        public string Author
        {
            get
            {
                return this._author;
            }
            set
            {
                this._author = value;
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

        #endregion

    }
}
