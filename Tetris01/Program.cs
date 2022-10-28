using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TetrisBase;

namespace Tetris01
{

    static class Program
    {


        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*
            TetrisFigureCreator creator = new TetrisFigureCreator();
            AbstractTetrisFigure tetrisFigure = creator.Create();
            var sizePoints = tetrisFigure.CalcSizePoints();
            int x = 0;
            */

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        private static void PrintTetrisCup(TetrisCup cup)
        {
            System.Console.Out.WriteLine("*** PrintTetrisCup ***");

            for (int i = 0; i < cup.GetPointsCount(); i++)
            {
                TetrisPoint point1 = cup.GetPointAt(i);
                System.Console.Out.WriteLine("element[{0}] = ({1}, {2}); color = {3}", i, point1.X, point1.Y, point1.Color.ToString());
            }
            System.Console.Out.WriteLine("---");
            System.Console.Out.WriteLine("elements count: {0}", cup.GetPointsCount());

        }
    }
}
