using System;
using System.Drawing;

namespace lab1
{
    internal class CEmblem
    {
        const int DefaultOuterCircleRadius = 100;
        const int DefaultInnerSquareSize = 70;
        const int DefaultInnerCircleRadius = 20;

        private Graphics graphics;
        private int _outerCircleRadius;
        private int _innerSquareSize;
        private int _innerCircleRadius;

        public int X { get; set; }
        public int Y { get; set; } 
        public int OuterCircleRadius
        { 
            get
            {
                return _outerCircleRadius;
            }
            set
            {
                _outerCircleRadius = value >= 200 ? 200 : value;
                _outerCircleRadius = value <= 10 ? 10 : value;

                _innerSquareSize = (int)(Math.Sqrt(2) * _outerCircleRadius);
                _innerCircleRadius = _innerSquareSize / 2;
            }
        }

        public int InnerSquareSize
        { 
            get
            {
                return _innerSquareSize;
            }
        }

        public int InnerCircleRadius
        { 
            get
            {
                return _innerCircleRadius;
            }
        }

        public CEmblem(Graphics graphics, int X, int Y)
        {
            this.graphics = graphics;
            this.X = X;
            this.Y = Y;
            this.OuterCircleRadius = DefaultOuterCircleRadius;
        }

        public void Show()
        {
            Draw(Pens.Blue, 2); 
        }

        public void Hide()
        {
            Draw(Pens.White, 2); 
        }

        public void Expand()
        {
            Hide();
            OuterCircleRadius++;
            Show();
        }

        public void Expand(int dRadius)
        {
            Hide();
            OuterCircleRadius += dRadius;
            Show();
        }

        public void Collapse()
        {
            Hide();
            OuterCircleRadius--;
            Show();
        }

        public void Collapse(int dRadius)
        {
            Hide();
            OuterCircleRadius -= dRadius;
            Show();
        }

        public void Move(int dX, int dY)
        {
            Hide();
            X += dX;
            Y += dY;
            Show();
        }

        private void Draw(Pen pen, int penWidth = 1)
        {
            Rectangle outerCircleRect = new Rectangle(X - OuterCircleRadius, Y - OuterCircleRadius, 2 * OuterCircleRadius, 2 * OuterCircleRadius);
            graphics.DrawEllipse(new Pen(pen.Color, penWidth), outerCircleRect);

            int halfInnerSquareSize = InnerSquareSize / 2;
            int innerSquareX = X - halfInnerSquareSize;
            int innerSquareY = Y - halfInnerSquareSize;
            Rectangle innerSquareRect = new Rectangle(innerSquareX, innerSquareY, InnerSquareSize, InnerSquareSize);
            graphics.DrawRectangle(new Pen(pen.Color, penWidth), innerSquareRect);

            int innerCircleX = X - InnerCircleRadius;
            int innerCircleY = Y - InnerCircleRadius;
            int innerCircleDiameter = 2 * InnerCircleRadius;
            Rectangle innerCircleRect = new Rectangle(innerCircleX, innerCircleY, innerCircleDiameter, innerCircleDiameter);
            graphics.DrawEllipse(new Pen(pen.Color, penWidth), innerCircleRect);
        }
    }
}
