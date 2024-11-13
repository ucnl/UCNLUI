using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;
using UCNLNav;

namespace UCNLUI.Controls
{
    public partial class RadialPlot : UserControl
    {
        #region Properties

        public static readonly Color DefaultBackgoundColor = Color.Black;

        public static readonly Color DefaultAxisBackgroundLabelColor = Color.Black;
        public static readonly Color DefaultAxisColor = Color.LightGray;
        public static readonly Color DefaultAxisLabelColor = Color.LightGray;

        public static readonly Color DefaultBoatColor = Color.Yellow;
        public static readonly int   DefaultBoatSizePx = 16;

        public static readonly Color DefaultHistoryTextColor = Color.SpringGreen;

        public static readonly Color DefaultRightUpperTextColor = Color.PowderBlue;
        public static readonly Color DefaultRightUpperTextBackGroundColor = Color.Black;

        public static readonly Color DefaultLeftUpperTextColor = Color.GreenYellow;
        public static readonly Color DefaultLeftUpperTextBackGroundColor = Color.Black;

        public static readonly Color DefaultLimboColor = Color.LightSeaGreen;
        public static readonly int   DefaultLimboThicknessPx = 10;
        public static readonly int   DefaultLimboTickAngleStep = 15;
        public static readonly Color DefaultLimboTickColor = Color.LightGray;
        public static readonly int   DefaultLimboTickThicknessPx = 10;

        public static readonly Color DefaultTargetCircleColor = Color.Goldenrod;
        public static readonly Color DefaultTargetDistLineColor = Color.Gold;
        public static readonly Color DefaultTargetLabelColor = Color.Black;
        public static readonly Color DefaultTargetLabelBackgoundColor = Color.Yellow;

        #region  Left-upper corner text

        public bool LeftUpperTextVisible { get; set; }

        public string LeftUpperText { get; set; }

        public Font LeftUpperTextFont { get; set; }

        Brush leftUpperTextBrush = new SolidBrush(DefaultLeftUpperTextColor);
        Color leftUpperTextColor = DefaultLeftUpperTextColor;

        public Color LeftUpperTextColor
        {
            get { return leftUpperTextColor; }
            set
            {
                leftUpperTextColor = value;
                leftUpperTextBrush = new SolidBrush(leftUpperTextColor);
            }
        }

        #endregion

        #region History

        public bool HistoryVisible { get; set; }

        FixedSizeLIFO<string> history;
        string[] historyLines;

        public Font HistoryTextFont { get; set; }
        public Color HistoryTextColor { get; set; }

        int historyLinesNumber = 4;
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

        #endregion

        #region Right-upper corner text

        public bool RightUpperTextVisible { get; set; }

        AgingValue<string> rightUpperText;

        public void RightUpperTextSet(string text)
        {
            rightUpperText.Value = text;
        }
           

        public Font RightUpperTextFont { get; set; }

        Brush rightUpperTextBrush = new SolidBrush(DefaultRightUpperTextColor);
        Color rightUpperTextColor = DefaultRightUpperTextColor;

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

        #region Targets

        public Font TargetLabelFont { get; set; }

        Brush targetLabelBrush = new SolidBrush(DefaultTargetLabelColor);
        Color targetLabelColor = DefaultTargetLabelColor;

        public Color TargetLabelColor
        {
            get { return targetLabelColor; }
            set
            {
                targetLabelColor = value;
                targetLabelBrush = new SolidBrush(targetLabelColor);
            }
        }

        Color targetDistLineColor = DefaultTargetDistLineColor;
        public Color TargetDistLineColor
        {
            get { return targetDistLineColor; }
            set
            {
                targetDistLineColor = value;
                targetDistLinePen = new Pen(targetDistLineColor, 1.0f);
            }
        }

        Color targetCircleColor = DefaultTargetCircleColor;
        public Color TargetCircleColor
        {
            get { return targetCircleColor; }
            set
            {
                targetCircleColor = value;
                targetCirclePen = new Pen(targetCircleColor, 1.0f);
            }
        }

        Color targetLabelBkColor = DefaultTargetLabelBackgoundColor;
        public Color TargetLabelBackgroundColor
        {
            get { return targetLabelBkColor; }
            set
            {
                targetLabelBkColor = value;
                targetLabelTextBkBrush = new SolidBrush(targetLabelBkColor);
            }
        }

        Brush targetLabelTextBkBrush = new SolidBrush(DefaultTargetLabelBackgoundColor);

        Pen targetDistLinePen = new Pen(DefaultTargetDistLineColor, 1.0f);
        Pen targetCirclePen = new Pen(DefaultTargetCircleColor, 1.0f);

        #endregion

        #region Axis

        Color axisColor = DefaultAxisColor;
        public Color AxisColor
        {
            get { return axisColor; }
            set
            {
                axisColor = value;
                axisPen = new Pen(axisColor, 1.0f);
            }
        }

        Pen axisPen = new Pen(DefaultAxisColor, 1.0f);

        public Font AxisLabelFont { get; set; }

        Brush axisLblBrush = new SolidBrush(DefaultAxisLabelColor);
        Color axisLblColor = DefaultAxisLabelColor;

        public Color AxisLabelColor
        {
            get { return axisLblColor; }
            set
            {
                axisLblColor = value;
                axisLblBrush = new SolidBrush(axisLblColor);
            }
        }

        Brush axisBkLblBrush = new SolidBrush(DefaultAxisBackgroundLabelColor);
        Color axisBkLblColor = DefaultAxisBackgroundLabelColor;

        public Color AxisBackgroundLabelColor
        {
            get { return axisBkLblColor; }
            set
            {
                axisBkLblColor = value;
                axisBkLblBrush = new SolidBrush(axisBkLblColor);
            }
        }

        #endregion

        #region Limbo

        public bool LimboVisible { get; set; }

        float limboTickAngleStep = DefaultLimboTickAngleStep;
        public float LimboTickAngleStep
        {
            get { return limboTickAngleStep; }
            set { limboTickAngleStep = value; }
        }

        int limboThickness = DefaultLimboThicknessPx;
        public int LimboThickness
        {
            get { return limboThickness; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("value");

                limboThickness = value;
                limboPen = new Pen(limboColor, limboThickness);
            }
        }

        Color limboColor = DefaultLimboColor;
        public Color LimboColor
        {
            get { return limboColor; }
            set
            {
                limboColor = value;
                limboPen = new Pen(limboColor, limboThickness);
            }
        }

        Pen limboPen = new Pen(DefaultLimboColor, DefaultLimboThicknessPx);

        LineCap limboTickCap = LineCap.Flat;
        public LineCap LimboTickCap
        {
            get { return limboTickCap; }
            set
            {
                limboTickCap = value;
                limboTickPen = new Pen(limboTickColor, limboTickThickness);
                limboTickPen.StartCap = limboTickCap;
            }
        }

        Color limboTickColor = DefaultLimboTickColor;
        public Color LimboTickColor
        {
            get { return limboTickColor; }
            set
            {
                limboTickColor = value;
                limboTickPen = new Pen(limboTickColor, limboTickThickness);
                limboTickPen.StartCap = limboTickCap;
            }
        }

        int limboTickThickness = DefaultLimboTickThicknessPx;
        public int LimboTickThickness
        {
            get { return limboTickThickness; }
            set
            {
                limboTickThickness = value;
                limboTickPen = new Pen(limboTickColor, limboTickThickness);
                limboTickPen.StartCap = limboTickCap;
            }
        }

        Pen limboTickPen = new Pen(DefaultLimboTickColor, DefaultLimboTickThicknessPx);

        #endregion

        #region Left upper Text custom background

        Color leftUpperTextBkColor = DefaultLeftUpperTextBackGroundColor;
        public Color LeftUpperTextBackgoundColor
        {
            get { return leftUpperTextBkColor; }
            set
            {
                leftUpperTextBkColor = value;
                leftUpperTextBkBrush = new SolidBrush(leftUpperTextBkColor);
            }
        }

        Brush leftUpperTextBkBrush = new SolidBrush(DefaultLeftUpperTextBackGroundColor);

        #endregion

        #region Right upper Text custom background

        Color rightUpperTextBkColor = DefaultRightUpperTextBackGroundColor;
        public Color RightUpperTextBackgoundColor
        {
            get { return rightUpperTextBkColor; }
            set
            {
                rightUpperTextBkColor = value;
                rightUpperTextBkBrush = new SolidBrush(rightUpperTextBkColor);
            }
        }

        Brush rightUpperTextBkBrush = new SolidBrush(DefaultLeftUpperTextBackGroundColor);

        #endregion

        #region Boat

        public bool BoatVisible { get; set; }

        int boatSize = DefaultBoatSizePx;
        public int BoatSize
        {
            get { return boatSize; }
            set
            {
                boatSize = value;
                boatPen = new Pen(boatColor, boatSize);
                boatPen.EndCap = LineCap.Triangle;
            }
        }

        Color boatColor = DefaultBoatColor;
        public Color BoatColor
        {
            get { return boatColor; }
            set
            {
                boatColor = value;
                boatPen = new Pen(boatColor, boatSize);
                boatPen.EndCap = LineCap.Triangle;
            }
        }

        Pen boatPen = new Pen(DefaultBoatColor, DefaultBoatSizePx);

        #endregion

        StringFormat tFormat;
        Dictionary<string, RadialPlotDrawTarget> targets;

        double heading = double.NaN;
        public double Heading
        {
            get { return heading; }
            set
            {
                if (double.IsNaN(value) || ((value >= 0) && (value <= 360)))
                    heading = value;
                else
                    throw new ArgumentOutOfRangeException("value");
            }
        }

        #endregion

        #region Constructor

        public RadialPlot()
        {
            InitializeComponent();

            #region Misc. handlers

            this.Resize += (o, e) => this.Invalidate();

            /*
            this.MouseClick += (o, e) =>
                {
                    throw new NotImplementedException();
                };

            this.MouseMove += (o, e) =>
                {
                    throw new NotImplementedException();
                };
             */

            #endregion

            #region Drawing stuff

            HistoryTextColor = DefaultHistoryTextColor;

            RightUpperTextColor = DefaultRightUpperTextColor;

            rightUpperText = new AgingValue<string>(3, 255, x => x);

            if (LeftUpperTextFont == null)
                LeftUpperTextFont = this.Font;

            if (RightUpperTextFont == null)
                RightUpperTextFont = this.Font;

            if (HistoryTextFont == null)
                HistoryTextFont = this.Font;

            if (AxisLabelFont == null)
                AxisLabelFont = this.Font;

            if (TargetLabelFont == null)
                TargetLabelFont = this.Font;

            tFormat = new StringFormat();
            tFormat.LineAlignment = StringAlignment.Center;
            tFormat.Alignment = StringAlignment.Center;

            boatPen.EndCap = LineCap.Triangle;

            #endregion
            

            targets = new Dictionary<string, RadialPlotDrawTarget>();
        }

        #endregion

        #region Handlers
        
        private void RadPlot_Paint(object sender, PaintEventArgs e)
        {
            if (e.ClipRectangle.IsEmpty)
                return;

            #region Init

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            float width = this.Width - this.Padding.Left - this.Padding.Right;
            float height = this.Height - this.Padding.Top - this.Padding.Bottom;

            e.Graphics.TranslateTransform(width / 2.0f + this.Padding.Left, height / 2.0f + this.Padding.Top);

            #endregion

            #region find maximum distance, axis step and scale

            float maxDistance = 1.0f;
            foreach (var target in targets)
            {
                if (target.Value.Distance > maxDistance)
                    maxDistance = target.Value.Distance;
            }

            float axisStep = Convert.ToSingle(Utils.FitAxisStepByRange(maxDistance));
            float maxDimension = Math.Min(width, height) / 2;

            float scale = maxDimension / maxDistance;

            #endregion

            #region Draw axis

            e.Graphics.DrawLine(axisPen, 0, -maxDimension, 0, maxDimension);
            e.Graphics.DrawLine(axisPen, -maxDimension, 0, maxDimension, 0);

            //string radiusFStr = maxDistance <= 1.0f ? "F01" : "F00";
            string radiusFStr = axisStep <= 1.0f ? "F01" : "F00";

            float radius = axisStep;
            while (radius < maxDistance)
            {
                float rS = radius * scale;
                e.Graphics.DrawEllipse(axisPen, -rS, -rS, rS * 2, rS * 2);

                var lblStr = radius.ToString(radiusFStr, CultureInfo.InvariantCulture);
                var lblSize = e.Graphics.MeasureString(lblStr, AxisLabelFont);

                e.Graphics.FillRectangle(axisBkLblBrush, -lblSize.Width / 2, -rS - lblSize.Height, lblSize.Width, lblSize.Height);
                e.Graphics.DrawString(lblStr, AxisLabelFont, axisLblBrush, -lblSize.Width / 2, -rS - lblSize.Height);

                radius += axisStep;
            }            

            #endregion

            if (LimboVisible)
            {
                #region Draw limbo

                e.Graphics.DrawEllipse(limboPen, -maxDimension, -maxDimension, maxDimension * 2, maxDimension * 2);

                int startDegree = 0;

                float degree = startDegree;
                while (degree < 360.0f)
                {
                    float rd = (float)((degree - 90) * Math.PI / 180.0);
                    float x1 = (float)((maxDimension - limboThickness / 2) * Math.Cos(rd));
                    float y1 = (float)((maxDimension - limboThickness / 2) * Math.Sin(rd));
                    float x2 = (float)((maxDimension + limboThickness / 2) * Math.Cos(rd));
                    float y2 = (float)((maxDimension + limboThickness / 2) * Math.Sin(rd));

                    e.Graphics.DrawLine(limboTickPen, x1, y1, x2, y2);
                    degree += limboTickAngleStep;
                }

                #endregion
            }
            else
            {
                #region Draw outer circle with label

                float rS = maxDistance * scale;
                e.Graphics.DrawEllipse(axisPen, -rS, -rS, rS * 2, rS * 2);

                var lblStr = maxDistance.ToString(radiusFStr, CultureInfo.InvariantCulture);
                var lblSize = e.Graphics.MeasureString(lblStr, AxisLabelFont);

                e.Graphics.FillRectangle(axisBkLblBrush, -lblSize.Width / 2, -rS - lblSize.Height, lblSize.Width, lblSize.Height);
                e.Graphics.DrawString(lblStr, AxisLabelFont, axisLblBrush, -lblSize.Width / 2, -rS - lblSize.Height);

                #endregion
            }

            #region Draw targets

            float tx, ty;

            foreach (var item in targets.Values)
            {
                if (item.Distance < 0)
                    radius = scale;
                else
                    radius = item.Distance * scale;

                tx = radius * (float)(Math.Cos((item.Azimuth - 90.0) * Math.PI / 180));
                ty = radius * (float)(Math.Sin((item.Azimuth - 90.0) * Math.PI / 180));

                var tLbl = item.ID.ToString();
                var tLblSize = e.Graphics.MeasureString(tLbl, TargetLabelFont);
                var tLblMSize = Math.Max(tLblSize.Width, tLblSize.Height);

                var tR = new RectangleF(tx - tLblMSize / 2, ty - tLblMSize / 2, tLblMSize, tLblMSize);

                if (item.IsTimeout)
                {
                    targetDistLinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    targetCirclePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                }
                else
                {
                    targetDistLinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                    targetCirclePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                }

                e.Graphics.DrawLine(targetDistLinePen, 0, 0, tx, ty);
                e.Graphics.DrawEllipse(targetCirclePen, tR);
                e.Graphics.FillEllipse(targetLabelTextBkBrush, tR);
                e.Graphics.DrawString(tLbl, TargetLabelFont, targetLabelBrush, tR, tFormat);
            }

            #endregion
            
            if (HistoryVisible)
            {
                #region Draw history lines

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

                #endregion
            }
            
            if (LeftUpperTextVisible && !string.IsNullOrEmpty(LeftUpperText))
            {
                #region Draw left upper corner text

                PointF luTextPos = new PointF(-this.Width / 2 + this.Padding.Left, -this.Height / 2 + this.Padding.Top);
                var luTextSize = e.Graphics.MeasureString(LeftUpperText, LeftUpperTextFont);
                if (leftUpperTextBkColor != Color.Empty)
                    e.Graphics.FillRectangle(leftUpperTextBkBrush, luTextPos.X, luTextPos.Y, luTextSize.Width, luTextSize.Height);

                e.Graphics.DrawString(LeftUpperText, LeftUpperTextFont, leftUpperTextBrush, luTextPos);

                #endregion
            }

            if (RightUpperTextVisible && rightUpperText.IsInitialized)
            {
                #region Draw right-upper text

                byte alpha = Age2Alpha(rightUpperText.Age.TotalSeconds, rightUpperText.ObsoleteIntervalSec);

                var str = rightUpperText.ToString();
                var ruTextSize = e.Graphics.MeasureString(str, RightUpperTextFont);
                PointF ruTextPos = new PointF(this.Width / 2 - this.Padding.Right - ruTextSize.Width, -this.Height / 2 + this.Padding.Top);                
                if (rightUpperTextBkColor != Color.Empty)
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(alpha, rightUpperTextBkColor)), ruTextPos.X, ruTextPos.Y, ruTextSize.Width, ruTextSize.Height);

                e.Graphics.DrawString(str, RightUpperTextFont, new SolidBrush(Color.FromArgb(alpha, rightUpperTextColor)), ruTextPos);

                #endregion
            }

            #region Draw N-sign

            if (!double.IsNaN(heading))
            {
                string northSign = "N";
                var nsignSize = e.Graphics.MeasureString(northSign, this.Font);
                e.Graphics.DrawString(northSign, this.Font, Brushes.Yellow, -nsignSize.Width / 2, -height / 2);
            }

            #endregion

            if (BoatVisible)
            {
                #region Draw boat

                float hdn = double.IsNaN(heading) ? 90 : (float)heading + 90;

                float cv = (float)Math.Sin(hdn * Math.PI / 180.0);
                float sv = (float)Math.Cos(hdn * Math.PI / 180.0);
                float xBs = sv * boatSize / 2;
                float yBs = cv * boatSize / 2;
                float xBe = -sv * boatSize / 2;
                float yBe = -cv * boatSize / 2;

                e.Graphics.DrawLine(boatPen, xBs, yBs, xBe, yBe);

                #endregion
            }
        }

        #endregion

        #region Methods

        #region Private

        private byte Age2Alpha(double age_sec, double obs_int_sec)
        {
            double age = age_sec > obs_int_sec ? obs_int_sec : age_sec;
            int alpha = 5 + Convert.ToInt32(250.0 * (obs_int_sec - age) / obs_int_sec);
            return Convert.ToByte(alpha);
        }

        #endregion

        public void SetTarget(string id, double distance, double azimuth, bool isTimeout)
        {
            if (!targets.ContainsKey(id))
                targets.Add(id, new RadialPlotDrawTarget());

            targets[id].ID = id;
            targets[id].Distance = Convert.ToSingle(distance);
            targets[id].Azimuth = Convert.ToSingle(azimuth);
            targets[id].IsTimeout = isTimeout;
        }

        public void AppendHistoryLine(string text)
        {
            history.Add(text.Replace("\r\n", " "));
            historyLines = history.ToArray();
        }

        #endregion
    }
}
