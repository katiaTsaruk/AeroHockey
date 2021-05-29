using SFML.Graphics;
using SFML.System;

namespace AeroHockey
{
    public class Ball
    {
        public CircleShape circleShape=new CircleShape();
        int windowWidth, windowHeight;
        public float radius = 15f;

        public Ball(int windowWidth,int windowHeight)
        {
            
            this.windowWidth = windowWidth;
            this.windowHeight = windowHeight;
            CreateBall();
        }

        public  void CreateBall()
        {
            circleShape.Radius = radius;
            circleShape.Origin=new Vector2f(circleShape.Radius/2,circleShape.Radius/2);
            circleShape.Position=new Vector2f(windowWidth/2,windowHeight/2);
            circleShape.FillColor = Color.Black;
            circleShape.OutlineColor=Color.White;
            circleShape.OutlineThickness = 10f;
        }
    }
}