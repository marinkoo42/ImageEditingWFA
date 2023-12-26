using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMS_Projekat
{
    public partial class GammaInput : Form
    {
        public GammaInput()
        {
            InitializeComponent();

            okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;

        }



        public double Red
        {
            get
            {
                return (Convert.ToDouble(redTbx.Text));
            }
            set { redTbx.Text = value.ToString(); }
        }

        public double Green
        {
            get
            {
                return (Convert.ToDouble(greenTbx.Text));
            }
            set { greenTbx.Text = value.ToString(); }
        }

        public double Blue
        {
            get
            {
                return (Convert.ToDouble(blueTbx.Text));
            }
            set { blueTbx.Text = value.ToString(); }
        }


    }
}
