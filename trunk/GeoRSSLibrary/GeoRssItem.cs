using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace GeoRSSLibrary
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

        protected GeoRssItemType _type;

        protected List<Coordinates> _coordinates;

        #endregion

        #region Constructors
        
        /// <summary>
        /// Default constructor
        /// </summary>
        public GeoRssItem() { }

        public GeoRssItem(string guid, DateTime pubDate, string title, string subTitle,
            string description, string author, string link, GeoRssItemType type, List<Coordinates> coordinates)
        {
            this._guid = guid;
            this._pubDate = pubDate;
            this._title = title;
            this._subTitle = subTitle;
            this._description = description;
            this._author = author;
            this._link = link;
            this._type = type;
            this._coordinates = coordinates;
        }

        public GeoRssItem(XmlNode itemNode)
        {
            XmlNode selected;

            selected = itemNode.SelectSingleNode("guid");
            if (selected != null)
                this._guid = selected.InnerText;

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

            this._coordinates = new List<Coordinates>();
            XmlNamespaceManager xmlNSManager = new XmlNamespaceManager(new System.Xml.NameTable());
            xmlNSManager.AddNamespace("georss", "http://www.georss.org/georss");
            xmlNSManager.AddNamespace("gml", "http://www.opengis.net/gml");

            selected = itemNode.SelectSingleNode("georss:point", xmlNSManager);
            this._type = GeoRssItemType.Point;

            if (selected == null)
            {
                selected = itemNode.SelectSingleNode("gml:LineString/gml:posList", xmlNSManager);
                this._type = GeoRssItemType.Line;
            }

            if (selected == null)
            {
                selected = itemNode.SelectSingleNode("gml:Polygon/gml:exterior/gml:LinearRing/gml:posList", xmlNSManager);
                this._type = GeoRssItemType.Polygon;
            }

            string strCoords = selected.InnerText;
            strCoords = strCoords.TrimStart('\n', ' ');
            strCoords = strCoords.TrimEnd('\n', ' ');
            string[] arrayStrCoords = strCoords.Split('\n');
            for (int i = 0; i < arrayStrCoords.Count<string>(); i++)
            {
                this._coordinates.Add(new Coordinates(arrayStrCoords[i]));
            }


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

        public GeoRssItemType Type
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type = value;
            }
        }

        public List<Coordinates> Coordinates
        {
            get
            {
                return this._coordinates;
            }
            set
            {
                this._coordinates = value;
            }
        }

        public Coordinates FirstCoordinates
        {
            get
            {
                return this._coordinates.First();
            }
        }

        #endregion

        static public GeoRssItemType GetItemType(XmlNode itemNode)
        {
            GeoRssItemType type = GeoRssItemType.Point;
            XmlNode selected;
            XmlNamespaceManager xmlNSManager = new XmlNamespaceManager(new System.Xml.NameTable());
            xmlNSManager.AddNamespace("georss", "http://www.georss.org/georss");
            selected = itemNode.SelectSingleNode("georss:point", xmlNSManager);
            if (selected != null)
                type = GeoRssItemType.Point;

            selected = itemNode.SelectSingleNode("georss:line", xmlNSManager);
            if (selected != null)
                type = GeoRssItemType.Line;
            
            selected = itemNode.SelectSingleNode("georss:polygon", xmlNSManager);
            if (selected != null)
                type = GeoRssItemType.Polygon;

            return GeoRssItemType.Point ;
        }

    }
}
