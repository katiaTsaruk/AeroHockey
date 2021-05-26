using SFML.System;

namespace AeroHockey
{
    public class Physics
    {
        ///TODO: бан когда залетает за линию ракеток
        
        private Ball ball;
        private Paddle paddle1;
        private Paddle paddle2;
        public int windowWidth, windowHeight;
        public float deltaX = 0.07f;
        public float deltaY = 0.06f;
        
        public Physics(Ball ball, Paddle paddle1, Paddle paddle2, int windowWidth, int windowHeight)
        {
            this.ball = ball;
            this.paddle1 = paddle1;
            this.paddle2 = paddle2;
            this.windowWidth = windowWidth;
            this.windowHeight = windowHeight;
        }
        public bool CheckWallCollision(float deltaX,float deltaY)
        {
            bool result = false;
            float newBallX=ball.circleShape.Position.X + deltaX;
            float newBallY=ball.circleShape.Position.Y + deltaY;
            if ( newBallY >= 2*ball.radius-15  && newBallY <= windowHeight - 2*ball.radius-5 )
                result= true;
            return result;
        }

        public bool CheckPaddleCollision(float deltaX, float deltaY)
        {
            bool result = true;
            float newBallX=ball.circleShape.Position.X + deltaX;
            float newBallY=ball.circleShape.Position.Y + deltaY;
            if (result && newBallX - ball.radius <= paddle1.rectangleShape.Position.X + paddle1.width / 2+2 &&
                newBallY - ball.radius <= paddle1.rectangleShape.Position.Y + paddle1.height/2+6  &&
                newBallY + ball.radius >= paddle1.rectangleShape.Position.Y - paddle1.height/2-6 )
                result = false;
            if (result && newBallX + ball.radius >= paddle2.rectangleShape.Position.X - paddle2.width  &&
                newBallY - ball.radius <= paddle2.rectangleShape.Position.Y + paddle2.height / 2+6 &&
                newBallY + ball.radius >= paddle2.rectangleShape.Position.Y - paddle2.height / 2-6)
                result = false;
            return result;
        }

        public void SetDeltas()
        {
            if (!CheckWallCollision(deltaX, deltaY))
            {
                deltaY *= -1;
            }

            if (!CheckPaddleCollision(deltaX, deltaY))
            {
                deltaX *= -1;
            }
        }
        public void MoveBall()
        {
            SetDeltas();
            if (CheckWallCollision(deltaX, deltaY) && CheckPaddleCollision(deltaX, deltaY))
            {
                ball.circleShape.Position = new Vector2f(ball.circleShape.Position.X+deltaX,ball.circleShape.Position.Y+deltaY);
            }
        }
    }
}