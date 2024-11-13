using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using UCNLDrivers;
using UCNLNav;
using uOSM;

namespace UCNLUI.Controls.uPlot
{
    public partial class uGeoPlot : UserControl
    {
        #region Properties

        readonly int maxLayersInCache = 32;
        Dictionary<string, Bitmap> tileCache;
        string currentLayerID = string.Empty;

        Point tileLayerCenterOffset_px;
        Bitmap tileLayer;
        uOSMTileProvider tProvider;
        readonly int minZoom = 4;
        readonly int maxZoom = 25;
        readonly int maxTileZoom = 19;

        int g_lu_x = 0, g_lu_y = 0;
        int g_rb_x = 0, g_rb_y = 0;

        double mpx = 0;
        double scale = 0;
        int _zoom = 0;
        int zoom
        {
            get => _zoom;
            set
            {
                _zoom = value;
                scale = 156543.03 * Math.Cos(center_lat * Math.PI / 180.0) / Math.Pow(2, _zoom);
                mpx = 1 / scale;

                ZoomLevelChanged.Rise(this, EventArgs.Empty);
                UpdateTileLayer();
            }
        }

        public int ZoomLevel
        {
            get => _zoom;
        }

        Point mouse_drag_start_pos;

        bool center_coordinates_set = false;
        double center_lat = 48.502178;
        double center_lon = 44.552608;

        Size tileSize;

        public bool ShowZoomLevel { get; set; }

        bool tilesEnabled = false;
        public bool TilesEnabled
        {
            get => tilesEnabled;
            set
            {
                tilesEnabled = value;
                if (tileCache != null) 
                    tileCache.Clear();
            }
        }

        public bool TileBordersVisible { get; set; }

        public Color TileBorderColor
        {
            get => tileBorderPen.Color;
            set => tileBorderPen.Color = value;
        }

        public float TileBorderWidth
        {
            get => tileBorderPen.Width;
            set => tileBorderPen.Width = value;
        }

        public DashStyle TileBorderStyle
        {
            get => tileBorderPen.DashStyle;
            set => tileBorderPen.DashStyle = value;
        }

        Pen tileBorderPen;

        Pen scaleSubLinePen;
        Pen scaleLinePen;
        Font scaleLineFont;
        SolidBrush scaleLineTextBrush;
        SolidBrush scaleLineTextBackBrush;
        Pen mlineSubPen;
        Pen mlinePen;
        SolidBrush mlineTextBrush;
        Font mlineFont;
        SolidBrush mlineBackTextBrush;
        Font legendFont;

        Font historyFont;
        Color historyTextColor;
        int historyLinesNumber = 4;
        int historySynLock = 0;
        List<string> historyLines;
        SolidBrush[] historyLinesTextBrushes;
        int maxHistoryLineLength = 127;

        Font leftUpperTextFont;
        SolidBrush leftUpperTextBrush;
        SolidBrush leftUpperTextBackgroundBrush;

        Font rightUpperTextFont;
        SolidBrush rightUpperTextBackgroundBrush;

        public float ScaleTickSize { get; set; }

        public Color ScaleLineColor
        {
            get => scaleLinePen.Color;
            set => scaleLinePen.Color = value;
        }

        public float ScaleLineWidth
        {
            get => scaleLinePen.Width;
            set
            {
                scaleLinePen.Width = value;
                scaleSubLinePen.Width = value + 2;
            }
        }

        public Color ScaleLineBackgroundColor
        {
            get => scaleLineTextBackBrush.Color;
            set => scaleLineTextBackBrush.Color = value;
        }

        public Font ScaleLineFont
        {
            get => scaleLineFont;
            set
            {
                if (value != null)
                    scaleLineFont = value;                
            }
        }

        public Color ScaleLineTextColor
        {
            get => scaleLineTextBrush.Color;
            set => scaleLineTextBrush.Color = value;
        }


        public bool HistoryVisible { get; set; }

        public Font HistoryFont
        {
            get => historyFont;
            set
            {
                if (value != null)
                    historyFont = value;               
            }
        }

        public int HistoryLinesNumber
        {
            get => historyLinesNumber;
            set
            {
                if (value >= 1)
                {
                    historyLinesNumber = value;
                    UpdateHistoryLinesProperties();
                }
                else
                    throw new ArgumentOutOfRangeException(nameof(value));
            }
        }

        public Color HistoryTextColor
        {
            get { return historyTextColor; }
            set
            {
                historyTextColor = value;
                UpdateHistoryLinesProperties();
            }
        }


        public bool LeftUpperTextVisible { get; set; }

        public string LeftUpperText { get; set; }

        public Font LeftUpperTextFont
        {
            get => leftUpperTextFont;
            set
            {
                if (value != null)
                    leftUpperTextFont = value;               
            }
        }

        public Color LeftUpperTextColor
        {
            get => leftUpperTextBrush.Color;
            set => leftUpperTextBrush.Color = value;
        }

        public Color LeftUpperTextBackgroundColor
        {
            get => leftUpperTextBackgroundBrush.Color;
            set => leftUpperTextBackgroundBrush.Color = value;
        }


        public bool RightUpperTextVisible { get; set; }

        AgingValue<string> rightUpperText;

        public string RightUpperText
        {
            get => rightUpperText.Value;            
        }

        public Font RightUpperTextFont
        {
            get => rightUpperTextFont;
            set
            {
                if (value != null)
                    rightUpperTextFont = value;               
            }
        }

        public Color RightUpperTextColor { get; set; }


        public Color RightUpperTextBackgroundColor
        {
            get => rightUpperTextBackgroundBrush.Color;
            set => rightUpperTextBackgroundBrush.Color = value;
        }


        #region measuring line

        Point mline_start;
        Point mline_end;
        int mline_state = 0;

        public Color MeasuringLineColor
        {
            get => mlinePen.Color;
            set => mlinePen.Color = value;
        }

        public float MeasuringLineWidth
        {
            get => mlinePen.Width;
            set
            {
                mlinePen.Width = value;
                mlineSubPen.Width = value + 2;
            }
        }

        public Color MeasuringLineBackgroundColor
        {
            get => mlineSubPen.Color;
            set => mlineSubPen.Color = value;
        }

        public Font MeasuringLineFont
        {
            get => mlineFont;
            set
            {
                if (value != null)
                    mlineFont = value;                
            }
        }

        public Color MeasuringLineTextColor
        {
            get => mlineTextBrush.Color;
            set => mlineTextBrush.Color = value;
        }

        public Color MeasuringLineBackTextColor
        {            
            get => mlineBackTextBrush.Color;
            set => mlineBackTextBrush.Color = value;
        }

        public int MeasuringLineCrossSize { get; set; }

        #endregion

        public bool GridSizeVisible { get; set; }

        public bool LegendVisible { get; set; }

        public Font LegendFont
        {
            get => legendFont;
            set
            {
                if (value != null)
                    legendFont = value;                
            }
        }

        uGeoTracks tracks;

        #endregion

        #region Constructor

        public uGeoPlot()
        {
            InitializeComponent();

            tileCache = new Dictionary<string, Bitmap>();
            rightUpperText = new AgingValue<string>(5, 255, x => x);

            TilesEnabled = false;
            tileBorderPen = new Pen(Color.Gray, 1);
            tileBorderPen.DashStyle = DashStyle.Dot;
            tileSize = new Size(256, 256);
            scaleLinePen = new Pen(Color.Black, 2);
            scaleSubLinePen = new Pen(Color.White, 4);
            scaleLineFont = this.Font;
            ScaleTickSize = 10;
            scaleLineTextBrush = new SolidBrush(Color.Black);
            scaleLineTextBackBrush = new SolidBrush(Color.FromArgb(20, Color.Gray));

            mlineSubPen = new Pen(Color.White, 3);
            mlinePen = new Pen(Color.Black, 1);
            mlineTextBrush = new SolidBrush(Color.Black);
            mlineFont = this.Font;
            mlineBackTextBrush = new SolidBrush(Color.FromArgb(20, Color.Gray));
            MeasuringLineCrossSize = 15;

            zoom = 18;

            historyFont = this.Font;
            historyTextColor = Color.Green;
            historyLinesNumber = 4;
            historyLines = new List<string>();
            UpdateHistoryLinesProperties();

            leftUpperTextFont = this.Font;
            leftUpperTextBrush = new SolidBrush(Color.Blue);
            leftUpperTextBackgroundBrush = new SolidBrush(Color.FromArgb(120, Color.White));
            
            rightUpperTextFont = this.Font;
            RightUpperTextColor = Color.Brown;
            rightUpperTextBackgroundBrush = new SolidBrush(Color.FromArgb(200, Color.White));            

            legendFont = this.Font;

            tracks = new uGeoTracks(3);

            this.Resize += (o, e) => UpdateTileLayer();

            this.MouseWheel += (o, e) =>
            {
                if (e.Delta > 0) ZoomIn();
                else ZoomOut();
            };

            this.MouseDown += (o, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (mline_state != 0)
                    {
                        mline_state = 0;
                        Invalidate();
                    }                

                    mouse_drag_start_pos = e.Location;                    
                    Cursor = Cursors.SizeAll;                    
                } 
                else if (e.Button == MouseButtons.Right)
                {
                    if (mline_state == 0)
                    {
                        mline_start = e.Location;
                        mline_end = e.Location;
                    }
                    else if (mline_state == 1)
                    {
                        mline_end = e.Location;
                    }

                    mline_state = (mline_state + 1) % 3;
                    Invalidate();
                }
            };

            this.MouseMove += (o, e) =>
            {
                if (mline_state == 1)
                {
                    mline_end = e.Location;
                    Invalidate();
                }
            };

            this.MouseUp += (o, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    Translate(e.X - mouse_drag_start_pos.X, -(e.Y - mouse_drag_start_pos.Y));
                    Cursor = Cursors.Default;
                }                
            };
        }

        #endregion

        #region Methods

        #region Private

        private void UpdateHistoryLinesProperties()
        {
            while (Interlocked.CompareExchange(ref historySynLock, 1, 0) != 0)
                Thread.SpinWait(1);

            while (historyLines.Count > historyLinesNumber)
                historyLines.RemoveAt(historyLines.Count - 1);

            historyLinesTextBrushes = new SolidBrush[historyLinesNumber];

            int cDelta = (255 - 40) / historyLinesNumber;

            for (int i = 0; i < historyLinesNumber; i++)
                historyLinesTextBrushes[i] = new SolidBrush(Color.FromArgb(255 - i * cDelta, historyTextColor));

            Interlocked.Decrement(ref historySynLock);
        }
        
        private static double FitAxisStepByRange(double range)
        {
            double x = Math.Pow(10.0, Math.Floor(Math.Log10(range)));
            if (range / x >= 5)
                return x;
            else if (range / (x / 2.0) >= 5)
                return x / 2.0;
            else
                return x / 5.0;
        }

        private void UpdateTileLayer()
        {
            int tWidth = tProvider == null ? tileSize.Width : tProvider.TileSize.Width;
            int tHeight = tProvider == null ? tileSize.Height : tProvider.TileSize.Height;

            uOSMTileUtils.GetTiles(this.Width, this.Height,
                    tWidth, tHeight,
                    center_lat, center_lon, _zoom,
                    out int lu_x, out int lu_y, out int rb_x, out int rb_y,
                    out _, out _,
                    out double x_offset_px, out double y_offset_px);

            g_lu_x = lu_x;
            g_lu_y = lu_y;
            g_rb_x = rb_x;
            g_rb_y = rb_y;

            var tileID = string.Format("{0}-{1}-{2}-{3}",
                lu_x, lu_y, rb_x, rb_y);

            int tLayerWidth = (rb_x - lu_x) * tWidth;
            int tLayerHeight = (rb_y - lu_y) * tHeight;

            tileLayerCenterOffset_px.X = -Convert.ToInt32(x_offset_px) - (tLayerWidth - this.Width) / 2;
            tileLayerCenterOffset_px.Y = Convert.ToInt32(y_offset_px) - (tLayerHeight - this.Height) / 2;

            if (TilesEnabled &&
                (tProvider != null) &&
                (_zoom <= maxTileZoom))
            {
                if (tileID != currentLayerID)
                {
                    currentLayerID = tileID;
                    bool layerCached = false;

                    if (tileCache.ContainsKey(tileID))
                    {
                        tileLayer = tileCache[tileID];
                        layerCached = true;
                    }
                    else
                    {
                        tileLayer = new Bitmap(tLayerWidth, tLayerHeight);
                    }

                    if (!layerCached)
                    {
                        using (Graphics bg = Graphics.FromImage(tileLayer))
                        {
                            this.Cursor = Cursors.WaitCursor;
                            var tiles = tProvider.GetTiles(_zoom, lu_x, rb_x, lu_y, rb_y);
                            this.Cursor = Cursors.Default;

                            foreach (var tile in tiles)
                            {
                                var tRect = new Rectangle(
                                    (tile.X - lu_x) * tile.Tile.Width,
                                    (tile.Y - lu_y) * tile.Tile.Height,
                                    tile.Tile.Width, tile.Tile.Height);
                                bg.DrawImageUnscaled(tile.Tile, tRect);                                
                            }                            
                        }

                        if (tileCache.Count >= maxLayersInCache)
                            tileCache.Remove(tileCache.Keys.First());

                        tileCache.Add(tileID, tileLayer);
                    }
                }
            }
            else
            {
                tileLayer = null;
            }

            mline_state = 0;            
            this.Invalidate();
        }

        private void Translate(int x_px, int y_px)
        {
            if ((x_px == 0) && (y_px == 0))
                return;

            double dx_m = x_px * scale;
            double dy_m = y_px * scale;

            Algorithms.GeopointOffsetByDeltas_WGS84(
                Algorithms.Deg2Rad(center_lat), Algorithms.Deg2Rad(center_lon),
                dy_m, dx_m,
                out double c_lat_rad, out double c_lon_rad);

            center_lat = Algorithms.Rad2Deg(c_lat_rad);
            center_lon = Algorithms.Rad2Deg(c_lon_rad);

            UpdateTileLayer();
        }

        private string M2StrS(double v)
        {
            if (v < 10)
                return string.Format(CultureInfo.InvariantCulture, "{0:F01} m ", v);
            else if (v < 1000)
                return string.Format(CultureInfo.InvariantCulture, "{0:F00} m ", v);
            else 
                return string.Format(CultureInfo.InvariantCulture, "{0:F00} km ", v / 1000);
        }

        private string M2Str(double v)
        {
            if (v < 10)
                return string.Format(CultureInfo.InvariantCulture, "{0:F03} m ", v);
            else if (v < 100)
                return string.Format(CultureInfo.InvariantCulture, "{0:F02} m ", v);
            else if (v < 1000)
                return string.Format(CultureInfo.InvariantCulture, "{0:F01} m ", v);
            else
                return string.Format(CultureInfo.InvariantCulture, "{0:F00} km ", v / 1000);
        }


        private byte Age2Alpha(double age_sec, double obs_int_sec)
        {
            double age = age_sec > obs_int_sec ? obs_int_sec : age_sec;
            int alpha = 5 + Convert.ToInt32(250.0 * (obs_int_sec - age) / obs_int_sec);
            return Convert.ToByte(alpha);
        }

        #endregion

        #region Public

        public void RightUpperTextSet(string text)
        {
            rightUpperText.Value = text;
        }

        public void ConnectTileProvider(uOSMTileProvider provider)
        {
            tileCache.Clear();
            tProvider = provider;
            tileSize = tProvider.TileSize;
        }

        public void FullZoomIn() { zoom = maxZoom; }

        public void FullZoomOut() { zoom = minZoom; }

        public void ZoomIn() { if (zoom < maxZoom) zoom++; }

        public void ZoomOut() { if (zoom > minZoom) zoom--; }

        public void Clear()
        {
            tracks.ClearPoints();
            
        }


        public void AppendHistoryLine(string text)
        {
            while (Interlocked.CompareExchange(ref historySynLock, 1, 0) != 0)
                Thread.SpinWait(1);

            historyLines.Insert(0, text.Replace("\r\n", " "));

            while (historyLines.Count > historyLinesNumber)
                historyLines.RemoveAt(historyLines.Count - 1);

            Interlocked.Decrement(ref historySynLock);
        }


        public void InitTrack(string trackID, int trackMaxPoints, Color trackColor, int trackPointSize, float trackLineWidth, bool markCurrent)
        {
            tracks.AddTrack(trackID, trackMaxPoints, trackColor, trackPointSize, trackLineWidth, markCurrent);
        }

        public void AddPoint(string trackID, double lat, double lon, double course)
        {            
            tracks.AddPoint(trackID, lat, lon, course);
        }

        public void AddPoint(string trackID, double lat, double lon)
        {
            if (!center_coordinates_set)
            {
                center_coordinates_set = true;
                SetCenter(lat, lon);
            }

            tracks.AddPoint(trackID, lat, lon, double.NaN);
        }


        public void SetCenter(double lat, double lon)
        {
            if ((lat >= -90) && (lat <= 90) && (lon >= -180) && (lon <= 180))
            {
                center_lat = lat;
                center_lon = lon;
                UpdateTileLayer();
            }
        }


        public void SetTracksVisibility(string trackID, bool visible)
        {
            tracks.SetTrackVisibility(trackID, visible);
        }

        public void SetTracksVisibility(bool visible)
        {
            tracks.SetTracksVisibility(visible);
        }

        public void SetTracksVisibility(string[] tracksIDs, bool visible)
        {
            foreach (string trackID in tracksIDs)
                tracks.SetTrackVisibility(trackID, visible);
        }

        #endregion

        #endregion

        #region Handlers

        private void uGeoPlot_Paint(object sender, PaintEventArgs e)
        {
            if (e.ClipRectangle.IsEmpty)
                return;

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            #region tileLayer

            if (tileLayer != null)
                e.Graphics.DrawImage(tileLayer, tileLayerCenterOffset_px);
            
            if (TileBordersVisible)
            {
                int sw = 0;
                for (int x = g_lu_x - 1; x < g_rb_x + 1; x++)
                    for (int y = g_lu_y - 1; y < g_rb_y + 1; y++)
                    {
                        if (sw == 0)
                        {
                            var tRect = new Rectangle(
                            (x - g_lu_x) * tileSize.Width + tileLayerCenterOffset_px.X,
                            (y - g_lu_y) * tileSize.Height + tileLayerCenterOffset_px.Y,
                            tileSize.Width, tileSize.Height);

                            e.Graphics.DrawRectangle(tileBorderPen, tRect);
                        }

                        sw = (sw + 1) % 1;
                    }
            }

            #endregion

            #region History lines
            
            if (HistoryVisible)
            {
                float hLinesHeight = 0;
                if (historyLines != null)
                {
                    while (Interlocked.CompareExchange(ref historySynLock, 1, 0) != 0)
                        Thread.SpinWait(1);

                    for (int i = 0; i < historyLines.Count; i++)
                    {
                        string hLine;
                        if (historyLines[i].Length > maxHistoryLineLength)
                            hLine = string.Format("{0}...\r\n", historyLines[i].Substring(0, maxHistoryLineLength));
                        else
                            hLine = string.Format(historyLines[i]);

                        var hLinesSize = e.Graphics.MeasureString(hLine, historyFont);

                        e.Graphics.DrawString(hLine, historyFont,
                            historyLinesTextBrushes[i],
                            this.Padding.Left, this.Height - hLinesSize.Height * (i + 1) - this.Padding.Bottom);
                        hLinesHeight += hLinesSize.Height;
                    }

                    Interlocked.Decrement(ref historySynLock);
                }
            }

            #endregion

            #region Scale bar

            var gScaleAligned = FitAxisStepByRange(this.Height * scale);
            float gScaleAligned_px = Convert.ToSingle(gScaleAligned * mpx);

            if (gScaleAligned_px > this.Height / 2)
            {
                gScaleAligned_px /= 2;
                gScaleAligned /= 2;
            }
            if (gScaleAligned_px <= this.Height / 4)
            {
                gScaleAligned_px *= 3;
                gScaleAligned *= 3;
            }

            float scale_r = this.Width - this.Padding.Right;
            float scale_b = this.Height - this.Padding.Bottom;
            float scale_t = scale_b - gScaleAligned_px;
            float scale_m = scale_b - gScaleAligned_px / 2;

            e.Graphics.DrawLine(scaleSubLinePen, scale_r, scale_t, scale_r, scale_b);
            e.Graphics.DrawLine(scaleLinePen, scale_r, scale_t, scale_r, scale_b);
            e.Graphics.DrawLine(scaleSubLinePen, scale_r - ScaleTickSize, scale_b, scale_r, scale_b);            
            e.Graphics.DrawLine(scaleSubLinePen, scale_r - ScaleTickSize / 2, scale_m, scale_r, scale_m);
            e.Graphics.DrawLine(scaleLinePen, scale_r - ScaleTickSize / 2, scale_m, scale_r, scale_m);

            string scaleLine;
            if (ShowZoomLevel)
                scaleLine = string.Format("z={0}\r\n{1}", _zoom, M2StrS(gScaleAligned));
            else
                scaleLine = M2StrS(gScaleAligned);

            var scaleLSize = e.Graphics.MeasureString(scaleLine, ScaleLineFont);

            if (GridSizeVisible)
            {
                var gridSizeLine = string.Format("grid: {0}", M2Str(tileSize.Width * scale));
                var gridSizeLineSize = e.Graphics.MeasureString(gridSizeLine, ScaleLineFont);
                e.Graphics.FillRectangle(scaleLineTextBackBrush,
                    scale_r - gridSizeLineSize.Width, scale_b - gridSizeLineSize.Height,
                    gridSizeLineSize.Width, gridSizeLineSize.Height);
                e.Graphics.DrawString(gridSizeLine, scaleLineFont, scaleLineTextBrush,
                    scale_r - gridSizeLineSize.Width - 2, scale_b - gridSizeLineSize.Height);

                e.Graphics.DrawLine(scaleLinePen, scale_r - gridSizeLineSize.Width, scale_b, scale_r, scale_b);
            }
            else
            {
                e.Graphics.DrawLine(scaleLinePen, scale_r - ScaleTickSize, scale_b, scale_r, scale_b);
            }

            e.Graphics.DrawLine(scaleSubLinePen, scale_r - scaleLSize.Width, scale_t, scale_r, scale_t);
            e.Graphics.DrawLine(scaleLinePen, scale_r - scaleLSize.Width, scale_t, scale_r, scale_t);

            e.Graphics.FillRectangle(scaleLineTextBackBrush, scale_r - scaleLSize.Width, scale_t - scaleLSize.Height - ScaleLineWidth, scaleLSize.Width, scaleLSize.Height);
            e.Graphics.DrawString(scaleLine, ScaleLineFont, scaleLineTextBrush, scale_r - scaleLSize.Width, scale_t - scaleLSize.Height);

            #endregion

            #region Left-top text

            if (LeftUpperTextVisible && !string.IsNullOrEmpty(LeftUpperText))
            {
                PointF luTextPos = new PointF(this.Padding.Left, this.Padding.Top);
                var luTextSize = e.Graphics.MeasureString(LeftUpperText, leftUpperTextFont);
                e.Graphics.FillRectangle(leftUpperTextBackgroundBrush, luTextPos.X, luTextPos.Y, luTextSize.Width, luTextSize.Height);
                e.Graphics.DrawString(LeftUpperText, leftUpperTextFont, leftUpperTextBrush, luTextPos);
            }

            #endregion

            float rightTop = this.Padding.Top;

            #region Right-top text

            if (RightUpperTextVisible && (rightUpperText != null) && rightUpperText.IsInitialized)
            {
                byte alpha = Age2Alpha(rightUpperText.Age.TotalSeconds, rightUpperText.ObsoleteIntervalSec);

                var ru_str = rightUpperText.ToString();
                var ru_str_size = e.Graphics.MeasureString(ru_str, rightUpperTextFont);
                var ru_pos = new PointF(this.Width - this.Padding.Right - ru_str_size.Width, rightTop);
                e.Graphics.FillRectangle(rightUpperTextBackgroundBrush, ru_pos.X, ru_pos.Y, ru_str_size.Width, ru_str_size.Height);
                e.Graphics.DrawString(ru_str, rightUpperTextFont,
                    new SolidBrush(
                        Color.FromArgb(alpha, RightUpperTextColor)), ru_pos);

                rightTop += ru_str_size.Height + this.Padding.Bottom;
            }

            #endregion

            #region Measuring line

            if (mline_state != 0)
            {
                e.Graphics.DrawLine(mlineSubPen, mline_start, mline_end);
                e.Graphics.DrawLine(mlinePen, mline_start, mline_end);

                e.Graphics.DrawLine(mlineSubPen,
                    mline_start.X - MeasuringLineCrossSize / 2, mline_start.Y,
                    mline_start.X + MeasuringLineCrossSize / 2, mline_start.Y);
                e.Graphics.DrawLine(mlinePen,
                    mline_start.X - MeasuringLineCrossSize / 2, mline_start.Y,
                    mline_start.X + MeasuringLineCrossSize / 2, mline_start.Y);

                e.Graphics.DrawLine(mlineSubPen,
                    mline_start.X, mline_start.Y - MeasuringLineCrossSize / 2,
                    mline_start.X, mline_start.Y + MeasuringLineCrossSize / 2);
                e.Graphics.DrawLine(mlinePen,
                    mline_start.X, mline_start.Y - MeasuringLineCrossSize / 2,
                    mline_start.X, mline_start.Y + MeasuringLineCrossSize / 2);

                e.Graphics.DrawLine(mlineSubPen,
                    mline_end.X - MeasuringLineCrossSize / 2, mline_end.Y,
                    mline_end.X + MeasuringLineCrossSize / 2, mline_end.Y);
                e.Graphics.DrawLine(mlinePen,
                    mline_end.X - MeasuringLineCrossSize / 2, mline_end.Y,
                    mline_end.X + MeasuringLineCrossSize / 2, mline_end.Y);

                e.Graphics.DrawLine(mlineSubPen,
                    mline_end.X, mline_end.Y - MeasuringLineCrossSize / 2,
                    mline_end.X, mline_end.Y + MeasuringLineCrossSize / 2);
                e.Graphics.DrawLine(mlinePen,
                    mline_end.X, mline_end.Y - MeasuringLineCrossSize / 2,
                    mline_end.X, mline_end.Y + MeasuringLineCrossSize / 2);

                var mline_length_m = scale * Math.Sqrt(Math.Pow(mline_start.X - mline_end.X, 2) + Math.Pow(mline_start.Y - mline_end.Y, 2));

                var mline_str = M2Str(mline_length_m);
                var mline_str_size = e.Graphics.MeasureString(mline_str, mlineFont);

                e.Graphics.FillRectangle(mlineBackTextBrush, mline_end.X, mline_end.Y - mline_str_size.Height, mline_str_size.Width, mline_str_size.Height);
                e.Graphics.DrawString(mline_str, mlineFont, mlineTextBrush, mline_end.X, mline_end.Y - mline_str_size.Height);

            }

            #endregion

            #region Legend

            if (LegendVisible)            
                tracks.DrawLegends(e.Graphics, legendFont, new Point(this.Width - this.Padding.Right, Convert.ToInt32(rightTop)));            

            #endregion

            #region Tracks

            e.Graphics.TranslateTransform(this.Width / 2.0f, this.Height / 2.0f);

            GeoPoint cPoint = new GeoPoint(center_lat, center_lon);
            tracks.DrawTracks(e.Graphics, cPoint, mpx);            

            #endregion
        }

        #endregion

        #region Events

        public EventHandler ZoomLevelChanged;

        #endregion
    }
}
