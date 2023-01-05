using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisBase
{
    public interface ITetrisBrickModel
    {
        int[] FilledRows { get; }
        bool IsCupOverflowed { get; }
        AbstractTetrisFigure Figure { get; }
        AbstractTetrisFigure NextFigure { get; }
        AbstractTetrisFigure PlaneFigure { get; }
        TetrisCup Cup { get; }

        int ExploseFilledRows();
        bool MoveLeft();
        bool MoveRight();
        bool MoveUp();
        bool MoveDown();
        bool Rotate();
        void Reset();
        void AssignCupPoints(List<TetrisPoint> points);
    }
}
