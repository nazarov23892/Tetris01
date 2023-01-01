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
        private IFigureCreator[] creators = new IFigureCreator[]
        {
            new TFigureCreator(),
            new LineFigureCreator(),
            new LFigureCreator(),
            new JFigureCreator(),
            new SFigureCreator(),
            new ZFigureCreator(),
            new OFigureCreator()
        };

        public AbstractTetrisFigure Create()
        {
            if (creators.Length==0)
            {
                return null;
            }
            int randomIndex = randomGen.Next(creators.Length);
            IFigureCreator creator = creators[randomIndex];
            AbstractTetrisFigure figure = creator.CreateFigure();
            return figure;
        }
    }

    interface IFigureCreator
    {
        AbstractTetrisFigure CreateFigure();
    }

    class TFigureCreator : IFigureCreator
    {
        public AbstractTetrisFigure CreateFigure()
        {
            return new TTetrisFigure(0, 0);
        }
    }

    class LineFigureCreator : IFigureCreator
    {
        public AbstractTetrisFigure CreateFigure()
        {
            return new LineTetrisFigure(0, 0);
        }
    }

    class LFigureCreator : IFigureCreator
    {
        public AbstractTetrisFigure CreateFigure()
        {
            return new LTetrisFigure(0, 0);
        }
    }

    class JFigureCreator : IFigureCreator
    {
        public AbstractTetrisFigure CreateFigure()
        {
            return new JTetrisFigure(0, 0);
        }
    }

    class SFigureCreator : IFigureCreator
    {
        public AbstractTetrisFigure CreateFigure()
        {
            return new STetrisFigure(0, 0);
        }
    }

    class ZFigureCreator : IFigureCreator
    {
        public AbstractTetrisFigure CreateFigure()
        {
            return new ZTetrisFigure(0, 0);
        }
    }

    class OFigureCreator : IFigureCreator
    {
        public AbstractTetrisFigure CreateFigure()
        {
            return new OTetrisFigure(0, 0);
        }
    }

}
