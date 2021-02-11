using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using UCNLNav;

namespace UCNLUI.Controls
{
    public partial class GeoPlotCartesian : UserControl
    {
        #region Properties

        int historyLinesNumber = 5;
        FixedSizeLIFO<string> history;
        string[] historyLines;
        int maxTextLength = 128;
        
        int trackLength = 100;
        Dictionary<string, FixedSizeLIFO<PointF>> tracks;

        Dictionary<string, Color> trackColors;
        Dictionary<string, float> trackPenSizes;
        Dictionary<string, Pen> trackPens;
        Dictionary<string, bool> latestPointMarks;
        Dictionary<string, float> course;

        float meanLatDeg = float.NaN;
        float meanLonDeg = float.NaN;
        float farestLatDeltaDeg = float.NaN;
        float farestLonDeltaDeg = float.NaN;
        
        int borderGap = 5;
                              
        #region Misc. font

        Font miscInfoFnt;
        Brush miscInfoBrs;

        int miscFntSize = 5;
        public int MiscFntSize
        {
            get { return miscFntSize; }
            set
            {
                miscFntSize = value;
                miscInfoFnt = new System.Drawing.Font("Consolas", miscFntSize, GraphicsUnit.Millimeter);
            }
        }

        Color miscInfoClr = Color.Black;
        public Color MiscInfoColor
        {
            get { return miscInfoClr; }
            set
            {
                miscInfoClr = value;
                miscInfoBrs = new SolidBrush(miscInfoClr);
            }
        }

        #endregion

        #region Axis labels font

        Font axisLblFnt;
        Brush axisLblBrs;

        int axisLblsFntSize = 4;

        public int AxisLabelsFntSize
        {
            get { return axisLblsFntSize; }
            set
            {
                axisLblsFntSize = value;
                axisLblFnt = new System.Drawing.Font("Consolas", axisLblsFntSize, GraphicsUnit.Millimeter);
            }
        }

        Color axisLblClr = Color.Black;
        public Color AxisLabelsColor
        {
            get { return axisLblClr; }
            set
            {
                axisLblClr = value;
                axisLblBrs = new SolidBrush(axisLblClr);
            }
        }

        #endregion

        #region History lines font

        int historyFntSize = 3;
        Font histLinesFnt;
        Brush histLinesBrs;

        Color histLineClr = Color.Black;

        public Color HistoryLinesColor
        {
            get { return histLineClr; }
            set
            {
                histLineClr = value;
                histLinesBrs = new SolidBrush(histLineClr);
            }
        }

        public int HistoryLinesFntSize
        {
            get { return historyFntSize; }
            set
            {
                historyFntSize = value;
                histLinesFnt = new System.Drawing.Font("Consolas", historyFntSize, GraphicsUnit.Millimeter);
            }
        }


        #endregion        

        #region grid pen

        Pen gridPen;

        Color gridColor = Color.Black;
        public Color GridColor
        {
            get { return gridColor; }
            set
            {
                gridColor = value;
                gridPen = new Pen(gridColor, 1.0f);
            }
        }

        #endregion

        float courseLineLength = 200;
        public int CourseLineLength
        {
            get { return Convert.ToInt32(courseLineLength); }
            set
            {
                if (value > 0)
                    courseLineLength = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }

        Color defaultPointColor = Color.Blue;
        float defaultTrackPointSize = 4.0f;

        string legendLbl = string.Empty;

        string leftUpperCornerText = string.Empty;
        public string LeftUpperCornerText
        {
            get { return leftUpperCornerText; }
            set { leftUpperCornerText = value; }
        }

        Pen coursePen;

        string northSign = "N";

        bool fitByDictionary = false;
        public bool FitByDictionary
        {
            get
            {
                return fitByDictionary;
            }
            set
            {
                if (fitByDictionary != value)
                {
                    fitByDictionary = value;
                    ResetTracksStatistics();
                    RefreshTrackStatistics();
                }
            }
        }

        List<string> tracksToFit;

        #endregion

        #region Constructor

        public GeoPlotCartesian()
        {
            InitializeComponent();

            tracks = new Dictionary<string, FixedSizeLIFO<PointF>>();
            trackColors = new Dictionary<string, Color>();
            trackPenSizes = new Dictionary<string, float>();
            trackPens = new Dictionary<string, Pen>();
            latestPointMarks = new Dictionary<string, bool>();
            course = new Dictionary<string, float>();
            
            miscInfoBrs = new SolidBrush(miscInfoClr);
            miscInfoFnt = new System.Drawing.Font("Consolas", miscFntSize, GraphicsUnit.Millimeter);

            history = new FixedSizeLIFO<string>(historyLinesNumber);
            histLinesFnt = new System.Drawing.Font("Consolas", historyFntSize, GraphicsUnit.Millimeter);
            histLinesBrs = new SolidBrush(histLineClr);

            axisLblFnt = new System.Drawing.Font("Consolas", axisLblsFntSize, GraphicsUnit.Millimeter);
            axisLblBrs = new SolidBrush(axisLblClr);

            gridPen = new Pen(gridColor, 1.0f);

            coursePen = new Pen(gridColor, 1.0f);
            coursePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            tracksToFit = new List<string>();
        }

        #endregion

        #region Methods

        #region Private

        private float ABFlt(float prev, float next, float a)
        {
            if (float.IsNaN(prev))
                return next;
            else
                return a * prev + (1.0f - a) * next;
        }

        private PointF DegToMeters(double lat1, double lon1, double lat2, double lon2)
        {
            double dLat_m = 0, dLon_m = 0;
            Algorithms.GetDeltasByGeopoints_WGS84(Algorithms.Deg2Rad(lat1), Algorithms.Deg2Rad(lon1),
                Algorithms.Deg2Rad(lat2), Algorithms.Deg2Rad(lon2), out dLat_m, out dLon_m);
            return new PointF(Convert.ToSingle(dLon_m), Convert.ToSingle(dLat_m));
        }

        private void UpdateLegendLabel()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var trk in tracks)
                sb.AppendFormat("{0}\r\n", trk.Key);

            legendLbl = sb.ToString();
        }

        private void RefreshTrackStatistics()
        {
            double meanLat = 0.0;
            double meanLon = 0.0;
            int cnt = 0;

            foreach (var item in tracks)
            {
                if (!fitByDictionary || (tracksToFit.Contains(item.Key)))
                {
                    var points = item.Value.ToArray();
                    for (int i = 0; i < points.Length; i++)
                    {
                        meanLon += points[i].X;
                        meanLat += points[i].Y;
                    }

                    cnt += points.Length;
                }
            }

            if (cnt > 0)
            {
                meanLon /= cnt;
                meanLat /= cnt;

                double farestX = 0;
                double farestY = 0;
                foreach (var item in tracks)
                {
                    if (!fitByDictionary || (tracksToFit.Contains(item.Key)))
                    {
                        var points = item.Value.ToArray();
                        for (int i = 0; i < points.Length; i++)
                        {
                            if (Math.Abs(meanLat - points[i].Y) > farestY)
                                farestY = Math.Abs(meanLat - points[i].Y);
                            if (Math.Abs(meanLon - points[i].X) > farestX)
                                farestX = Math.Abs(meanLon - points[i].X);
                        }
                    }
                }

                meanLatDeg = ABFlt(meanLatDeg, Convert.ToSingle(meanLat), 0.8f);
                meanLonDeg = ABFlt(meanLonDeg, Convert.ToSingle(meanLon), 0.8f);

                farestLatDeltaDeg = ABFlt(farestLatDeltaDeg, Convert.ToSingle(farestY), 0.1f);
                farestLonDeltaDeg = ABFlt(farestLonDeltaDeg, Convert.ToSingle(farestX), 0.1f);
            }
        }

        private void ResetTracksStatistics()
        {
            meanLatDeg = float.NaN;
            meanLonDeg = float.NaN;
            farestLatDeltaDeg = float.NaN;
            farestLonDeltaDeg = float.NaN;
        }

        #endregion

        public void InitTracks(int trLength)
        {
            trackLength = trLength;
        }        

        public void AddTrack(string key, Color color,
            float penWidth, int pointSize, int trackSize, bool isMarkLatestPoint)
        {
            if (tracks.ContainsKey(key))
                throw new ArgumentException("Track with specified key is already exists");

            tracks.Add(key, new FixedSizeLIFO<PointF>(trackSize));
            trackColors.Add(key, color);
            trackPenSizes.Add(key, pointSize);
            trackPens.Add(key, new Pen(color, penWidth));
            latestPointMarks.Add(key, isMarkLatestPoint);
            course.Add(key, float.NaN);

            UpdateLegendLabel();
        }        

        public void UpdateTrack(string tKey, PointF[] pnts)
        {
            if (!tracks.ContainsKey(tKey))
                AddTrack(tKey, defaultPointColor, defaultTrackPointSize, 4, trackLength, true);

            foreach (var pnt in pnts)
                tracks[tKey].Add(pnt);

            RefreshTrackStatistics();
        }

        public void UpdateTrack(string tKey, double lat, double lon, double course_deg)
        {
            if (!tracks.ContainsKey(tKey))
                AddTrack(tKey, defaultPointColor, defaultTrackPointSize, 4, trackLength, true);                

            tracks[tKey].Add(new PointF(Convert.ToSingle(lon), Convert.ToSingle(lat)));
            course[tKey] = Convert.ToSingle(Algorithms.Deg2Rad(course_deg - 90));
            RefreshTrackStatistics();
        }

        public void UpdateTrack(string tKey, double lat, double lon)
        {
            if (!tracks.ContainsKey(tKey))
                AddTrack(tKey, defaultPointColor, defaultTrackPointSize, 4, trackLength, true);

            tracks[tKey].Add(new PointF(Convert.ToSingle(lon), Convert.ToSingle(lat)));
            RefreshTrackStatistics();
        }

        public void ClearTracks()
        {
            foreach (var item in tracks)
                item.Value.Clear();

            ResetTracksStatistics();
        }

        public void AppendHistoryLine(string text)
        {
            history.Add(text.Replace("\r\n", " "));
            historyLines = history.ToArray();
        }


        public bool TracksToFitIsContains(string key)
        {
            return tracksToFit.Contains(key);
        }

        public bool TracksToFitAdd(string key)
        {
            if (!tracksToFit.Contains(key))
            {
                tracksToFit.Add(key);
                ResetTracksStatistics();
                RefreshTrackStatistics();
                return true;
            }
            else
                return false;
        }

        public bool TracksToFitRemove(string key)
        {
            if (tracksToFit.Contains(key))
            {
                tracksToFit.Remove(key);
                ResetTracksStatistics();
                RefreshTrackStatistics();                
                return true;
            }
            else
            {
                return false;
            }            
        }

        public void TracksToFitClear()
        {
            tracksToFit.Clear();
            ResetTracksStatistics();
            FitByDictionary = false;
        }

        public void TracksToFitSet(IEnumerable<string> keys)
        {
            tracksToFit.Clear();
            foreach (var key in keys)
            {
                if (!tracksToFit.Contains(key))
                    tracksToFit.Add(key);
            }
            ResetTracksStatistics();
            RefreshTrackStatistics();
        }

        public void TracksToFitSet(string key)
        {
            tracksToFit.Clear();
            tracksToFit.Add(key);
            ResetTracksStatistics();
            RefreshTrackStatistics();            
        }

        #endregion

        #region Handlers

        private void MarinePlot_Paint(object sender, PaintEventArgs e)
        {            
            if (!e.ClipRectangle.IsEmpty)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                e.Graphics.TranslateTransform(this.Width / 2.0f, this.Height / 2.0f);

                #region draw historyLines

                float hLinesHeight = 0;
                if (historyLines != null)
                {
                    for (int i = 0; i < historyLines.Length; i++)
                    {
                        string hLine;
                        if (historyLines[i].Length > maxTextLength)
                            hLine = string.Format("{0}...\r\n", historyLines[i].Substring(0, maxTextLength));
                        else
                            hLine = string.Format(historyLines[i]);

                        var hLinesSize = e.Graphics.MeasureString(hLine, histLinesFnt);

                        e.Graphics.DrawString(hLine, histLinesFnt,
                            new SolidBrush(Color.FromArgb(255 - i * 40, histLineClr)),
                            -this.Width / 2 + borderGap, this.Height / 2 - hLinesSize.Height * (i + 1));
                        hLinesHeight += hLinesSize.Height;
                    }
                }

                #endregion

                #region draw tracks

                if (tracks.Count > 0)
                {
                    float farestXDelta = 0.0f;
                    float farestYDelta = 0.0f;

                    Dictionary<string, PointF[]> deltas = new Dictionary<string, PointF[]>();

                    foreach (var track in tracks)
                    {
                        if (!fitByDictionary || (tracksToFit.Contains(track.Key)))
                        {
                            var trkPoints = track.Value.ToArray();
                            var trkDeltas = new PointF[trkPoints.Length];
                            deltas.Add(track.Key, trkDeltas);
                            for (int i = 0; i < trkPoints.Length; i++)
                            {

                                trkDeltas[i] = DegToMeters(meanLonDeg, meanLatDeg, trkPoints[i].X, trkPoints[i].Y);
                                if (Math.Abs(trkDeltas[i].X) > farestXDelta) farestXDelta = Math.Abs(trkDeltas[i].X);
                                if (Math.Abs(trkDeltas[i].Y) > farestYDelta) farestYDelta = Math.Abs(trkDeltas[i].Y);
                            }
                        }
                    }

                    float farestDistM = (float)(Math.Max(farestXDelta, farestYDelta) * 1.1);
                    if (farestDistM < float.Epsilon)
                        farestDistM = 0.000001f;
                    else
                    {
                        float farestDistStepM = Convert.ToSingle(Utils.FitAxisStepByRange((Math.Max(farestXDelta, farestYDelta) * 1.1)));
                        farestDistM = farestDistStepM * Convert.ToSingle(Math.Ceiling(farestDistM / farestDistStepM));
                    }

                    float xScale = this.Width / (farestDistM * 2.0f);
                    float yScale = this.Height / (farestDistM * 2.0f);
                    float scale = (float)Math.Min(xScale, yScale);

                    float fDist = Math.Abs((float)farestDistM * 0.75f);
                    float fDistScaled = (float)(fDist * scale);                                         
              
                    e.Graphics.DrawLine(gridPen, -fDistScaled, -4, -fDistScaled, 4);
                    e.Graphics.DrawLine(gridPen, fDistScaled, -4, fDistScaled, 4);
                    e.Graphics.DrawLine(gridPen, -4, -fDistScaled, 4, -fDistScaled);
                    e.Graphics.DrawLine(gridPen, -4, fDistScaled, 4, fDistScaled);                    

                    var fDistMLbl = string.Format(CultureInfo.InvariantCulture, "{0:F01} m", fDist);  
                    var fDistMLblSize = e.Graphics.MeasureString(fDistMLbl, axisLblFnt);

                    e.Graphics.DrawString(fDistMLbl, axisLblFnt, axisLblBrs,
                        -fDistScaled - fDistMLblSize.Width / 2, -fDistMLblSize.Height - 2);

                    e.Graphics.DrawString(fDistMLbl, axisLblFnt, axisLblBrs,
                        fDistScaled - fDistMLblSize.Width / 2, -fDistMLblSize.Height - 2);

                    e.Graphics.DrawString(fDistMLbl, axisLblFnt, axisLblBrs,
                        -fDistMLblSize.Width, -fDistScaled - fDistMLblSize.Height / 2);

                    e.Graphics.DrawString(fDistMLbl, axisLblFnt, axisLblBrs,
                        -fDistMLblSize.Width, fDistScaled - fDistMLblSize.Height / 2);

                    float minDim = this.Height;
                    if (minDim > this.Width)
                        minDim = this.Width;
                   
                    float left = -minDim / 2.0f;
                    float right = minDim / 2.0f;
                    float top = -minDim / 2.0f;
                    float bottom = minDim / 2.0f;

                    var lblSize = e.Graphics.MeasureString(northSign, miscInfoFnt);
                    e.Graphics.DrawString(northSign, miscInfoFnt, Brushes.Cyan,
                        -lblSize.Width / 2, -this.Height / 2);   

                    e.Graphics.DrawLine(gridPen, left, 0.0f, right, 0.0f);
                    e.Graphics.DrawLine(gridPen, 0.0f, top + lblSize.Height, 0.0f, bottom - hLinesHeight);
                    
                    float xToDraw;
                    float yToDraw;

                    foreach (var track in deltas)
                    {
                        float pSize = trackPenSizes[track.Key];

                        for (int i = 0; i < track.Value.Length; i++)
                        {
                            yToDraw = track.Value[i].X * scale;
                            xToDraw = -track.Value[i].Y * scale;

                            if (i == 0)
                            {
                                if (latestPointMarks[track.Key])
                                {
                                    e.Graphics.DrawRectangle(trackPens[track.Key],
                                                             xToDraw - pSize * 2,
                                                             yToDraw - pSize * 2,
                                                             pSize * 4,
                                                             pSize * 4);

                                    e.Graphics.FillRectangle(trackPens[track.Key].Brush,
                                                             xToDraw - pSize * 2,
                                                             yToDraw - pSize * 2,
                                                             pSize * 4,
                                                             pSize * 4);
                                }
                                else
                                {
                                    e.Graphics.DrawRectangle(trackPens[track.Key],
                                                         xToDraw - pSize,
                                                         yToDraw - pSize,
                                                         pSize * 2,
                                                         pSize * 2);
                                }

                                if (!float.IsNaN(course[track.Key]))
                                {
                                    float crsEndPointX;
                                    float crsEndPointY;

                                    crsEndPointX = xToDraw + Convert.ToSingle(courseLineLength * Math.Cos(course[track.Key]));
                                    crsEndPointY = yToDraw + Convert.ToSingle(courseLineLength * Math.Sin(course[track.Key]));

                                    coursePen.Color = trackColors[track.Key];
                                    e.Graphics.DrawLine(coursePen, xToDraw, yToDraw, crsEndPointX, crsEndPointY);
                                }
                            }
                            else
                            {
                                e.Graphics.DrawRectangle(trackPens[track.Key],
                                                         xToDraw - pSize,
                                                         yToDraw - pSize,
                                                         pSize * 2,
                                                         pSize * 2);                                
                            }
                        }                        
                    }                    
                }

                #endregion

                #region draw additional info

                if (!string.IsNullOrEmpty(leftUpperCornerText))
                {
                    e.Graphics.DrawString(leftUpperCornerText, miscInfoFnt, miscInfoBrs, -this.Width / 2 + borderGap, -this.Height / 2 + borderGap);                
                }

                #endregion

                #region draw legend

                var legendLblSize = e.Graphics.MeasureString(legendLbl, miscInfoFnt);
                e.Graphics.DrawString(legendLbl, miscInfoFnt, miscInfoBrs, this.Width / 2 - borderGap - legendLblSize.Width, -this.Height / 2 + borderGap);

                float delta = legendLblSize.Height / tracks.Count;

                int cnt = 0;
                foreach (var trk in tracks)
                {
                    float pSize = trackPenSizes[trk.Key];
                    float xToDraw = this.Width / 2 - borderGap - legendLblSize.Width - borderGap * 3;
                    float yToDraw = -this.Height / 2 + borderGap + delta * cnt + delta / 2;
                    cnt++;

                    e.Graphics.DrawRectangle(trackPens[trk.Key],
                                                       xToDraw - pSize,
                                                       yToDraw - pSize,
                                                       pSize * 2,
                                                       pSize * 2);

                    e.Graphics.FillRectangle(trackPens[trk.Key].Brush,
                                             xToDraw - pSize,
                                             yToDraw - pSize,
                                             pSize * 2,
                                             pSize * 2);

                }

                #endregion                
            }
        }

        private void MarinePlot_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void MarinePlot_MouseClick(object sender, MouseEventArgs e)
        {
            /// TODO:
        }

        private void MarinePlot_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            /// TODO:
        }

        private void MarinePlot_MouseMove(object sender, MouseEventArgs e)
        {
            /// TODO:
        }

        private void GeoPlotCartesian_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        #endregion        
    }

}
