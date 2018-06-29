using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UCNLSalinity;

namespace UCNLUI.Dialogs
{
    public partial class SalinityDialog : Form
    {
        #region Properties

        public string Title
        {
            get
            {
                return this.Text;
            }
            set
            {
                this.Text = value;
            }
        }

        public string LatCaption
        {
            get
            {
                return latCaptionLbl.Text;
            }
            set
            {
                latCaptionLbl.Text = value;
            }
        }

        public string LonCaption
        {
            get
            {
                return LonCaptionLbl.Text;
            }
            set
            {
                LonCaptionLbl.Text = value;
            }
        }

        public string SalinityCaption
        {
            get
            {
                return salinityCaptionLbl.Text;
            }
            set
            {
                salinityCaptionLbl.Text = value;
            }
        }

        public string SalinityDefCaption
        {
            get
            {
                return salinityLabel.Text;
            }
            set
            {
                salinityLabel.Text = value;
            }
        }

        public string SearchBtnCaption
        {
            get
            {
                return searchBtn.Text;
            }
            set
            {
                searchBtn.Text = value;
            }
        }

        public string ErrorConnetingDBMsg { get; set; }
        public string NearestPntMsg { get; set; }

        public double Lat
        {
            get
            {
                return Convert.ToDouble(latEdit.Value);
            }
            set
            {
                latEdit.Value = Convert.ToDecimal(value);
            }
        }

        public double Lon
        {
            get
            {
                return Convert.ToDouble(lonEdit.Value);
            }
            set
            {
                lonEdit.Value = Convert.ToDecimal(value);
            }
        }

        Dictionary<int, string> ns = new Dictionary<int, string>() { { 1, "N" }, { -1, "S" } };
        Dictionary<int, string> ew = new Dictionary<int, string>() { { 1, "E" }, { -1, "W" } };

        double salinity = 0;
        public double Salinity
        {
            get
            {
                return salinity;
            }
        }

        WWSalinityProvider wws;
        static bool isWWSInitialized = false;

        #endregion

        #region Constructor

        public SalinityDialog()
        {
            InitializeComponent();

            ErrorConnetingDBMsg = "Error connecting to database";
            NearestPntMsg = "the nearest point is";
        }

        #endregion        
        
        #region Handlers

        private void SalinityDialog_Shown(object sender, EventArgs e)
        {
            isWWSInitialized = false;
        }

        private void latEdit_ValueChanged(object sender, EventArgs e)
        {
            okBtn.Enabled = false;
            latLbl.Text = string.Format("{0:F01}° {1}", Math.Abs(Lat), ns[(int)(Lat / Math.Abs(Lat))]);
        }

        private void lonEdit_ValueChanged(object sender, EventArgs e)
        {
            okBtn.Enabled = false;
            lonLbl.Text = string.Format("{0:F01}° {1}", Math.Abs(Lon), ew[(int)(Lon / Math.Abs(Lon))]);
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isWWSInitialized)
                {
                    wws = new WWSalinityProvider("WWSalinity.xml");
                    isWWSInitialized = true;
                }

                double nlat = 0;
                double nlon = 0;
                salinity = wws.GetNearestSalinity(Lat, Lon, out nlat, out nlon);
                salinityLabel.Text = string.Format("{0}, {1} {2:F01}° {3:F01}°", salinity, NearestPntMsg, nlat, nlon);

                okBtn.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorConnetingDBMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        #endregion               

        private void SalinityDialog_Load(object sender, EventArgs e)
        {

        }

        private void latCaptionLbl_Click(object sender, EventArgs e)
        {

        }

        private void LonCaptionLbl_Click(object sender, EventArgs e)
        {

        }

        private void latLbl_Click(object sender, EventArgs e)
        {

        }

        private void lonLbl_Click(object sender, EventArgs e)
        {

        }

        private void salinityCaptionLbl_Click(object sender, EventArgs e)
        {

        }

        private void okBtn_Click(object sender, EventArgs e)
        {

        }

        private void salinityLabel_Click(object sender, EventArgs e)
        {

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
