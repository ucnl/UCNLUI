using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using UCNLDrivers;
using UCNLKML;
using UCNLNav;

namespace UCNLUI
{
    public class TrackManager
    {
        #region Properties

        public string Descrption { get; set; }

        Dictionary<string, List<GeoPoint3DTm>> tracks;

        public bool IsEmpty
        {
            get { return tracks.Count == 0; }
        }

        bool changed = false;
        public bool Changed
        {
            get => changed;
            set
            {
                if (value != changed)
                {
                    changed = value;
                    ChangedChanged.Rise(this, EventArgs.Empty);
                }
            }
        }

        #endregion

        #region Constructor

        public TrackManager() : this("www.docs.unavlab.com")
        {
        }

        public TrackManager(string generator_Description)
        {
            Descrption = generator_Description;
            tracks = new Dictionary<string, List<GeoPoint3DTm>>();            
        }

        #endregion

        #region Methods

        public void Clear()
        {
            tracks.Clear();
            IsEmptyChanged.Rise(this, new EventArgs());            
        }

        public void AddPoint(string trackID, double lat, double lon, double dpt, DateTime timeStamp)
        {
            bool prevIsEmpty = IsEmpty;

            if (!tracks.ContainsKey(trackID))
                tracks.Add(trackID, new List<GeoPoint3DTm>());

            tracks[trackID].Add(new GeoPoint3DTm(lat, lon, dpt, timeStamp));

            if (prevIsEmpty != IsEmpty)
                IsEmptyChanged.Rise(this, EventArgs.Empty);

            Changed = true;
        }

        public void ExportToKML(string fileName)
        {
            KMLData data = new KMLData(fileName, Descrption);
            List<KMLLocation> kmlTrack;

            foreach (var item in tracks)
            {
                kmlTrack = new List<KMLLocation>();
                foreach (var point in item.Value)
                    kmlTrack.Add(new KMLLocation(point.Longitude, point.Latitude, -point.Depth));

                data.Add(new KMLPlacemark(string.Format("{0} track", item.Key), "", kmlTrack.ToArray()));
            }

            TinyKML.Write(data, fileName);
            Changed = false;
        }

        public void ExportToCSV(string fileName)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var track in tracks)
            {
                sb.AppendFormat("#{0}\r\n", Descrption);
                sb.AppendFormat("#\r\nTrack name: {0}\r\n", track.Key);
                sb.Append("HH:MM:SS;LAT;LON;DPT;\r\n");

                foreach (var point in track.Value)
                {
                    sb.AppendFormat(CultureInfo.InvariantCulture,
                        "{0:00};{1:00};{2:00};{3:F06};{4:F06};{5:F03}\r\n",
                        point.TimeStamp.Hour,
                        point.TimeStamp.Minute,
                        point.TimeStamp.Second,
                        point.Latitude,
                        point.Longitude,
                        point.Depth);
                }
            }

            File.WriteAllText(fileName, sb.ToString());
            Changed = false;
        }

        public void ImportFromKML(string fileName)
        {
            KMLData data = TinyKML.Read(fileName);

            foreach (var placemark in data)
            {
                foreach (var kmllocation in placemark.PlacemarkItem)
                {
                    AddPoint(placemark.Name, kmllocation.Latitude, kmllocation.Longitude, kmllocation.Altitude, DateTime.Now);
                }
            }            

            Changed = true;
        }

        public bool IsTrackPresent(string trackID)
        {
            return tracks.ContainsKey(trackID);
        }

        public List<GeoPoint> GetTrack2D(string trackID)
        {
            List<GeoPoint> result = new List<GeoPoint>();

            if (tracks.ContainsKey(trackID))
            {
                foreach (var item in tracks[trackID])
                {
                    result.Add(new GeoPoint(item.Latitude, item.Longitude));
                }
            }

            return result;
        }

        #endregion

        #region Events

        public EventHandler IsEmptyChanged;
        public EventHandler ChangedChanged;

        #endregion
    }
}
