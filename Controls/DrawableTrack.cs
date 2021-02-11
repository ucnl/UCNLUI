using System;
using System.Collections.Generic;
using System.Drawing;
using UCNLNav;

namespace UCNLUI.Controls
{
    public enum TrackPointType
    {
        Dot,
        Rectangle,
        Triangle,
    }

    public class DrawableTrack
    {
        #region Properties

        public bool Visible = true;

        Pen trkPen;
        float trkMarkerPointSize;

        Pen crsPen;
        float crsLineLength;

        public bool IsLastPointEnlarged;

        TrackPointType trkPointType;

        FixedSizeLIFO<PointF> trkLIFO;
        PointF centroid;
        PointF lonRange;
        PointF latRange;

        public PointF Centroid
        {
            get { return new PointF(centroid.X, centroid.Y); }
        }

        public PointF LatRange
        {
            get { return new PointF(latRange.X, latRange.Y); }
        }

        public PointF LonRange
        {
            get { return new PointF(lonRange.X, lonRange.Y); }
        }

        public int Count
        {
            get { return trkLIFO.Count; }
        }

        float course;

        public int TrackLIFOSize
        {
            get { return trkLIFO.Size; }
        }

        #endregion

        #region Constructor

        public DrawableTrack(int lifoSize, TrackPointType trackPointType, Pen trackMarkerPen, float trackMarkerPointSize, bool isLastPointEnlarged, Pen coursePen, float courseLineLength)
        {
            trkLIFO = new FixedSizeLIFO<PointF>(lifoSize);

            if (trackPointType != TrackPointType.Rectangle)
                throw new NotImplementedException("TrackPointType.Rectangle supported only so far");

            trkPointType = trackPointType;
            trkPen = trackMarkerPen;
            trkMarkerPointSize = trackMarkerPointSize;
            IsLastPointEnlarged = isLastPointEnlarged;

            crsPen = coursePen;
            crsLineLength = courseLineLength;

            Reset();
        }

        #endregion

        #region Methods

        #region Private

        private void Reset()
        {
            trkLIFO.Clear();
            centroid = new PointF(float.NaN, float.NaN);
            latRange = new PointF(float.NaN, float.NaN);
            lonRange = new PointF(float.NaN, float.NaN);
            course = float.NaN;
        }

        private void UpdateStatistics()
        {
            var trkDump = trkLIFO.ToArray();

            if ((trkDump == null) || (trkDump.Length <= 0))
                return;

            float latSum = 0.0f, lonSum = 0.0f;
            float minLat = float.MaxValue, maxLat = float.MinValue;
            float minLon = float.MaxValue, maxLon = float.MinValue;

            for (int i = 0; i < trkDump.Length; i++)
            {
                lonSum += trkDump[i].X; latSum += trkDump[i].Y;

                if (trkDump[i].X < minLon)
                    minLon = trkDump[i].X;

                if (trkDump[i].X > maxLon)
                    maxLon = trkDump[i].X;

                if (trkDump[i].Y < minLat)
                    minLat = trkDump[i].Y;

                if (trkDump[i].Y > maxLat)
                    maxLat = trkDump[i].Y;
            }

            centroid.X = lonSum / trkDump.Length;
            centroid.Y = latSum / trkDump.Length;

            latRange.X = minLat;
            latRange.Y = maxLat;

            lonRange.X = minLon;
            lonRange.Y = maxLon;            
        }

        public static List<PointF> ToLCS(IEnumerable<PointF> points, PointF centroid)
        {
            List<PointF> result = new List<PointF>();

            double cLat = Algorithms.Deg2Rad(centroid.Y);
            double cLon = Algorithms.Deg2Rad(centroid.X);
            double d_lat_m, d_lon_m;

            foreach (var point in points)
            {
                Algorithms.GetDeltasByGeopoints(cLat, cLon,
                    Algorithms.Deg2Rad(point.Y), Algorithms.Deg2Rad(point.X),
                    Algorithms.WGS84Ellipsoid,
                    out d_lat_m, out d_lon_m);

                result.Add(new PointF(Convert.ToSingle(d_lon_m), Convert.ToSingle(d_lat_m)));
            }

            return result;
        }

        #endregion

        #region Public

        public void Clear()
        {
            Reset();
        }

        public void AddPoint(IEnumerable<PointF> points)
        {
            foreach (var point in points)
            {
                trkLIFO.Add(point);
            }
            UpdateStatistics();
        }

        public void AddPoint(double lat_deg, double lon_deg)
        {
            trkLIFO.Add(new PointF(Convert.ToSingle(lon_deg), Convert.ToSingle(lat_deg)));
            UpdateStatistics();
        }

        public void AddPoint(double lat_deg, double lon_deg, double course_deg)
        {
            course = Convert.ToSingle(Algorithms.Deg2Rad(course_deg - 90.0));
            trkLIFO.Add(new PointF(Convert.ToSingle(lon_deg), Convert.ToSingle(lat_deg)));
            UpdateStatistics();
        }

        public Size MeasureLegendIcon(Graphics g, string legendLine, Font font)
        {
            var lLineSize = g.MeasureString(legendLine, font);
            float pwidth = trkMarkerPointSize * 1.5f;
            float width = pwidth * 4;
            float height = pwidth * 3;
            
            width *= 2;
            width += pwidth;
            width += lLineSize.Width + pwidth;

            if (lLineSize.Height > height)
                height = lLineSize.Height;

            return new Size(Convert.ToInt32(Math.Ceiling(width)), Convert.ToInt32(Math.Ceiling(height)));
        }

        public float DrawLegend(Graphics g, string lLine, PointF lu, Font font)
        {
            float pwidth = trkMarkerPointSize * 1.5f;
            float width = pwidth * 4;
            float height = pwidth * 3;
            width *= 2;

            RectangleF r1 = new RectangleF(lu.X + pwidth * 2 - trkMarkerPointSize,
                                           lu.Y + height / 2 - trkMarkerPointSize,
                                           trkMarkerPointSize * 2,
                                           trkMarkerPointSize * 2);

            RectangleF r2;
            if (IsLastPointEnlarged)
            {
                r2 = new RectangleF(lu.X + width - pwidth - trkMarkerPointSize * 2,
                                    lu.Y + height / 2 - trkMarkerPointSize * 2,
                                    trkMarkerPointSize * 4,
                                    trkMarkerPointSize * 4);
            }
            else
            {
                r2 = new RectangleF(lu.X + width - pwidth - trkMarkerPointSize,
                                    lu.Y + height / 2 - trkMarkerPointSize,
                                    trkMarkerPointSize * 2,
                                    trkMarkerPointSize * 2);
            }

            g.DrawRectangle(trkPen, r1.Left, r1.Top, r1.Width, r1.Height);
            g.DrawRectangle(trkPen, r2.Left, r2.Top, r2.Width, r2.Height);
            g.FillRectangle(trkPen.Brush, r2.Left, r2.Top, r2.Width, r2.Height);

            var lSize = g.MeasureString(lLine, font);
            g.DrawString(lLine, font, trkPen.Brush, lu.X + width + pwidth, lu.Y + height / 2 - lSize.Height / 2);

            return height;
        }

        public void Draw(Graphics g, PointF gCentroid, PointF gScale)
        {
            if (trkLIFO.Count > 0)
            {
                var trkDeltas = ToLCS(trkLIFO.ToArray(), gCentroid);

                float gx, gy;

                for (int i = 0; i < trkDeltas.Count; i++)
                {
                    gx = -trkDeltas[i].X * gScale.X;
                    gy = trkDeltas[i].Y * gScale.Y;

                    if (i == 0)
                    {
                        if (IsLastPointEnlarged)
                        {
                            g.DrawRectangle(trkPen,
                                            gx - trkMarkerPointSize * 2,
                                            gy - trkMarkerPointSize * 2,
                                            trkMarkerPointSize * 4,
                                            trkMarkerPointSize * 4);

                            g.FillRectangle(trkPen.Brush,
                                            gx - trkMarkerPointSize * 2,
                                            gy - trkMarkerPointSize * 2,
                                            trkMarkerPointSize * 4,
                                            trkMarkerPointSize * 4);
                        }
                        else
                        {
                            g.DrawRectangle(trkPen,
                                            gx - trkMarkerPointSize,
                                            gy - trkMarkerPointSize,
                                            trkMarkerPointSize * 2,
                                            trkMarkerPointSize * 2);
                        }

                        if (!float.IsNaN(course))
                        {

                            float crsEndPointX = gx + Convert.ToSingle(crsLineLength * Math.Cos(course));
                            float crsEndPointY = gy + Convert.ToSingle(crsLineLength * Math.Sin(course));
                            g.DrawLine(crsPen, gx, gy, crsEndPointX, crsEndPointY);
                        }
                    }
                    else
                    {
                        g.DrawRectangle(trkPen,
                                        gx - trkMarkerPointSize,
                                        gy - trkMarkerPointSize,
                                        trkMarkerPointSize * 2,
                                        trkMarkerPointSize * 2);
                    }
                }
            }

        }

        #endregion

        #endregion
    }
}
