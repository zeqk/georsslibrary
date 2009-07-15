using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace GeoRSSLibrary.GeoRssItems
{
    public class GeoRssItem : IGeoRssItem
    {
        #region Fields
        protected string _guid;

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

        public GeoRssItem(string guid, DateTime pubDate, string title, string subTitle,
            string description, string author, string link)
        {
            this._guid = guid;
            this._pubDate = pubDate;
            this._title = title;
            this._subTitle = subTitle;
            this._description = description;
            this._author = author;
            this._link = link;
        }

        


        #endregion

        #region Properties
        public string Guid
        {
            get
            {
                return this._guid;
            }
            set
            {
                this._guid = value;
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


        #region Static Methods
        static public IGeoRssItem GetGeoRssItem(XmlNode itemNode)
        {
            XmlNode selected;

            IGeoRssItem geoRssItem = null;

            string guid = "";
            DateTime pubDate = new DateTime();
            string title = "";
            string subTitle = "";
            string description = "";
            string author = "";
            string link = "";

            selected = itemNode.SelectSingleNode("guid");
            if (selected != null)
                guid = selected.InnerText;

            selected = itemNode.SelectSingleNode("pubDate");
            if (selected != null)
                pubDate = DateTime.Parse(selected.InnerText);

            selected = itemNode.SelectSingleNode("title");
            if (selected != null)
                title = selected.InnerText;

            selected = itemNode.SelectSingleNode("subtitle");
            if (selected != null)
                subTitle = selected.InnerText;

            selected = itemNode.SelectSingleNode("description");
            if (selected != null)
                description = selected.InnerText;

            selected = itemNode.SelectSingleNode("author");
            if (selected != null)
                author = selected.InnerText;

            selected = itemNode.SelectSingleNode("link");
            if (selected != null)
                link = selected.InnerText;


            XmlNamespaceManager xmlNSManager = new XmlNamespaceManager(new System.Xml.NameTable());
            xmlNSManager.AddNamespace("georss", "http://www.georss.org/georss");
            xmlNSManager.AddNamespace("gml", "http://www.opengis.net/gml");

            selected = itemNode.SelectSingleNode("georss:point", xmlNSManager);
            if (selected != null)
            {
                string strCoords = selected.InnerText;
                strCoords = strCoords.TrimStart('\n', ' ');
                strCoords = strCoords.TrimEnd('\n', ' ');
                Coordinates coordinates = new Coordinates(strCoords);
                geoRssItem = new Point(guid, pubDate, title, subTitle, description, author, link, coordinates);

            }
            else
                selected = itemNode.SelectSingleNode("gml:LineString/gml:posList", xmlNSManager);

            if (geoRssItem == null && selected != null)
            {
                string strCoords = selected.InnerText;
                strCoords = strCoords.TrimStart('\n', ' ');
                strCoords = strCoords.TrimEnd('\n', ' ');
                string[] arrayStrCoords = strCoords.Split('\n');
                List<Coordinates> coordinates = new List<Coordinates>();
                for (int i = 0; i < arrayStrCoords.Count<string>(); i++)
                {
                    coordinates.Add(new Coordinates(arrayStrCoords[i]));
                }

                geoRssItem = new Line(guid, pubDate, title, subTitle, description, author, link, coordinates);
            }
            else
                selected = itemNode.SelectSingleNode("gml:Polygon/gml:exterior/gml:LinearRing/gml:posList", xmlNSManager);

            if (geoRssItem == null && selected != null)
            {
                string strCoords = selected.InnerText;
                strCoords = strCoords.TrimStart('\n', ' ');
                strCoords = strCoords.TrimEnd('\n', ' ');
                string[] arrayStrCoords = strCoords.Split('\n');
                List<Coordinates> coordinates = new List<Coordinates>();
                for (int i = 0; i < arrayStrCoords.Count<string>(); i++)
                {
                    coordinates.Add(new Coordinates(arrayStrCoords[i]));
                }

                geoRssItem = new Polygon(guid, pubDate, title, subTitle, description, author, link, coordinates);
            }
            else
                selected = itemNode.SelectSingleNode("gml:Envelope", xmlNSManager);

            if (geoRssItem == null && selected != null)
            {
                XmlNode auxNode = selected;
                XmlNode xmlLowerCorner = selected.SelectSingleNode("gml:lowerCorner", xmlNSManager);
                XmlNode xmlUpperCorner = auxNode.SelectSingleNode("gml:upperCorner", xmlNSManager);

                if (xmlLowerCorner != null && xmlUpperCorner != null)
                {
                    string strLowerCorner = xmlLowerCorner.InnerText;
                    strLowerCorner = strLowerCorner.TrimStart('\n', ' ');
                    strLowerCorner = strLowerCorner.TrimEnd('\n', ' ');
                    Coordinates lowerCorner = new Coordinates(strLowerCorner);

                    string strUpperCorner = xmlUpperCorner.InnerText;
                    strUpperCorner = strUpperCorner.TrimStart('\n', ' ');
                    strUpperCorner = strUpperCorner.TrimEnd('\n', ' ');
                    Coordinates upperCorner = new Coordinates(strUpperCorner);

                    geoRssItem = new Box(guid, pubDate, title, subTitle, description, author, link, lowerCorner, upperCorner);

                }

            }

            return geoRssItem;

        }
        #endregion

    }
}

