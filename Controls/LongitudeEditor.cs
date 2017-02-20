using System;
using System.Windows.Forms;

namespace UCNLUI.Controls
{
    public partial class LongitudeEditor : UserControl
    {
        #region Properties

        public double Angle
        {
            get
            {
                return GetAngle();
            }
            set
            {
                if ((value >= -180.0) && (value <= 180))
                    SetAngle(value);
                else
                {
                    throw new ArgumentOutOfRangeException("Angle");
                }
            }
        }

        public string StringRepresentation
        {
            get
            {
                return resultString.Text;
            }
        }

        public double Degrees
        {
            get
            {
                return Convert.ToDouble(degreeNumericEdit.Value);
            }
        }

        public double Minutes
        {
            get
            {
                return Convert.ToDouble(minutesNumericEdit.Value);
            }
        }

        public double Seconds
        {
            get
            {
                return Convert.ToDouble(secondsNumericEdit.Value);
            }
        }

        #endregion

        #region Constructor

        public LongitudeEditor()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private double GetAngle()
        {
            double degrees = Convert.ToDouble(degreeNumericEdit.Value);
            double minutes = Convert.ToDouble(minutesNumericEdit.Value);
            double seconds = Convert.ToDouble(secondsNumericEdit.Value);

            return degrees + minutes / 60.0 + seconds / 3600.0;
        }

        private void SetAngle(double angle)
        {
            double degrees = Math.Floor(angle);
            double minutes = Math.Floor((angle - degrees) * 60.0);
            double seconds = (angle - degrees) * 3600 - minutes * 60.0;

            degreeNumericEdit.Value = Convert.ToDecimal(degrees);
            minutesNumericEdit.Value = Convert.ToDecimal(minutes);
            secondsNumericEdit.Value = Convert.ToDecimal(seconds);
        }

        private void UpDateString()
        {
            string temp = "/ " +
                Math.Abs(Degrees).ToString("F00") + "° " +
                Minutes.ToString("F00") + "' " +
                Seconds.ToString("F02") + "\" ";

            if (Degrees >= 0)
                temp += "E";
            else
                temp += "W";

            resultString.Text = temp;
        }

        #endregion

        private void degreeNumericEdit_ValueChanged(object sender, EventArgs e)
        {
            UpDateString();
        }

        private void minutesNumericEdit_ValueChanged(object sender, EventArgs e)
        {
            if (Minutes != 0.0)
            {
                degreeNumericEdit.Maximum = 179;
                degreeNumericEdit.Minimum = -179;
            }
            else
            {
                if (Seconds == 0.0)
                {
                    degreeNumericEdit.Maximum = 180;
                    degreeNumericEdit.Minimum = -180;
                }
            }

            UpDateString();
        }

        private void secondsNumericEdit_ValueChanged(object sender, EventArgs e)
        {
            if (Seconds != 0.0)
            {
                degreeNumericEdit.Maximum = 179;
                degreeNumericEdit.Minimum = -179;
            }
            else
            {
                if (Minutes == 0.0)
                {
                    degreeNumericEdit.Maximum = 180;
                    degreeNumericEdit.Minimum = -180;
                }
            }

            UpDateString();
        }

        #region Events

        #endregion
    }
}
