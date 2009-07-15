using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoRSSLibrary.GeoRssItems
{
    public class Line : GeoRssItem
    {
        #region Fields

        private List<Coordinates> _coordinates;
	
        #endregion

        #region Constructors

        public Line(string guid, DateTime pubDate, string title, string subTitle,
            string description, string author, string link, List<Coordinates> coordinates)
            :base(guid,pubDate,title,subTitle,description,author,link)
        {
            this._coordinates = coordinates;
        }

        #endregion

        #region Properties

        public List<Coordinates> Coordinates
        {
            get { return _coordinates; }
            set { _coordinates = value; }
        }

        #endregion

    }
}
