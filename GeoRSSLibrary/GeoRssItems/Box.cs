using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoRSSLibrary.GeoRssItems
{
    public class Box : GeoRssItem
    {
        #region Fields

        private Coordinates _lowerCorner;

        private Coordinates _upperCorner;
	
        #endregion

        #region Contructors

        public Box(string guid, DateTime pubDate, string title, string subTitle,
            string description, string author, string link, Coordinates lowerCorner,Coordinates upperCorner)
            :base(guid,pubDate,title,subTitle,description,author,link)
        {
            this._lowerCorner = lowerCorner;
            this._upperCorner = upperCorner;
        }
        #endregion



        #region Properties

        public Coordinates LowerCorner
        {
            get { return _lowerCorner; }
            set { _lowerCorner = value; }
        }

        public Coordinates UpperCorner
        {
            get { return _upperCorner; }
            set { _upperCorner = value; }
        }

        #endregion

    }
}
