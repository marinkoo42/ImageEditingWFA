using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMS_Projekat
{
    public partial class SaveOptions : Form
    {
        public bool compressionChecked
        {
            get { return compressionCbx.Checked; }
        }
        public bool downsamplingChecked
        {
            get { return downsplCbx.Checked; }
        }
        public bool hbRadioChecked
        {
            get { return hbRadio.Checked; }
        }


        public SaveOptions()
        {
            InitializeComponent();
            cancelBtn.DialogResult = DialogResult.Cancel;
            saveBtn.DialogResult = DialogResult.OK;
            bRadio.Checked = false;
            hbRadio.Checked = true;
            bRadio.Enabled = false;
            hbRadio.Enabled = false;
        }

        private void compressionCbx_CheckedChanged(object sender, EventArgs e)
        {
            bRadio.Enabled = !bRadio.Enabled;
            hbRadio.Enabled = !hbRadio.Enabled;
        }
    }
}
