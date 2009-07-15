using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoRSSLibrary.GeoRssItems
{
    public class Point : GeoRssItem
    {
        #region Fields

        private Coordinates _coordinates;        
	
        #endregion

        #region Contructors

        public Point(string guid, DateTime pubDate, string title, string subTitle,
            string description, string author, string link, Coordinates coordinates)
            :base(guid,pubDate,title,subTitle,description,author,link)
        {
            this._coordinates = coordinates;
        }
        #endregion



        #region Properties

        public Coordinates Coordinates
        {
            get { return _coordinates; }
            set { _coordinates = value; }
        }

        #endregion
    }
}
