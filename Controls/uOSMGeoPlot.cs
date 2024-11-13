using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using UCNLNav;
using uOSM;

namespace UCNLUI.Controls
{
    public partial class uOSMGeoPlot : UserControl
    {
        #region Properties

        Dictionary<string, DrawableTrack> tracks;

        FixedSizeLIFO<string> history;
        string[] historyLines;

        uOSMTileProvider tProvider;
        public bool IsTileProviderConnected
        {
            get { return tProvider != null; }
        }

        int t_zoom = -1;
        int t_lu_x = -1, t_lu_y = -1, t_rb_x = -1, t_rb_y = -1;
        Image substrate;

        PointF gLatRanges = new PointF(float.NaN, float.NaN);
        PointF gLonRanges = new PointF(float.NaN, float.NaN);
        PointF gCentroid = new PointF(float.NaN, float.NaN);
        PointF gScale = new PointF(float.NaN, float.NaN);        
        PointF sCenter = new PointF(float.NaN, float.NaN);

        double gTileMpx = double.NaN;
        double gTileWidthM = double.NaN;

        int drawTracksNum = 0;

        Pen tileBorderPen;

        public bool TileBordersVisible = true;

        public Font LegendFont { get; set; }

        public Font LeftUpperTextFont { get; set; }

        Brush leftUpperTextBrush = new SolidBrush(Color.Black);
        Color leftUpperTextColor = Color.Black;
        public Color LeftUpperTextColor
        {
            get { return leftUpperTextColor; }
            set
            {
                leftUpperTextColor = value;
                leftUpperTextBrush = new SolidBrush(leftUpperTextColor);
            }
        }

        public string LeftUpperText { get; set; }

        public bool HistoryVisible { get; set; }
        public Font HistoryTextFont { get; set; }
        public Color HistoryTextColor { get; set; }

        public bool LegendVisible { get; set; }
        public bool LeftUpperTextVisible { get; set; }

        public int historyLinesNumber = 4;
        public int HistoryLinesNumber 
        { 
            get { return historyLinesNumber; }
            set
            {
                if ((value > 0) && (value < 16))
                {
                    historyLinesNumber = value;
                    history = new FixedSizeLIFO<string>(historyLinesNumber);
                }
            }
        }

        int maxHistoryLineLength = 127;
        public int MaxHistoryLineLength
        {
            get { return maxHistoryLineLength; }
            set
            {
                if ((value > 0) && (value < 256))
                    maxHistoryLineLength = value;
            }
        }

        int scaleTickSize = 20;
        Pen scaleSubLinePen;
        Pen scaleLinePen;
        float scalePenWidth = 2.0f;
        float scaleSubPenWidth = 4.0f;

        public Font ScaleLineFont { get; set; }

        public Color ScaleLineColor { get; set; }

        Brush scaleLineBrush;

        bool isStPoint = false;
        bool isNdPoint = false;
        Point stPoint;
        Point ndPoint;
        Point msPoint;

        public Color MeasurementLineColor { get; set; }
        
        public Font MeasurementTextFont { get; set; }
        Brush measurementTextBrush = new SolidBrush(Color.Black);
        Color measurementTextColor = Color.Black;
        public Color MeasurementTextColor
        {
            get { return measurementTextColor; }
            set
            {
                measurementTextColor = value;
                measurementTextBrush = new SolidBrush(measurementTextColor);
            }
        }

        Brush measurementTextBgBrush = new SolidBrush(Color.FromArgb(190, Color.White));
        Color measurementTextBgdColor = Color.FromArgb(190, Color.White);
        public Color MeasurementTextBgColor
        {
            get { return measurementTextBgdColor; }
            set
            {
                measurementTextBgBrush = new SolidBrush(MeasurementTextBgColor);
            }
        }
            
        float mSubLineWidth = 3.0f;
        float mLineWidth = 1.0f;
        Pen mSubLinePen;
        Pen mLinePen;
        float mCrossSize = 8;

        public readonly int DefaultPointsToShow = 64;
        public readonly Color DefaultMarkerColor = Color.Blue;
        public readonly float DefaultMarkerPenWidth = 1.0f;
        public readonly int DefaultMarkerSize = 4;
        public readonly bool DefaultIsLastPointEnlarged = true;
        public readonly Color DefaultCourseLineColor = Color.Blue;
        public readonly float DefaultCourseLineWidth = 1.0f;
        public readonly int DefaultCourseLineLength = 200;

        public static readonly int DefaultTileWidth = 256;
        public static readonly int DefaultTileHeight = 256;

        public static readonly int DefaultMaxZoom = 19;

        int maxZoom = DefaultMaxZoom;

        int tileWidth = DefaultTileWidth;
        int tileHeight = DefaultTileHeight;

        Color textBackgoundColor = Color.Empty;
        public Color TextBackgroundColor
        {
            get { return textBackgoundColor; }
            set
            {
                textBackgoundColor = value;
                textBackgroundBrush = new SolidBrush(textBackgoundColor);
            }
        }

        Brush textBackgroundBrush;


        #region Right-upper corner text

        public bool RightUpperTextVisible { get; set; }

        AgingValue<string> rightUpperText;

        public void RightUpperTextSet(string text)
        {
            rightUpperText.Value = text;
        }


        public Font RightUpperTextFont { get; set; }

        Brush rightUpperTextBrush = new SolidBrush(Color.Black);
        Color rightUpperTextColor = Color.Black;

        public Color RightUpperTextColor
        {
            get { return rightUpperTextColor; }
            set
            {
                rightUpperTextColor = value;
                rightUpperTextBrush = new SolidBrush(rightUpperTextColor);
            }
        }

        #endregion

        #region Right upper Text custom background

        Color rightUpperTextBkColor = Color.Black;
        public Color RightUpperTextBackgoundColor
        {
            get { return rightUpperTextBkColor; }
            set
            {
                rightUpperTextBkColor = value;
                rightUpperTextBkBrush = new SolidBrush(rightUpperTextBkColor);
            }
        }

        Brush rightUpperTextBkBrush = new SolidBrush(Color.Black);

        #endregion

        #endregion

        #region Constructor

        public uOSMGeoPlot()
        {
            InitializeComponent();

            rightUpperText = new AgingValue<string>(3, 255, x => x);

            tracks = new Dictionary<string, DrawableTrack>();

            tileBorderPen = new Pen(Color.DarkGray, 1.0f);
            tileBorderPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            if (LegendFont == null)
                LegendFont = this.Font;

            if (LeftUpperTextFont == null)
                LeftUpperTextFont = this.Font;

            if (RightUpperTextFont == null)
                RightUpperTextFont = this.Font;

            if (ScaleLineFont == null)
                ScaleLineFont = this.Font;

            if (ScaleLineColor == Color.Empty)
                ScaleLineColor = this.ForeColor;

            scaleLineBrush = new SolidBrush(ScaleLineColor);

            scaleLinePen = new Pen(Color.Black, scalePenWidth);
            scaleSubLinePen = new Pen(Color.White, scaleSubPenWidth);

            history = new FixedSizeLIFO<string>(historyLinesNumber);

            if (MeasurementLineColor == Color.Empty)
                MeasurementLineColor = Color.Black;

            if (MeasurementTextFont == null)
                MeasurementTextFont = this.Font;

            if (MeasurementTextColor == Color.Empty)
                MeasurementTextColor = Color.Black;

            mSubLinePen = new Pen(Color.White, mSubLineWidth);
            mLinePen = new Pen(MeasurementLineColor, mLineWidth);

            if (TextBackgroundColor != Color.Empty)
                textBackgroundBrush = new SolidBrush(TextBackgroundColor);
        }

        #endregion        

        #region Methods

        #region Private

        private void UpdateTracksStatistics()
        {
            PointF ltRanges = new PointF(float.MaxValue, float.MinValue);
            PointF lnRanges = new PointF(float.MaxValue, float.MinValue);
            PointF centroid = new PointF(0, 0);
            int numTracksToDraw = 0;
            foreach (var track in tracks)
            {
                if ((track.Value.Visible) && (track.Value.Count > 0))
                {
                    centroid.X += track.Value.Centroid.X;
                    centroid.Y += track.Value.Centroid.Y;

                    if (track.Value.LatRange.X < ltRanges.X)
                        ltRanges.X = track.Value.LatRange.X;

                    if (track.Value.LatRange.Y > ltRanges.Y)
                        ltRanges.Y = track.Value.LatRange.Y;

                    if (track.Value.LonRange.X < lnRanges.X)
                        lnRanges.X = track.Value.LonRange.X;

                    if (track.Value.LonRange.Y > lnRanges.Y)
                        lnRanges.Y = track.Value.LonRange.Y;

                    numTracksToDraw++;
                }
            }

            if (numTracksToDraw > 0)
            {
                centroid.X /= numTracksToDraw;
                centroid.Y /= numTracksToDraw;

                drawTracksNum = numTracksToDraw;
                gCentroid = centroid;
                gLatRanges = ltRanges;
                gLonRanges = lnRanges;
            }
        }

        private async void UpdateSubstrate(int sWidth, int sHeight, int zoom, int lu_x, int rb_x, int lu_y, int rb_y)
        {
            substrate = new Bitmap(sWidth, sHeight);

            if (tProvider == null)
            {
                using (Graphics bg = Graphics.FromImage(substrate))
                {
                    for (int x = lu_x; x <= rb_x; x++)
                    {
                        for (int y = lu_y; y <= rb_y; y++)
                        {
                            var tRect = new Rectangle((x - lu_x) * tileWidth, (y - lu_y) * tileHeight, tileWidth, tileHeight);
                            bg.DrawRectangle(tileBorderPen, tRect);
                        }
                    }
                }
            }
            else
            {
                var tiles = await tProvider.GetTilesAsync(zoom, lu_x, rb_x, lu_y, rb_y);
                using (Graphics bg = Graphics.FromImage(substrate))
                {
                    foreach (var tile in tiles)
                    {
                        var tRect = new Rectangle((tile.X - lu_x) * tile.Tile.Width, (tile.Y - lu_y) * tile.Tile.Height, tile.Tile.Width, tile.Tile.Height);
                        bg.DrawImageUnscaled(tile.Tile, tRect);

                        if (TileBordersVisible)
                            bg.DrawRectangle(tileBorderPen, tRect);
                    }
                }
                this.Invalidate();
            }
        }

        private void UpdateScale()
        {
            int lu_x = 0, lu_y = 0, rb_x = 0, rb_y = 0, zoom = 0;
            double c_lat_deg = double.NaN, c_lon_deg = double.NaN;

            if (tProvider != null)
            {
                tileWidth = tProvider.TileSize.Width;
                tileHeight = tProvider.TileSize.Height;
                maxZoom = tProvider.MaxZoom;
            }

            uOSMTileUtils.GetFitTiles(this.Width, this.Height,
                    tileWidth, tileHeight,
                    gLatRanges.X, gLonRanges.X, gLatRanges.Y, gLonRanges.Y,
                    maxZoom,
                    out c_lat_deg, out c_lon_deg,
                    out lu_x, out lu_y, out rb_x, out rb_y, out zoom);

            sCenter.X = Convert.ToSingle(c_lon_deg);
            sCenter.Y = Convert.ToSingle(c_lat_deg);

            int substrateWidth = (Math.Abs(rb_x - lu_x) + 1) * tileWidth;
            int substrateHeight = (Math.Abs(rb_y - lu_y) + 1) * tileHeight;
                

            if ((substrate == null) ||
                (zoom != t_zoom) ||
                (lu_x != t_lu_x) || (lu_y != t_lu_y) &&
                (rb_x != t_rb_x) || (rb_y != t_rb_y))
            {
                t_zoom = zoom;
                t_lu_x = lu_x;
                t_lu_y = lu_y;
                t_rb_x = rb_x;
                t_rb_y = rb_y;

                UpdateSubstrate(substrateWidth, substrateHeight, zoom, lu_x, rb_x, lu_y, rb_y);
            }
        }

        private float Dist2D(Point st, Point nd)
        {
            return Convert.ToSingle(Math.Sqrt((st.X - nd.X) * (st.X - nd.X) + (st.Y - nd.Y) * (st.Y - nd.Y)));
        }

        #endregion

        #region Public

        public void ConnectTileProvider(uOSMTileProvider provider)
        {
            tProvider = provider;
        }

        public bool IsTrackPresent(string trackName)
        {
            return tracks.ContainsKey(trackName);
        }

        public void InitTrack(string trackName, int pointsToShow, Color markerColor, float markerPenWidth, int markerSize, bool isLastPointEnlarged,
            Color courseLineColor, float courseLineWidth, int courseLineLength)
        {
            if (tracks.ContainsKey(trackName))
                throw new ArgumentException("Track with the specified name already exists");

            tracks.Add(trackName,
                new DrawableTrack(pointsToShow,
                    TrackPointType.Rectangle,
                    new Pen(markerColor, markerPenWidth), markerSize, isLastPointEnlarged,
                    new Pen(courseLineColor, courseLineWidth), courseLineLength));
        }

        public void AddPoint(string trackName, double lat_deg, double lon_deg)
        {
            if (!tracks.ContainsKey(trackName))
                tracks.Add(trackName,
                    new DrawableTrack(DefaultPointsToShow, TrackPointType.Rectangle, new Pen(DefaultMarkerColor, DefaultMarkerPenWidth),
                        DefaultMarkerSize, DefaultIsLastPointEnlarged, new Pen(DefaultCourseLineColor, DefaultCourseLineWidth), DefaultCourseLineLength));

            tracks[trackName].AddPoint(lat_deg, lon_deg);

            UpdateTracksStatistics();
        }

        public void AddPoint(string trackName, double lat_deg, double lon_deg, double course_deg)
        {
            if (!tracks.ContainsKey(trackName))
                tracks.Add(trackName,
                    new DrawableTrack(DefaultPointsToShow, TrackPointType.Rectangle, new Pen(DefaultMarkerColor, DefaultMarkerPenWidth),
                        DefaultMarkerSize, DefaultIsLastPointEnlarged, new Pen(DefaultCourseLineColor, DefaultCourseLineWidth), DefaultCourseLineLength));

            tracks[trackName].AddPoint(lat_deg, lon_deg, course_deg);

            UpdateTracksStatistics();
        }

        public void AddPoints(string trackName, IEnumerable<PointF> points)
        {
            if (!tracks.ContainsKey(trackName))
                tracks.Add(trackName,
                    new DrawableTrack(DefaultPointsToShow, TrackPointType.Rectangle, new Pen(DefaultMarkerColor, DefaultMarkerPenWidth),
                        DefaultMarkerSize, DefaultIsLastPointEnlarged, new Pen(DefaultCourseLineColor, DefaultCourseLineWidth), DefaultCourseLineLength));

            tracks[trackName].AddPoint(points);

            UpdateTracksStatistics();
        }

        public void AppendHistory(string text)
        {
            history.Add(text.Replace("\r\n", " "));
            historyLines = history.ToArray();
        }

        public void ClearTracks()
        {
            foreach (var track in tracks)
                track.Value.Clear();

            PointF gLatRanges = new PointF(float.NaN, float.NaN);
            PointF gLonRanges = new PointF(float.NaN, float.NaN);
            PointF gCentroid = new PointF(float.NaN, float.NaN);
            PointF gScale = new PointF(float.NaN, float.NaN);
            PointF sCenter = new PointF(float.NaN, float.NaN);
        }

        public void SetTrackVisibility(string trackName, bool isVisible)
        {
            if (tracks.ContainsKey(trackName))
                tracks[trackName].Visible = isVisible;
        }

        public void SetTracksVisibility(IEnumerable<string> trackNames, bool isVisible)
        {
            /*foreach (var track in tracks)
            {
                track.Value.Visible = !isVisible;
            }*/

            foreach (var trackName in trackNames)
            {
                if (tracks.ContainsKey(trackName))
                    tracks[trackName].Visible = isVisible;
            }
        }

        public void SetTracksVisibility(bool isVisible)
        {
            foreach (var track in tracks)
            {
                track.Value.Visible = isVisible;
            }
        }

        private byte Age2Alpha(double age_sec, double obs_int_sec)
        {
            double age = age_sec > obs_int_sec ? obs_int_sec : age_sec;
            int alpha = 5 + Convert.ToInt32(250.0 * (obs_int_sec - age) / obs_int_sec);
            return Convert.ToByte(alpha);
        }

        #endregion

        #endregion

        #region Handlers

        private void uOSMGeoPlot_Paint(object sender, PaintEventArgs e)
        {
            if (e.ClipRectangle.IsEmpty)
                return;

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            e.Graphics.TranslateTransform(this.Width / 2.0f, this.Height / 2.0f);

            float rd_y = this.Padding.Bottom + this.Padding.Top;

            if (drawTracksNum > 0)
            {
                #region Drawing map tiles

                UpdateScale();

                e.Graphics.DrawImage(substrate, -substrate.Width / 2, -substrate.Height / 2);
                gTileMpx = uOSMTileUtils.TileLongitudalSizeMetersPerPixel(tileWidth, gCentroid.Y, t_zoom);
                gTileWidthM = gTileMpx * tileWidth;
                gScale.X = Convert.ToSingle(1.0 / gTileMpx);
                gScale.Y = gScale.X;

                #endregion
            
                #region Draw scale

                double gScaleAligned = (this.Height / 3) / gScale.X;
                gScaleAligned = Utils.FitAxisStepByRange(gScaleAligned);
                float gScaleAlignedPx = Convert.ToSingle(gScaleAligned * gScale.X);

                while (gScaleAlignedPx > this.Height / 2)
                {
                    gScaleAlignedPx /= 2;
                    gScaleAligned /= 2;
                }

                while (gScaleAlignedPx < this.Height / 4)
                {
                    gScaleAlignedPx *= 2;
                    gScaleAligned *= 2;
                }
                

                float scale_r = this.Width / 2.0f - this.Padding.Right;
                float scale_b = this.Height / 2.0f - this.Padding.Bottom;
                float scale_t = scale_b - gScaleAlignedPx;
                float scale_m = scale_b - gScaleAlignedPx / 2.0f;

                e.Graphics.DrawLine(scaleSubLinePen, scale_r, scale_t, scale_r, scale_b);
                e.Graphics.DrawLine(scaleLinePen, scale_r, scale_t, scale_r, scale_b);
                e.Graphics.DrawLine(scaleSubLinePen, scale_r - scaleTickSize, scale_t, scale_r, scale_t);
                e.Graphics.DrawLine(scaleLinePen, scale_r - scaleTickSize, scale_t, scale_r, scale_t);
                e.Graphics.DrawLine(scaleSubLinePen, scale_r - scaleTickSize, scale_b, scale_r, scale_b);
                e.Graphics.DrawLine(scaleLinePen, scale_r - scaleTickSize, scale_b, scale_r, scale_b);

                e.Graphics.DrawLine(scaleSubLinePen, scale_r - scaleTickSize / 2, scale_m, scale_r, scale_m);
                e.Graphics.DrawLine(scaleLinePen, scale_r - scaleTickSize / 2, scale_m, scale_r, scale_m);

                var scaleLine = string.Format(CultureInfo.InvariantCulture, "{0:F01} m", gScaleAligned);
                var scaleLSize = e.Graphics.MeasureString(scaleLine, ScaleLineFont);
                e.Graphics.DrawString(scaleLine, ScaleLineFont, scaleLineBrush, scale_r - scaleLSize.Width - scaleTickSize - this.Padding.Right, scale_t - scaleLSize.Height / 2);

                #endregion

                #region Drawing tracks & legend

                float legendTotalHeight = 0;
                float legendMaxWidth = 0;
                foreach (var track in tracks)
                {
                    if (track.Value.Visible)
                    {
                        track.Value.Draw(e.Graphics, sCenter, gScale);
                        var lSize = track.Value.MeasureLegendIcon(e.Graphics, track.Key, LegendFont);
                        legendTotalHeight += lSize.Height;
                        if (lSize.Width > legendMaxWidth)
                            legendMaxWidth = lSize.Width;
                    }
                }

                if (LegendVisible)
                {
                    rd_y += legendTotalHeight + this.Padding.Bottom + this.Padding.Top;
                    legendTotalHeight += this.Padding.Bottom + this.Padding.Top;

                    PointF legend_lu = new PointF(this.Width / 2.0f - this.Padding.Left - legendMaxWidth, -this.Height / 2.0f + this.Padding.Top);

                    if (textBackgoundColor != Color.Empty)
                        e.Graphics.FillRectangle(textBackgroundBrush, legend_lu.X, legend_lu.Y, legendMaxWidth, legendTotalHeight);

                    legend_lu.Y += this.Padding.Top;
                    foreach (var track in tracks)
                    {
                        if (track.Value.Visible)
                            legend_lu.Y += track.Value.DrawLegend(e.Graphics, track.Key, legend_lu, LegendFont);
                    }

                    
                }

                #endregion

                #region Draw measurement line

                if (isStPoint)
                {
                    float mDistancePx;

                    PointF midPoint;

                    e.Graphics.DrawLine(mSubLinePen, stPoint.X - mCrossSize, stPoint.Y, stPoint.X + mCrossSize, stPoint.Y);
                    e.Graphics.DrawLine(mLinePen, stPoint.X - mCrossSize, stPoint.Y, stPoint.X + mCrossSize, stPoint.Y);
                    e.Graphics.DrawLine(mSubLinePen, stPoint.X, stPoint.Y - mCrossSize, stPoint.X, stPoint.Y + mCrossSize);
                    e.Graphics.DrawLine(mLinePen, stPoint.X, stPoint.Y - mCrossSize, stPoint.X, stPoint.Y + mCrossSize);

                    if (isNdPoint)
                    {
                        e.Graphics.DrawLine(mSubLinePen, stPoint, ndPoint);
                        e.Graphics.DrawLine(mLinePen, stPoint, ndPoint);

                        e.Graphics.DrawLine(mSubLinePen, ndPoint.X - mCrossSize, ndPoint.Y, ndPoint.X + mCrossSize, ndPoint.Y);
                        e.Graphics.DrawLine(mLinePen, ndPoint.X - mCrossSize, ndPoint.Y, ndPoint.X + mCrossSize, ndPoint.Y);
                        e.Graphics.DrawLine(mSubLinePen, ndPoint.X, ndPoint.Y - mCrossSize, ndPoint.X, ndPoint.Y + mCrossSize);
                        e.Graphics.DrawLine(mLinePen, ndPoint.X, ndPoint.Y - mCrossSize, ndPoint.X, ndPoint.Y + mCrossSize);

                        midPoint = new Point((stPoint.X + ndPoint.X) / 2, (stPoint.Y + ndPoint.Y) / 2);
                        mDistancePx = Dist2D(stPoint, ndPoint);
                    }
                    else
                    {
                        e.Graphics.DrawLine(mSubLinePen, stPoint, msPoint);
                        e.Graphics.DrawLine(mLinePen, stPoint, msPoint);

                        midPoint = new Point((stPoint.X + msPoint.X) / 2, (stPoint.Y + msPoint.Y) / 2);
                        mDistancePx = Dist2D(stPoint, msPoint);
                    }

                    float mDistanceM = mDistancePx / gScale.X;
                    var mDistanceStr = string.Format(CultureInfo.InvariantCulture, "{0:F03} m", mDistanceM);
                    var mDistanceSSize = e.Graphics.MeasureString(mDistanceStr, MeasurementTextFont);

                    midPoint.X = midPoint.X - mDistanceSSize.Width / 2;
                    midPoint.Y = midPoint.Y - mDistanceSSize.Height / 2;
                    
                    e.Graphics.DrawRectangle(mLinePen, midPoint.X, midPoint.Y, mDistanceSSize.Width, mDistanceSSize.Height);
                    e.Graphics.FillRectangle(measurementTextBgBrush, midPoint.X, midPoint.Y, mDistanceSSize.Width, mDistanceSSize.Height);
                    e.Graphics.DrawString(mDistanceStr, MeasurementTextFont, measurementTextBrush, midPoint);
                }

                #endregion
            }

            #region Draw history lines

            if (HistoryVisible)
            {
                float hLinesHeight = 0;
                if (historyLines != null)
                {
                    for (int i = 0; i < historyLines.Length; i++)
                    {
                        string hLine;
                        if (historyLines[i].Length > maxHistoryLineLength)
                            hLine = string.Format("{0}...\r\n", historyLines[i].Substring(0, maxHistoryLineLength));
                        else
                            hLine = string.Format(historyLines[i]);

                        var hLinesSize = e.Graphics.MeasureString(hLine, HistoryTextFont);

                        e.Graphics.DrawString(hLine, HistoryTextFont,
                            new SolidBrush(Color.FromArgb(255 - i * 40, HistoryTextColor)),
                            -this.Width / 2 + this.Padding.Left, this.Height / 2 - hLinesSize.Height * (i + 1) - this.Padding.Bottom);
                        hLinesHeight += hLinesSize.Height;
                    }
                }
            }

            #endregion

            #region Draw left upper corner text

            if (LeftUpperTextVisible && !string.IsNullOrEmpty(LeftUpperText))
            {
                PointF luTextPos = new PointF(-this.Width / 2 + this.Padding.Left, -this.Height / 2 + this.Padding.Top);
                var luTextSize = e.Graphics.MeasureString(LeftUpperText, LeftUpperTextFont);
                if (textBackgoundColor != Color.Empty)
                {
                    e.Graphics.FillRectangle(textBackgroundBrush, luTextPos.X, luTextPos.Y, luTextSize.Width, luTextSize.Height);
                }
                    
                e.Graphics.DrawString(LeftUpperText, LeftUpperTextFont, leftUpperTextBrush, luTextPos);
            }

            #endregion

            #region Draw right upper corner text

            if (RightUpperTextVisible && rightUpperText.IsInitialized)
            {
                byte alpha = Age2Alpha(rightUpperText.Age.TotalSeconds, rightUpperText.ObsoleteIntervalSec);

                var str = rightUpperText.ToString();
                var ruTextSize = e.Graphics.MeasureString(str, RightUpperTextFont);
                PointF ruTextPos = new PointF(this.Width / 2 - this.Padding.Right - ruTextSize.Width, -this.Height / 2 + rd_y);
                if (rightUpperTextBkColor != Color.Empty)
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(alpha, rightUpperTextBkColor)), ruTextPos.X, ruTextPos.Y, ruTextSize.Width, ruTextSize.Height);

                e.Graphics.DrawString(str, RightUpperTextFont, new SolidBrush(Color.FromArgb(alpha, rightUpperTextColor)), ruTextPos);

            }

            #endregion
        }

        private void uOSMGeoPlot_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void uOSMGeoPlot_MouseMove(object sender, MouseEventArgs e)
        {
            if (isStPoint)
            {
                msPoint = new Point(e.X - this.Width / 2, e.Y - this.Height / 2);
                Invalidate();
            }
        }

        private void uOSMGeoPlot_MouseClick(object sender, MouseEventArgs e)
        {
            if ((e.Button != System.Windows.Forms.MouseButtons.Left) || (isNdPoint))
            {
                isStPoint = false;
                isNdPoint = false;
            }
            else
            {
                if (!isStPoint)
                {
                    stPoint = new Point(e.X - this.Width / 2, e.Y - this.Height / 2);
                    msPoint = stPoint;
                    isNdPoint = false;
                    isStPoint = true;
                }
                else
                {
                    ndPoint = new Point(e.X - this.Width / 2, e.Y - this.Height / 2);
                    isNdPoint = true;
                }
            }

            Invalidate();
        }

        #endregion        
    }
}
