using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace AeroHockey
{
    public class Paddle
    {
        public RectangleShape paddle = new RectangleShape();
        private bool isPlayer1;
        private int width;
        private int height;
        private int windowWidth;
        private int windowHeight;

        public Paddle(bool isPlayer1, int width,int height,int windowWidth,int windowHeight)
        {
            this.isPlayer1 = isPlayer1;
            this.width = width;
            this.height = height;
            this.windowWidth = windowWidth;
            this.windowHeight = windowHeight;
            CreatePaddle();
        }

        public (float,float) GetCurrentPosition()
        {
            return (paddle.Position.X, paddle.Position.Y);
        }

        private bool TryToChangePosition(float delta)
        {
            float newY = paddle.Position.Y + delta;
            return !(newY <= height / 2 + 10) && !(newY >= windowHeight - height / 2 - 10);
        }
        public void ChangePosition(float delta)
        {
            if (TryToChangePosition(delta))
            {
                paddle.Position = new Vector2f(paddle.Position.X, paddle.Position.Y + delta);
            }
        }
        
        private void CreatePaddle()
        {
            paddle.Size = new Vector2f(width, height);
            paddle.Origin = new Vector2f(width/2, height/2);
            paddle.OutlineColor=Color.White;
            paddle.OutlineThickness = 3f;
            if (isPlayer1)
            {
                paddle.FillColor=Color.Blue;
                paddle.Position=new Vector2f(50, windowHeight/2);
            }
            else
            {
                paddle.FillColor=Color.Red;
                paddle.Position=new Vector2f(windowWidth-50, windowHeight/2);
            }
        }

    }
}