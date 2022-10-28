using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisBase
{
    public delegate void TetrisCupFilledRowsBeforeExploseEventHandler(ITetrisBrickModel sender, IEnumerable<int> rowIndexes);
    public delegate void TetrisCupFilledRowsAfterExploseEventHandler(ITetrisBrickModel sender, int rowCount);
    public delegate void TetrisCupEventHandler(ITetrisBrickModel sender, TetrisCup cup);
    public delegate void TetrisFigureEventHandler(ITetrisBrickModel sender, AbstractTetrisFigure figure);

    public interface ITetrisBrickModel
    {
        event TetrisCupFilledRowsBeforeExploseEventHandler FilledRowsBeforeExplose;
        event TetrisCupFilledRowsAfterExploseEventHandler FilledRowsAfterExplose;
        event TetrisFigureEventHandler FigureRecreated;
        event TetrisFigureEventHandler FigureChanged;
        event TetrisCupEventHandler CupChanged;
        event TetrisCupEventHandler CupOverflow;

        AbstractTetrisFigure Figure { get; }
        AbstractTetrisFigure NextFigure { get; }
        AbstractTetrisFigure PlaneFigure { get; }
        TetrisCup Cup { get; }

        bool MoveLeft();
        bool MoveRight();
        bool MoveUp();
        bool MoveDown();
        bool Rotate();
        void Reset();
        void AssignCupPoints(List<TetrisPoint> points);
    }
}
