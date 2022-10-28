using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris01
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        public bool FigurePlaneEnabled
        {
            get => this.ui_checkBox_ShowPlane.Checked;
            set => this.ui_checkBox_ShowPlane.Checked = value;
        }
    }
}
