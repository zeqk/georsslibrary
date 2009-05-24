using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace GeoRSSLibrary
{
    class Point : GeoRssItem
    {
        private Coordinates _coordinates;


        #region Contructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Point()
        {
            
        }

        /// <summary>
        /// Initialize all values
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pubDate"></param>
        /// <param name="title"></param>
        /// <param name="subTitle"></param>
        /// <param name="description"></param>
        /// <param name="author"></param>
        /// <param name="link"></param>
        /// <param name="coordinates"></param>
        public Point(string id, DateTime pubDate, string title, string subTitle,
            string description, string author, string link, Coordinates coordinates)
            : base(id, pubDate, title, subTitle, description, author, link)
        {
            this._coordinates = coordinates;
        }

        /// <summary>
        /// Intialize from a xml node from a GeoRSS file
        /// </summary>
        /// <param name="itemNode">XmlNode item</param>
        public Point(XmlNode itemNode):base(itemNode)
        {
            XmlNode selected;
            XmlNamespaceManager xmlNSManager = new XmlNamespaceManager(new System.Xml.NameTable());
            xmlNSManager.AddNamespace("georss", "http://www.georss.org/georss");
            selected = itemNode.SelectSingleNode("georss:point", xmlNSManager);
            if (selected != null)
            {
                string strCoords = selected.InnerText;
                this._coordinates = new Coordinates(strCoords);
            }

        }


        #endregion

        public Coordinates Coordinates
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


    }
}
