using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisBase
{

    public class TetrisGame: ITetrisGame
    {
        public event TetrisGameDelegate LevelCompleted;
        public event TetrisGameDelegate Win;
        public event TetrisGameDelegate GameOver;

        private const int SCORE_LEVEL_END = 10 * 1000;
        private readonly Dictionary<int, int> SCORE_REWARDS = new Dictionary<int, int>()
        {
            {1, 100 },
            {2, 300 },
            {3, 700 },
            {4, 1500 }
        };
        private readonly int[] SpeedIntervalList = { 1000, 900, 800, 700, 600, 500, 400, 300, 200, 100 };

        private int score = 0;

        private TetrisGameState state;
        private ITetrisBrickModel brickModel = null;
        private ITetrisView view = null;
        private ITetrisLevelSet levelSet = null;
        private ITetrisTimer timer = null;

        public TetrisGame()
        {
            //
        }

        public TetrisGame(TetrisBrickModel tetrisController, TetrisView tetrisView, ITetrisLevelSet tetrisLevelSet, ITetrisTimer tetrisTimer)
        {
            this.BrickModel = tetrisController;
            this.View = tetrisView;
            this.LevelSet = tetrisLevelSet;
            this.Timer = tetrisTimer;
        }

        public ITetrisBrickModel BrickModel
        {
            get => this.brickModel;
            set
            {
                if (this.brickModel == value)
                {
                    return;
                }
                this.brickModel = value;
                //this.brickModel.CupOverflow += TetrisController_CupOverflow;
                //this.brickModel.FilledRowsAfterExplose += TetrisController_FilledRowsAfterExplose;
            }
        }

        public ITetrisView View
        {
            get => this.view;
            set => this.view = value;
        }

        public ITetrisLevelSet LevelSet 
        { 
            get => this.levelSet; 
            set => this.levelSet = value; 
        }

        public ITetrisTimer Timer 
        { 
            get => this.timer;
            set
            {
                if (this.timer == value)
                {
                    return;
                }
                this.timer = value;
                this.timer.Tick += TetrisTimer_Elapsed;
            }
        }

        public int Score => this.score;

        public int Level => this.levelSet.GetLevelNo();

        public TetrisGameState State => this.state;

        public int Speed => this.levelSet.GetLevelSpeed();

       
        public void MoveDown()
        {
            if (this.state != TetrisGameState.Play)
            {
                return;
            }
            this.brickModel.MoveDown();
            ExploseFilledRows();
            if (brickModel.IsCupOverflowed)
            {
                this.SetStateGameover();
            }
            this.view.Redraw();
        }

        public void MoveUp()
        {
            if (this.state != TetrisGameState.Play)
            {
                return;
            }
            //this.brickModel.MoveUp();
            //this.view.Redraw();
        }

        public void MoveRight()
        {
            if (this.state != TetrisGameState.Play)
            {
                return;
            }
            this.brickModel.MoveRight();
            this.view.Redraw();
        }

        public void MoveLeft()
        {
            if (this.state != TetrisGameState.Play)
            {
                return;
            }
            this.brickModel.MoveLeft();
            this.view.Redraw();
        }

        public void Rotate()
        {
            if (this.state != TetrisGameState.Play)
            {
                return;
            }
            this.brickModel.Rotate();
            this.view.Redraw();
        }

        public void Reset()
        {
            this.score = 0;
            this.brickModel.Reset();
            this.levelSet.Begin();
            AssignLevel();
            this.state = TetrisGameState.Play;
            this.timer.Start();
            this.view.Redraw();
        }

        public void SetStatePlay()
        {
            if (this.State != TetrisGameState.Paused)
            {
                return;
            }
            this.state = TetrisGameState.Play;
            timer.Start();
            this.view.Redraw();
        }

        public void SetStatePause()
        {
            if (this.State != TetrisGameState.Play)
            {
                return;
            }
            this.state = TetrisGameState.Paused;
            timer.Stop();
            this.view.Redraw();
        }

        private void SetStateWin()
        {
            this.state = TetrisGameState.Win;
            this.timer.Stop();
            if (this.Win != null)
            {
                this.Win(this);
            }
            this.view.Redraw();
        }

        private void SetStateGameover()
        {
            this.state = TetrisGameState.GameOver;
            this.timer.Stop();
            if (this.GameOver != null)
            {
                this.GameOver(this);  
            }
            this.view.Redraw();
        }

        //private void TetrisController_FilledRowsAfterExplose(ITetrisBrickModel sender, int rowCount)
        //{
        //    int reward = SCORE_REWARDS[rowCount];
        //    this.score += reward;

        //    if (this.score >= SCORE_LEVEL_END)
        //    {
        //        if (this.levelSet.IsEnd())
        //        {
        //            this.SetStateWin();
        //            return;
        //        }
        //        this.NextLevel();
        //        if (this.LevelCompleted != null)
        //        {
        //            this.LevelCompleted(this);
        //        }
        //    }
        //}

        private void ExploseFilledRows()
        {
            int explosedRowCount = this.brickModel.ExploseFilledRows();
            if (explosedRowCount == 0)
            {
                return;
            }
            int reward = SCORE_REWARDS[explosedRowCount];
            this.score += reward;

            if (IsLevelCompleted())
            {
                if (this.levelSet.IsEnd())
                {
                    this.SetStateWin();
                    return;
                }
                this.NextLevel();
                if (this.LevelCompleted != null)
                {
                    this.LevelCompleted(this);
                }
            }
        }

        private bool IsLevelCompleted()
        {
            return this.score >= SCORE_LEVEL_END;
        }

        private void TetrisTimer_Elapsed(ITetrisTimer sender)
        {
            this.MoveDown();
        }

        private void NextLevel()
        {
            this.score = 0;
            this.levelSet.Next();
            AssignLevel();
            this.view.Redraw();
        }

        private void AssignLevel()
        {
            List<TetrisPoint> points = new List<TetrisPoint>();
            for (int i = 0; i < levelSet.GetLevelPointsCount(); i++)
            {
                TetrisPoint tetrisPoint = levelSet.GetLevelPointAt(i);
                points.Add(tetrisPoint);
            }
            this.brickModel.AssignCupPoints(points);
            int speed = this.levelSet.GetLevelSpeed();
            if (speed < 0 || speed >= this.SpeedIntervalList.Length)
            {
                throw new Exception("invalid level speed value");
            }
            int interval_milliseconds = this.SpeedIntervalList[speed];
            this.timer.SetInterval(interval_milliseconds);
        }
    }
}
