using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TetrisBase;

namespace Tetris01
{
    public partial class MainForm : Form
    {
        private const int TETRIS_CUP_WIDTH = 10;
        private const int TETRIS_CUP_HEIGHT = 20;
        private readonly WinformDrawer winformDrawer1 = null;      
        private readonly ITetrisTimer tetrisTimer = null;
        private readonly ITetrisGame tetrisGame = null;
        private readonly ITetrisView tetrisView = null;

        public MainForm()
        {
            InitializeComponent();

            Graphics graphics1 = this.CreateGraphics();

            tetrisGame = new TetrisGame();
            tetrisTimer = new WinformTimer();
            winformDrawer1 = new WinformDrawer(graphics1);
            winformDrawer1.BackColor = this.BackColor;

            ITetrisLevelSet levelSet = new TetrisLevelSet();
            ITetrisFigureCreator figureCreator = new TetrisFigureCreator_v2();
            ITetrisBrickModel model = new TetrisBrickModel(TETRIS_CUP_WIDTH, TETRIS_CUP_HEIGHT, figureCreator);
            tetrisView = new TetrisView(model, tetrisGame, winformDrawer1);

            tetrisGame.BrickModel = model;
            tetrisGame.View = tetrisView;
            tetrisGame.LevelSet = levelSet;
            tetrisGame.Timer = tetrisTimer;
            tetrisGame.Reset();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    tetrisGame.MoveDown();
                    break;
                case Keys.Up:
                    tetrisGame.MoveUp();
                    break;
                case Keys.Left:
                    tetrisGame.MoveLeft();
                    break;
                case Keys.Right:
                    tetrisGame.MoveRight();
                    break;
                case Keys.Space:
                    tetrisGame.Rotate();
                    break;
                default:
                    break;
            }
        }

        private void ui_PauseButton_Click(object sender, EventArgs e)
        {
            if (tetrisGame.State == TetrisGameState.Play)
            {
                this.tetrisGame.SetStatePause();
            }
            else if(tetrisGame.State == TetrisGameState.Paused)
            {
                this.tetrisGame.SetStatePlay();
            }
        }

        private void ui_ResetButton_Click(object sender, EventArgs e)
        {
            this.tetrisGame.Reset();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.winformDrawer1.Dispose();
            this.tetrisTimer.Dispose();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.tetrisGame.State == TetrisGameState.Play)
            {
                this.tetrisGame.SetStatePause();
            }
            DialogResult result = MessageBox.Show("are you sure?", "Tetris exit..", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tetrisGame.SetStatePause();
            this.tetrisView.Redraw();
            using (AboutForm aboutForm = new AboutForm())
            {
                aboutForm.ShowDialog();
            }
            this.tetrisView.Redraw();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TetrisView tw = (TetrisView)this.tetrisView;
            bool isFigurePlaneEnabled = tw.FigurePlaneEnabled;
            this.tetrisGame.SetStatePause();
            this.tetrisView.Redraw();
            using (SettingsForm settingsForm = new SettingsForm())
            {
                settingsForm.FigurePlaneEnabled = isFigurePlaneEnabled;
                if (settingsForm.ShowDialog() == DialogResult.OK)
                {
                    tw.FigurePlaneEnabled = settingsForm.FigurePlaneEnabled;
                }
            }
            this.tetrisView.Redraw();
        }
    }
}
