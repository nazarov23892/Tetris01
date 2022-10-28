using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisBase
{
    public class TetrisMain
    {
        private ITetrisGame game;
        private ITetrisBrickModel brickModel;
        private ITetrisView view;

        public TetrisMain(ITetrisBrickModel brickModel, ITetrisView view, ITetrisGame game)
        {
            this.BrickModel = brickModel;
            this.View = view;
            this.Game = game;
        }

        public ITetrisGame Game
        {
            get => this.game;
            set => this.game = value;
        }

        public ITetrisBrickModel BrickModel 
        { 
            get => brickModel; 
            set => brickModel = value; 
        }

        public ITetrisView View 
        { 
            get => view; 
            set => view = value; 
        }
    }
}
