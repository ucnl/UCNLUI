using System;
using System.IO.Ports;
using System.Windows.Forms;
using UCNLDrivers;

namespace UCNLUI.Controls
{      
    public partial class SerialPortSettingsEdit : UserControl
    {
        #region Properties
        
        public SerialPortSettings PortSettings
        {
            get
            {
                return GetSettingsFromControls();
            }
            set
            {
                ApplaySettingsToControls(value);
            }
        }

        #endregion

        #region Constructor

        public SerialPortSettingsEdit()
        {
            InitializeComponent();
            InitControls();
        }

        #endregion

        #region Methods

        private SerialPortSettings GetSettingsFromControls()
        {
            SerialPortSettings result = new SerialPortSettings();

            if (portNameCombo.SelectedIndex >= 0)
                result.PortName = portNameCombo.SelectedItem.ToString();

            if (baudrateCombo.SelectedIndex >= 0)
                result.PortBaudRate = (BaudRate)Enum.Parse(typeof(BaudRate), baudrateCombo.SelectedItem.ToString());

            if (databitsCombo.SelectedIndex >= 0)
                result.PortDataBits = (DataBits)Enum.Parse(typeof(DataBits), databitsCombo.SelectedItem.ToString());

            if (stopbitsCombo.SelectedIndex >= 0)
                result.PortStopBits = (StopBits)Enum.Parse(typeof(StopBits), stopbitsCombo.SelectedItem.ToString());

            if (parityCombo.SelectedIndex >= 0)
                result.PortParity = (Parity)Enum.Parse(typeof(Parity), parityCombo.SelectedItem.ToString());

            if (handshakeCombo.SelectedIndex >= 0)
                result.PortHandshake = (Handshake)Enum.Parse(typeof(Handshake), handshakeCombo.SelectedItem.ToString());

            return result;
        }

        private void ApplaySettingsToControls(SerialPortSettings newSettings)
        {
            int index;

            if (newSettings == null)
                newSettings = new SerialPortSettings();

            index = portNameCombo.Items.IndexOf(newSettings.PortName);
            if (index >= 0)
                portNameCombo.SelectedIndex = index;

            index = baudrateCombo.Items.IndexOf(newSettings.PortBaudRate.ToString());
            if (index >= 0)
                baudrateCombo.SelectedIndex = index;

            index = databitsCombo.Items.IndexOf(newSettings.PortDataBits.ToString());
            if (index >= 0)
                databitsCombo.SelectedIndex = index;

            index = stopbitsCombo.Items.IndexOf(newSettings.PortStopBits.ToString());
            if (index >= 0)
                stopbitsCombo.SelectedIndex = index;

            index = parityCombo.Items.IndexOf(newSettings.PortParity.ToString());
            if (index >= 0)
                parityCombo.SelectedIndex = index;

            index = handshakeCombo.Items.IndexOf(newSettings.PortHandshake.ToString());
            if (index >= 0)
                handshakeCombo.SelectedIndex = index;
        }

        private void InitControls()
        {
            portNameCombo.Items.Clear();
            portNameCombo.Items.AddRange(SerialPort.GetPortNames());
            if (portNameCombo.Items.Count > 0)
                portNameCombo.SelectedIndex = 0;

            baudrateCombo.Items.Clear();
            baudrateCombo.Items.AddRange(Enum.GetNames(typeof(BaudRate)));
            baudrateCombo.SelectedIndex = baudrateCombo.Items.IndexOf(BaudRate.baudRate9600.ToString());

            databitsCombo.Items.Clear();
            databitsCombo.Items.AddRange(Enum.GetNames(typeof(DataBits)));
            databitsCombo.SelectedIndex = databitsCombo.Items.IndexOf(DataBits.dataBits8.ToString());

            stopbitsCombo.Items.Clear();
            stopbitsCombo.Items.AddRange(Enum.GetNames(typeof(StopBits)));
            stopbitsCombo.SelectedIndex = stopbitsCombo.Items.IndexOf(StopBits.One.ToString());

            parityCombo.Items.Clear();
            parityCombo.Items.AddRange(Enum.GetNames(typeof(Parity)));
            parityCombo.SelectedIndex = parityCombo.Items.IndexOf(Parity.Even.ToString());

            handshakeCombo.Items.Clear();
            handshakeCombo.Items.AddRange(Enum.GetNames(typeof(Handshake)));
            handshakeCombo.SelectedIndex = handshakeCombo.Items.IndexOf(Handshake.None.ToString());
        }

        #endregion
    }
}
