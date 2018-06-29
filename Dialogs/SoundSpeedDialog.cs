using System;
using System.Windows.Forms;
using UCNLSalinity;

namespace UCNLUI.Dialogs
{
    public partial class SoundSpeedDialog : Form
    {
        public enum presets : int
        {
            freshWater = 0,
            seaWater = 1,
            directMeasurement = 2,
            unknown
        }

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

        public presets Preset
        {
            get
            {
                return (presets)Enum.ToObject(typeof(presets), preConfigCbx.SelectedIndex);
            }
            set
            {
                preConfigCbx.SelectedIndex = (int)value;
            }
        }

        public double Temperature
        {
            get
            {
                return Convert.ToDouble(tempEdit.Value);
            }
            set
            {
                tempEdit.Value = Convert.ToDecimal(value);                
            }
        }

        public double Pressure
        {
            get
            {
                return Convert.ToDouble(pressureEdit.Value);
            }
            set
            {
                pressureEdit.Value = Convert.ToDecimal(value);                
            }
        }

        public double Salinity
        {
            get
            {
                return Convert.ToDouble(salinityEdit.Value);
            }
            set
            {
                salinityEdit.Value = Convert.ToDecimal(value);                
            }

        }

        public double SpeedOfSound
        {
            get
            {
                return Convert.ToDouble(soundSpeedEdit.Value);
            }
            set
            {
                soundSpeedEdit.Value = Convert.ToDecimal(value);
            }
        }

        #endregion

        #region Constructor

        public SoundSpeedDialog()
        {
            InitializeComponent();
            preConfigCbx.SelectedIndex = 0;
        }

        #endregion

        #region Handlers

        private void preConfigCbx_SelectedIndexChanged(object sender, EventArgs e)
        {            
            SwitchPresets();
            UpdateSpeedOfSoundValue();
        }

        private void tempEdit_ValueChanged(object sender, EventArgs e)
        {
            UpdateSpeedOfSoundValue();
        }

        private void pressureEdit_ValueChanged(object sender, EventArgs e)
        {
            UpdateSpeedOfSoundValue();
        }

        private void salinityEdit_ValueChanged(object sender, EventArgs e)
        {
            UpdateSpeedOfSoundValue();
        }

        private void getFromBaseBtn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (SalinityDialog sDialog = new SalinityDialog())
            {
                sDialog.Title = "Choose the location...";
                if (sDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Salinity = sDialog.Salinity;
                    UpdateSpeedOfSoundValue();
                }
            }
        }

        #endregion

        #region Methods

        private void SwitchPresets()
        {
            switch (Preset)
            {
                case presets.freshWater:
                    {
                        // fresh water         
                        Salinity = 0.5;
                        Pressure = 0.1;
                        tempEdit.Enabled = true;
                        pressureEdit.Enabled = false;
                        salinityEdit.Enabled = false;
                        getFromBaseBtn.Enabled = false;
                        soundSpeedEdit.ReadOnly = true;

                        break;
                    }
                case presets.seaWater:
                    {
                        // sea water
                        //Salinity = 35;
                        //Pressure = 0.1;                       
                        tempEdit.Enabled = true;
                        pressureEdit.Enabled = true;
                        salinityEdit.Enabled = true;
                        getFromBaseBtn.Enabled = true;
                        soundSpeedEdit.ReadOnly = true;

                        break;
                    }
                case presets.directMeasurement:
                    {
                        // direct measurement
                        tempEdit.Enabled = false;
                        pressureEdit.Enabled = false;
                        salinityEdit.Enabled = false;
                        getFromBaseBtn.Enabled = false;
                        soundSpeedEdit.ReadOnly = false;

                        break;
                    }
            }            
        }

        private void UpdateSpeedOfSoundValue()
        {
            if (Preset != presets.directMeasurement)
            {
                SpeedOfSound = SaltWaterSoSProvider.CalcSoundSpeed(Temperature, Pressure, Salinity);
            }
        }

        #endregion                
    }
}
