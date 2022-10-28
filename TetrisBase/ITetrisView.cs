using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisBase
{
    public interface ITetrisView
    {
        ITetrisBrickModel TetrisBrickModel
        {
            get; set;
        }

        ITetrisGame TetrisGame
        {
            get; set;
        }

        IDrawableContext DrawableContext
        {
            get; set;
        }

        void Redraw();
    }
}
