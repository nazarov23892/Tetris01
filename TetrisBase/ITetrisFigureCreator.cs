using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisBase
{
    public interface ITetrisFigureCreator
    {
        AbstractTetrisFigure Create();
    }
}
