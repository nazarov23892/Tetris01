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
    public partial class InputForm : Form
    {
        public InputForm()
        {
            InitializeComponent();
        }

        private void InputForm_KeyDown(object sender, KeyEventArgs e)
        {
            System.Console.Out.WriteLine("KeyDown; code:{0}", e.KeyCode);

            //e.KeyCode == Keys.
            /*
            KeyDown; code:Down
            KeyDown; code:Left
            KeyDown; code:Right
            KeyDown; code:Up 
             
             */
        }

        private void InputForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            System.Console.Out.WriteLine("KeyPress");
        }

        private void InputForm_KeyUp(object sender, KeyEventArgs e)
        {
            System.Console.Out.WriteLine("KeyUp");
        }
    }
}
