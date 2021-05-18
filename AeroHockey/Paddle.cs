using SFML.Graphics;
using SFML.System;

namespace AeroHockey
{
    public class Paddle
    {
        public RectangleShape paddle = new RectangleShape();
        public bool isPlayer1;
        public uint sizeX;
        public uint sizeY;

        public Paddle(bool isPlayer1, uint sizeX,uint sizeY)
        {
            this.isPlayer1 = isPlayer1;
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            SetPaddle();
        }

        public void SetPaddle()
        {
            paddle.Size = new Vector2f(sizeX, sizeY);
            paddle.Origin = new Vector2f(sizeX/2, sizeY/2);
            paddle.OutlineColor=Color.White;
            paddle.OutlineThickness = 3f;
            if (isPlayer1)
            {
                paddle.FillColor=Color.Blue;
                paddle.Position=new Vector2f(50, 360);
            }
            else
            {
                paddle.FillColor=Color.Red;
                paddle.Position=new Vector2f(1230, 360);
            }
        }

    }
}