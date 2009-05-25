using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace GeoRSSLibrary
{
    /// <summary>
    /// This class only contains two values, latitude and longitude and a many parse methods
    /// </summary>
    public class Coordinates
    {
        private double _latitude;
        private double _longitude;

        #region Constructors

        /// <summary>
        /// Default constructor. Initialize the latitude and the longitude in 0
        /// </summary>
        public Coordinates()
        {
            this._latitude = 0;
            this._longitude = 0;
        }

        /// <summary>
        /// Initialize the latitude and the longitude
        /// </summary>
        /// <param name="latitude">double for latitude</param>
        /// <param name="longitude">double for longitude</param>
        public Coordinates(double latitude, double longitude)
        {            
            this._latitude = latitude;
            this._longitude = longitude;
        }

        /// <summary>
        /// Initialize the latitude and the longitude from a array of double
        /// </summary>
        /// <param name="coordinates">double array with two values</param>
        public Coordinates(double[] coordinates)
            :this(coordinates[0],coordinates[1])
        {}

        /// <summary>
        /// Initialize the latitude and the longitude from a array of string
        /// </summary>
        /// <param name="stringCoords">string array with latitude and longitude</param>
        /// <param name="culture">string of culture</param>
        public Coordinates(string[] strCoords, string culture)
        {
            Coordinates coordinates = Parse(strCoords, culture);
            this._latitude = coordinates.Latitude;
            this._longitude = coordinates.Longitude;
        }

        /// <summary>
        /// Initialize the latitude and the longitude from a array of string. The default culture is en-US
        /// </summary>
        /// <param name="stringCoords">string array with latitude and longitude</param>
        public Coordinates(string[] strCoords)
            : this(strCoords, "en-US")
        { }

        /// <summary>
        /// Initialize the latitude and the longitude from a string
        /// </summary>
        /// <param name="stringCoords">sting of concatenated coordinates</param>
        /// <param name="culture">string of culture</param>
        public Coordinates(string strCoords, string culture)
        {
            Coordinates coordinates = Parse(strCoords, culture);
            this._latitude = coordinates.Latitude;
            this._longitude = coordinates.Longitude;
        }

        /// <summary>
        /// Initialize the latitude and the longitude from a string. The default culture is en-US
        /// </summary>
        /// <param name="stringCoords">sting of concatenated coordinates</param>
        public Coordinates(string strCoords)
            : this(strCoords, "en-US")
        { }

        #endregion

        #region Properties
        public double Latitude
        {
            get
            {
                return this._latitude;
            }
            set
            {
                this._latitude = value;
            }
        }

        public double Longitude
        {
            get
            {
                return this._longitude;
            }
            set
            {
                this._longitude = value;
            }
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            CultureInfo culture = new CultureInfo("en-US");
            return this._latitude.ToString(culture) + " " + this._longitude.ToString(culture);

        }

        public string[] ToStringArray()
        {
            string[] strArray = { this._latitude.ToString(), this._longitude.ToString() };
            return strArray;
        }

        public double[] ToArray()
        {
            double[] array = {this._latitude,this._longitude};
            return array;
        }

        public void CopyTo(ref Coordinates coordintes)
        {
            coordintes = this;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parse from a array of double to a coordinates object
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns>double array contains coordinates</returns>
        static public Coordinates Parse(double[] coordinates)
        {
            Coordinates rv = new Coordinates();
            rv.Latitude = coordinates[0];
            rv.Longitude = coordinates[1];
            return rv;
        }

        /// <summary>
        /// Parse from a array of strings to a coordinates object
        /// </summary>
        /// <param name="strArrayCoords">string array contains coordinates</param>
        /// <param name="culture">string of culture</param>
        /// <returns></returns>
        static public Coordinates Parse(string[] strArrayCoords, string culture)
        {
            CultureInfo cultureInfo = new CultureInfo(culture);
            Coordinates rv = new Coordinates();
            try
            {
                rv.Latitude = Double.Parse(strArrayCoords[0], cultureInfo);
                rv.Longitude = Double.Parse(strArrayCoords[1], cultureInfo);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rv;
        }

        /// <summary>
        /// Parse from a array of strings to a coordinates object. The default culture is en-US
        /// </summary>
        /// <param name="strArrayCoords">string array contains coordinates</param>
        /// <returns></returns>
        static public Coordinates Parse(string[] strArrayCoords)
        {
            return Parse(strArrayCoords, "en-US");
        }

        /// <summary>
        /// Parse a string to coordinates object
        /// </summary>
        /// <param name="strCoords">string of concatenated coordinates</param>
        /// <param name="culture">string of culture</param>
        /// <returns></returns>
        static public Coordinates Parse(string strCoords, string culture)
        {
            strCoords = strCoords.TrimStart(' ');
            strCoords = strCoords.TrimEnd(' ');
            string[] strArrayCoords = strCoords.Split(' ');
            return Parse(strArrayCoords, culture);
        }

        /// <summary>
        /// Parse a string to coordinates object. The default culture is en-US
        /// </summary>
        /// <param name="strCoords">string of concatenated coordinates</param>
        /// <returns></returns>
        static public Coordinates Parse(string strCoords)
        {
            return Parse(strCoords, "en-US");
        }

        #endregion
    }
}
