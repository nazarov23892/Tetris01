using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisBase
{
    public delegate void TetrisGameDelegate(TetrisGame sender);

    public interface ITetrisGame
    {
        ITetrisBrickModel BrickModel { get; set; }
        ITetrisView View { get; set; }
        ITetrisLevelSet LevelSet { get; set; }
        ITetrisTimer Timer { get; set; }

        int Score { get; }
        int Level { get; }
        int Speed { get; }
        TetrisGameState State { get; }
        
        void MoveDown();
        void MoveUp();
        void MoveRight();
        void MoveLeft();
        void Rotate();

        void SetStatePlay();
        void SetStatePause();
        void Reset();
    }

    public enum TetrisGameState
    {
        GameOver, Paused, Play, Win
    }
}
