using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisBase;

namespace TetrisBase
{
    public class TetrisView : ITetrisView
    {
        private const int MARGINSIZE_PX = 5;
        private const int POINTSIZE_PX = 20;
        private const int CUP_BOTTOMLEFT_PX_X = 50;
        private const int CUP_BOTTOMLEFT_PX_Y = 550;
        private const int NEXTFIGUREPANEL_WIDTH_PT = 4;
        private const int NEXTFIGUREPANEL_HEIGHT_PT = 4;
        private const int NEXTFIGURE_PANEL_SPACING_X = 20;
        private const int FIGURE_OUTLINE_WIDTH = 1;
        private const int PLANE_OUTLINE_WIDTH = 1;
        private const int CUP_OUTLINE_WIDTH = 1;
        private const int LABEL_FONT_SIZE = 12;
        private const int MESSAGE_FONT_SIZE = 28;
        private const TetrisColor FIGURE_OUTLINE_COLOR = TetrisColor.Black;
        private const TetrisColor PLANE_OUTLINE_COLOR = TetrisColor.Gray;
        private const TetrisColor CUP_OUTLINE_COLOR = TetrisColor.Black;

        private IDrawableContext drawableContext = null;
        private ITetrisBrickModel brickModel = null;
        private ITetrisGame game = null;

        public ITetrisBrickModel TetrisBrickModel
        {
            get => this.brickModel;
            set => this.brickModel = value;
        }

        public bool FigurePlaneEnabled
        {
            get; set;
        }

        public ITetrisGame TetrisGame
        {
            get => this.TetrisGame;
            set => this.TetrisGame = value;
        }

        public IDrawableContext DrawableContext
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public TetrisView(ITetrisBrickModel controller, ITetrisGame tetrisGame, IDrawableContext drawableContext)
        {
            this.brickModel = controller;
            this.drawableContext = drawableContext;
            this.game = tetrisGame;
            this.drawableContext.FontSize = LABEL_FONT_SIZE;
            this.FigurePlaneEnabled = true;
        }

        private void DrawFigure()
        {
            AbstractTetrisFigure figure = this.brickModel.Figure;
            drawableContext.OutlineColor = FIGURE_OUTLINE_COLOR;
            drawableContext.OutlineWidth = FIGURE_OUTLINE_WIDTH;
            for (int i = 0; i < figure.GetPointsCount(); i++)
            {
                TetrisPoint point = figure.GetPoint(i);
                int coordinateX = CUP_BOTTOMLEFT_PX_X + MARGINSIZE_PX + point.X * (POINTSIZE_PX + MARGINSIZE_PX);
                int coordinateY = CUP_BOTTOMLEFT_PX_Y - MARGINSIZE_PX - point.Y * (POINTSIZE_PX + MARGINSIZE_PX) - POINTSIZE_PX;
                drawableContext.DrawRectangleFillng(point.Color, coordinateX, coordinateY, POINTSIZE_PX, POINTSIZE_PX);
                drawableContext.DrawRectangleOutline(coordinateX, coordinateY, POINTSIZE_PX, POINTSIZE_PX);
            }
        }

        private void DrawFigurePlane()
        {
            if (! this.FigurePlaneEnabled)
            {
                return;
            }
            AbstractTetrisFigure figure = this.brickModel.PlaneFigure;
            drawableContext.OutlineColor = PLANE_OUTLINE_COLOR;
            drawableContext.OutlineWidth = PLANE_OUTLINE_WIDTH;
            for (int i = 0; i < figure.GetPointsCount(); i++)
            {
                TetrisPoint point = figure.GetPoint(i);
                int coordinateX = CUP_BOTTOMLEFT_PX_X + MARGINSIZE_PX + point.X * (POINTSIZE_PX + MARGINSIZE_PX);
                int coordinateY = CUP_BOTTOMLEFT_PX_Y - MARGINSIZE_PX - point.Y * (POINTSIZE_PX + MARGINSIZE_PX) - POINTSIZE_PX;
                drawableContext.DrawRectangleOutline(coordinateX, coordinateY, POINTSIZE_PX, POINTSIZE_PX);
            }
        }

        private void DrawNextFigure()
        {
            var panelPoints = this.CalcNextFigurePanelPoints();
            AbstractTetrisFigure nextFigure = this.brickModel.NextFigure;
            var figureSizePoint = nextFigure.CalcSizePoints();

            int topLeftX = figureSizePoint.X_Left;
            int topLeftY = figureSizePoint.Y_Top;
            int offsetX = 0 - topLeftX;
            int offsetY = NEXTFIGUREPANEL_HEIGHT_PT - topLeftY - 1;

            drawableContext.OutlineColor = FIGURE_OUTLINE_COLOR;
            drawableContext.OutlineWidth = FIGURE_OUTLINE_WIDTH;
            for (int i = 0; i < nextFigure.GetPointsCount(); i++)
            {
                TetrisPoint point = nextFigure.GetPoint(i);

                int pointX = point.X;
                int pointY = point.Y;
                pointX += offsetX;
                pointY += offsetY;

                int coordinateX = panelPoints.X_Left + MARGINSIZE_PX + pointX * (POINTSIZE_PX + MARGINSIZE_PX);
                int coordinateY = panelPoints.Y_Bottom - MARGINSIZE_PX - pointY * (POINTSIZE_PX + MARGINSIZE_PX) - POINTSIZE_PX;

                drawableContext.DrawRectangleFillng(point.Color, coordinateX, coordinateY, POINTSIZE_PX, POINTSIZE_PX);
                drawableContext.DrawRectangleOutline(coordinateX, coordinateY, POINTSIZE_PX, POINTSIZE_PX);
            }
        }

        private void DrawCupPoints()
        {
            TetrisCup cup = this.brickModel.Cup;
            drawableContext.OutlineColor = FIGURE_OUTLINE_COLOR;
            drawableContext.OutlineWidth = FIGURE_OUTLINE_WIDTH;
            for (int i = 0; i < cup.GetPointsCount(); i++)
            {
                TetrisPoint point = cup.GetPointAt(i);
                int coordinateX = CUP_BOTTOMLEFT_PX_X + MARGINSIZE_PX + point.X * (POINTSIZE_PX + MARGINSIZE_PX);
                int coordinateY = CUP_BOTTOMLEFT_PX_Y - MARGINSIZE_PX - point.Y * (POINTSIZE_PX + MARGINSIZE_PX) - POINTSIZE_PX;
                drawableContext.DrawRectangleFillng(point.Color, coordinateX, coordinateY, POINTSIZE_PX, POINTSIZE_PX);
                drawableContext.DrawRectangleOutline(coordinateX, coordinateY, POINTSIZE_PX, POINTSIZE_PX);
            }
        }

        private void DrawCupBorder()
        {
            var points = this.CalcCupPoints();

            int bottomleft_X = points.X_Left;
            int bottomleft_Y = points.Y_Bottom;
            int topleft_X = points.X_Left;
            int topleft_Y = points.Y_Top;
            int bottomright_X = points.X_Right;
            int bottomright_Y = points.Y_Bottom;
            int topright_X = points.X_Right;
            int topright_Y = points.Y_Top;

            drawableContext.OutlineColor = CUP_OUTLINE_COLOR;
            drawableContext.OutlineWidth = CUP_OUTLINE_WIDTH;
            drawableContext.DrawLine(topleft_X, topleft_Y, bottomleft_X, bottomleft_Y);
            drawableContext.DrawLine(bottomleft_X, bottomleft_Y, bottomright_X, bottomright_Y);
            drawableContext.DrawLine(bottomright_X, bottomright_Y, topright_X, topright_Y);
        }

        private void DrawGameState()
        {
            string message = "";
            switch (game.State)
            {
                case TetrisGameState.GameOver:
                    message = "GAME OVER";
                    break;
                case TetrisGameState.Paused:
                    message = "paused";
                    break;
                case TetrisGameState.Play:
                    // empty
                    break;
                case TetrisGameState.Win:
                    message = "WIN !";
                    break;
                default:
                    // empty
                    break;
            }
            if (message.Length == 0)
            {
                return;
            }

            var points = this.CalcCupPoints();
            int cupCenter_x = points.X_Left + (points.X_Right - points.X_Left) / 2;
            int cupCenter_y = points.Y_Top + (points.Y_Bottom - points.Y_Top) / 2;

            drawableContext.FontColor = TetrisColor.Blue;
            drawableContext.FontSize = MESSAGE_FONT_SIZE;
            var drawedStrSize = drawableContext.CalcDrawedStringSize(message);
            int width1 = drawedStrSize.Width;
            int height = drawedStrSize.Height;

            int message_x = cupCenter_x - (width1 / 2);
            int message_y = cupCenter_y - (height / 2);
            drawableContext.DrawString(message, message_x, message_y);
            return;
        }

        private void DrawLabels()
        {
            int SPACING_X = NEXTFIGURE_PANEL_SPACING_X;
            int SPACING_Y = 20;
            var cupPoints = this.CalcCupPoints();
            int scoreLabel_x = cupPoints.X_Right + SPACING_X;
            int scoreLabel_y = cupPoints.Y_Top + 150;
            int levelLabel_x = scoreLabel_x;
            int levelLabel_y = scoreLabel_y + SPACING_Y;
            int speedLabel_x = scoreLabel_x;
            int speedLabel_y = levelLabel_y + SPACING_Y;

            string scoreString = String.Format("score: {0}", game.Score);
            string levelString = String.Format("level: {0}", game.Level);
            string speedString = String.Format("speed: {0}", game.Speed);

            drawableContext.FontSize = LABEL_FONT_SIZE;
            drawableContext.FontColor = TetrisColor.Black;
            drawableContext.DrawString(scoreString, scoreLabel_x, scoreLabel_y);
            drawableContext.DrawString(levelString, levelLabel_x, levelLabel_y);
            drawableContext.DrawString(speedString, speedLabel_x, speedLabel_y);
        }

        /*
        private void DrawNextFigurePanel()
        {
            var panelPoints = this.CalcNextFigurePanelPoints();

            int topleft_X = panelPoints.X_Left;
            int topleft_Y = panelPoints.Y_Top;

            int bottomleft_X = panelPoints.X_Left;
            int bottomleft_Y = panelPoints.Y_Bottom;

            int bottomright_X = panelPoints.X_Right;
            int bottomright_Y = panelPoints.Y_Bottom;

            int topright_X = panelPoints.X_Right;
            int topright_Y = panelPoints.Y_Top;

            drawableContext.DrawLine(cupBorderColor, topleft_X, topleft_Y, bottomleft_X, bottomleft_Y);
            drawableContext.DrawLine(cupBorderColor, bottomleft_X, bottomleft_Y, bottomright_X, bottomright_Y);
            drawableContext.DrawLine(cupBorderColor, bottomright_X, bottomright_Y, topright_X, topright_Y);
            drawableContext.DrawLine(cupBorderColor, topright_X, topright_Y, topleft_X, topleft_Y);
        }
        */


        public void Redraw()
        {
            this.drawableContext.Clear();
            this.DrawCupBorder();
            this.DrawCupPoints();
            this.DrawFigurePlane();
            this.DrawFigure();
            this.DrawNextFigure();
            this.DrawGameState();
            this.DrawLabels();
            this.drawableContext.Flush();
        }

        private (int X_Left, int X_Right, int Y_Bottom, int Y_Top) CalcCupPoints()
        {
            TetrisCup cup = this.brickModel.Cup;

            int cupHeightPoints = cup.Height;
            int cupWidthPoints = cup.Width;

            int left_X = CUP_BOTTOMLEFT_PX_X;
            int right_X = CUP_BOTTOMLEFT_PX_X + cupWidthPoints * POINTSIZE_PX + (cupWidthPoints + 1) * MARGINSIZE_PX;
            int bottom_Y = CUP_BOTTOMLEFT_PX_Y;
            int top_Y = CUP_BOTTOMLEFT_PX_Y - cupHeightPoints * POINTSIZE_PX - (cupHeightPoints + 1) * MARGINSIZE_PX;

            return (left_X, right_X, bottom_Y, top_Y);
        }

        private (int X_Left, int X_Right, int Y_Bottom, int Y_Top) CalcNextFigurePanelPoints()
        {
            var cupPoints = this.CalcCupPoints();

            int X_left = cupPoints.X_Right + NEXTFIGURE_PANEL_SPACING_X;
            int X_right = X_left + NEXTFIGUREPANEL_WIDTH_PT * POINTSIZE_PX + (NEXTFIGUREPANEL_WIDTH_PT + 1) * MARGINSIZE_PX;
            int Y_top = cupPoints.Y_Top;
            int Y_bottom = Y_top + NEXTFIGUREPANEL_HEIGHT_PT * POINTSIZE_PX + (NEXTFIGUREPANEL_HEIGHT_PT + 1) * MARGINSIZE_PX;

            return (X_left, X_right, Y_bottom, Y_top);
        }
    }
}
