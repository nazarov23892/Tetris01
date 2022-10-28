using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisBase;

namespace TetrisBase
{
    public class TetrisFigureCreator : ITetrisFigureCreator
    {
        private System.Random randomGen = new System.Random();

        public AbstractTetrisFigure Create()
        {
            int random = randomGen.Next(7);
            AbstractTetrisFigure figure = null;
            switch (random)
            {
                case 0:
                    figure = new TTetrisFigure(0, 0);
                    break;

                case 1:
                    figure = new LTetrisFigure(0, 0);
                    break;

                case 2:
                    figure = new LineTetrisFigure(0, 0);
                    break;

                case 3:
                    figure = new JTetrisFigure(0, 0);
                    break;
                case 4:
                    figure = new STetrisFigure(0, 0);
                    break;
                case 5:
                    figure = new ZTetrisFigure(0, 0);
                    break;
                case 6:
                    figure = new OTetrisFigure(0, 0);
                    break;
                default:
                    throw new Exception("invalid index");
                    break;
            }
            return figure;
        }
    }
}
