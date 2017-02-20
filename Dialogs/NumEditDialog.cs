using System;
using System.Windows.Forms;

namespace UCNLUI.Dialogs
{
    public partial class NumEditDialog : Form
    {
        #region Properties

        public string Caption
        {
            get
            {
                return hintLbl.Text;
            }
            set
            {
                hintLbl.Text = value;
            }
        }

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

        public double Value
        {
            get
            {
                return Convert.ToDouble(numEdit.Value);
            }
            set
            {
                numEdit.Value = Convert.ToDecimal(value);
            }
        }

        public int DecimalPlaces
        {
            get
            {
                return numEdit.DecimalPlaces;
            }
            set
            {
                numEdit.DecimalPlaces = value;
            }
        }

        public double Maximum
        {
            get
            {
                return Convert.ToDouble(numEdit.Maximum);
            }
            set
            {
                numEdit.Maximum = Convert.ToDecimal(value);
            }
        }

        public double Minimum
        {
            get
            {
                return Convert.ToDouble(numEdit.Minimum);
            }
            set
            {
                numEdit.Minimum = Convert.ToDecimal(value);
            }
        }        

        #endregion

        #region Constructor

        public NumEditDialog()
        {
            InitializeComponent();
        }

        #endregion
    }
}
