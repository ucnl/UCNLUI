using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UCNLNav;

namespace UCNLUI.Controls.uPlot
{
    public class uGeoTracks
    {
        #region Properties

        Dictionary<string, uGeoTrack> tracks = new Dictionary<string, uGeoTrack>();
        public int LegendHeightSpacing { get; private set; }

        int synLock = 0;

        #endregion

        #region Constructor

        public uGeoTracks(int legendHeghtSpacing)
        {
            tracks = new Dictionary<string, uGeoTrack>();

            LegendHeightSpacing = legendHeghtSpacing;
        }

        #endregion

        #region Methods

        public void SetTracksVisibility(bool visible)
        {
            foreach (var track in tracks.Values)
                track.Visible = visible;
        }

        public void SetTrackVisibility(string trackID, bool visible)
        {
            if (tracks.ContainsKey(trackID))
                tracks[trackID].Visible = visible;
        }

        public void AddTrack(string trackID, int maxPoints, Color trackColor, int trackPointSize, float lineWidth, bool markCurrent)
        {
            if (tracks.ContainsKey(trackID))
                throw new ArgumentException(nameof(trackID));

            tracks.Add(trackID, new uGeoTrack(trackID, maxPoints, trackColor, trackPointSize, lineWidth, markCurrent));
            tracks[trackID].Visible = true;
        }

        public void AddPoint(string trackID, double lat, double lon, double course)
        {
            while (Interlocked.CompareExchange(ref synLock, 1, 0) != 0)
                Thread.SpinWait(1);

            if (!tracks.ContainsKey(trackID))
                throw new ArgumentException(nameof(trackID));

            tracks[trackID].AppendPoint(lat, lon, course);

            Interlocked.Decrement(ref synLock);
        }

        public void ClearPoints()
        {
            while (Interlocked.CompareExchange(ref synLock, 1, 0) != 0)
                Thread.SpinWait(1);

            foreach (var track in tracks)
                track.Value.Clear();

            Interlocked.Decrement(ref synLock);
        }

        public void Clear()
        {
            while (Interlocked.CompareExchange(ref synLock, 1, 0) != 0)
                Thread.SpinWait(1);

            tracks.Clear();

            Interlocked.Decrement(ref synLock);
        }

        public void DrawLegends(Graphics g, Font legendFont, Point rightTop)
        {
            while (Interlocked.CompareExchange(ref synLock, 1, 0) != 0)
                Thread.SpinWait(1);

            int maxPointSize = 0;

            foreach (var track in tracks.Values)
            {
                if ((track.Visible) && (track.PointSize > maxPointSize))
                    maxPointSize = track.PointSize;
            }

            Point rtPoint = rightTop;

            foreach (var track in tracks.Values)
            {
                if (track.Visible)
                    rtPoint.Y += track.DrawLegend(g, legendFont, rtPoint, maxPointSize, LegendHeightSpacing);
            }

            Interlocked.Decrement(ref synLock);
        }

        public void DrawTracks(Graphics g, GeoPoint windowCenter, double scale_mppx)
        {
            while (Interlocked.CompareExchange(ref synLock, 1, 0) != 0)
                Thread.SpinWait(1);

            foreach (var track in tracks.Values)
            {
                if (track.Visible && !track.IsEmpty)
                    track.Draw(g, windowCenter, scale_mppx);
            }

            Interlocked.Decrement(ref synLock);
        }

        #endregion

    }
}
