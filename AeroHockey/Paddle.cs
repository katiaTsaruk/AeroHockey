using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace AeroHockey
{
    public class Paddle
    {
        public RectangleShape rectangleShape = new RectangleShape();
        private bool isPlayer1;
        public int width=40;
        public int height=90;
        private int windowWidth;
        private int windowHeight;

        public Paddle(bool isPlayer1,int windowWidth,int windowHeight)
        {
            this.isPlayer1 = isPlayer1;
            this.windowWidth = windowWidth;
            this.windowHeight = windowHeight;
            CreatePaddle();
        }

        public (float,float) GetCurrentPosition()
        {
            return (rectangleShape.Position.X, rectangleShape.Position.Y);
        }

        private bool TryToChangePosition(float delta)
        {
            float newY = rectangleShape.Position.Y + delta;
            return !(newY <= height / 2 + 10) && !(newY >= windowHeight - height / 2 - 10);
        }
        public void ChangePosition(float delta)
        {
            if (TryToChangePosition(delta))
            {
                rectangleShape.Position = new Vector2f(rectangleShape.Position.X, rectangleShape.Position.Y + delta);
            }
        }
        
        private void CreatePaddle()
        {
            rectangleShape.Size = new Vector2f(width, height);
            rectangleShape.Origin = new Vector2f(width/2, height/2);
            rectangleShape.OutlineColor=Color.White;
            rectangleShape.OutlineThickness = 3f;
            if (isPlayer1)
            {
                rectangleShape.FillColor=Color.Blue;
                rectangleShape.Position=new Vector2f(50, windowHeight/2);
            }
            else
            {
                rectangleShape.FillColor=Color.Red;
                rectangleShape.Position=new Vector2f(windowWidth-50, windowHeight/2);
            }
        }

    }
}