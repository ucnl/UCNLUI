using System;
using System.Collections.Generic;
using System.Drawing;
using UCNLNav;

namespace UCNLUI.Controls.uPlot
{
    public class uGeoTrack
    {
        #region Properties

        public string ID { get; private set; }

        public bool Visible { get; set; }

        public double Course { get; private set; }

        public int CourseLineLengthPx { get; set; }


        Pen trackPen;

        public Color TrackColor { get => trackPen.Color; }

        public float TrackWidth { get => trackPen.Width; }

        public int PointSize { get; private set; }

        public bool IsEmpty
        {
            get => points.Count == 0;
        }

        public bool MarkCurrentPoint { get; private set; }

        
        List<GeoPoint> points;

        int maxPoints = 8;

        public int MaxPoints { get => maxPoints; private set => maxPoints = value; }

        public bool IsCourse { get => !double.IsNaN(Course); }

        #endregion

        #region Constructor

        public uGeoTrack(string trackID, int maxPoints, Color trackColor, int trackPointSize, float lineWidth, bool markCurrent)
        {
            ID = trackID;
            points = new List<GeoPoint>();
            MaxPoints = maxPoints;

            trackPen = new Pen(trackColor, lineWidth);
            PointSize = trackPointSize;
            MarkCurrentPoint = markCurrent;

            CourseLineLengthPx = 150;
        }


        #endregion

        #region Methods

        public void Clear()
        {
            points.Clear();
        }

        public void AppendPoint(double lat, double lon, double crs)
        {
            Course = crs;
            points.Add(new GeoPoint(lat, lon));

            if (points.Count > maxPoints)
                points.RemoveAt(0);
        }

        public int DrawLegend(Graphics g, Font font, Point rightTop, int placeForPoint, int spacing)
        {
            var textSize = g.MeasureString(ID, font);
            float integralHeight = textSize.Height;
            if (placeForPoint > integralHeight)
                integralHeight = placeForPoint;

            integralHeight += spacing * 2 + 1;
            float lineCenterY = rightTop.Y + integralHeight / 2;

            g.DrawRectangle(trackPen, rightTop.X - PointSize, lineCenterY - PointSize / 2, PointSize, PointSize);
            g.DrawString(ID, font, trackPen.Brush, rightTop.X - spacing * 2 - placeForPoint - textSize.Width, lineCenterY - textSize.Height / 2);

            return Convert.ToInt32(integralHeight);
        }

        public void Draw(Graphics g, GeoPoint windowCenter, double scale_mppx)
        {
            var cLat_rad = Algorithms.Deg2Rad(windowCenter.Latitude);
            var cLon_rad = Algorithms.Deg2Rad(windowCenter.Longitude);

            for (int i = 0; i < points.Count; i++)
            {
                var pLat_rad = Algorithms.Deg2Rad(points[i].Latitude);
                var pLon_rad = Algorithms.Deg2Rad(points[i].Longitude);

                Algorithms.GetDeltasByGeopoints_WGS84(cLat_rad, cLon_rad, pLat_rad, pLon_rad, out double dlat, out double dlon);

                float y = Convert.ToSingle(dlat * scale_mppx);
                float x = -Convert.ToSingle(dlon * scale_mppx);

                if (g.ClipBounds.Contains(x, y))
                {
                    g.DrawRectangle(trackPen, x - PointSize / 2, y - PointSize / 2, PointSize, PointSize);

                    if (i == points.Count - 1)
                    {
                        if (MarkCurrentPoint)
                        {
                            g.DrawLine(trackPen, x - PointSize, y, x - PointSize * 2, y);
                            g.DrawLine(trackPen, x + PointSize, y, x + PointSize * 2, y);
                            g.DrawLine(trackPen, x, y - PointSize, x, y - PointSize * 2);
                            g.DrawLine(trackPen, x, y + PointSize, x, y + PointSize * 2);
                        }

                        if (!double.IsNaN(Course))
                        {
                            double crs_rad = Algorithms.Wrap2PI(Algorithms.Deg2Rad(Course - 90));
                            float crsEx = x + Convert.ToSingle(CourseLineLengthPx * Math.Cos(crs_rad));
                            float crsEy = y + Convert.ToSingle(CourseLineLengthPx * Math.Sin(crs_rad));
                            g.DrawLine(trackPen, x, y, crsEx, crsEy);
                        }
                    }
                }
            }
        }        

        #endregion
    }
}
