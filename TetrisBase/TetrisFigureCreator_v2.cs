using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisBase
{
    public class TetrisFigureCreator_v2 : ITetrisFigureCreator
    {
        private System.Random randomGen = new System.Random();
        private Type[] types = new Type[]
        {
            typeof(TTetrisFigure),
            typeof(LTetrisFigure),
            typeof(LineTetrisFigure),
            typeof(JTetrisFigure),
            typeof(STetrisFigure),
            typeof(ZTetrisFigure),
            typeof(OTetrisFigure)
        };

        public AbstractTetrisFigure Create()
        {
            if (types.Length == 0)
            {
                return null;
            }
            int randomIndex = randomGen.Next(types.Length);
            Type type = types[randomIndex];
            AbstractTetrisFigure figure = (AbstractTetrisFigure)Activator.CreateInstance(type, 0, 0);
            return figure;
        }
    }
}
