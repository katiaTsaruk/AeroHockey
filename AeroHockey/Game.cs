using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace AeroHockey
{
    public class Game
    {
        private const int windowWidth = 1280;
        private const int windowHeight = 720;
        private RenderWindow window;
        Paddle paddle1=new Paddle(true,windowWidth,windowHeight);
        Paddle paddle2=new Paddle(false,windowWidth,windowHeight);
        Ball ball =new Ball(windowWidth,windowHeight);
        private Collision collision = new Collision();

        public void Start()
        {
            RenderWindow window = new RenderWindow(new VideoMode(windowWidth, windowHeight), "Game window");
            window.Closed += WindowClosed;

            while (window.IsOpen)
            {
                window.Clear();
                window.Draw(paddle1.rectangleShape);
                window.Draw(paddle2.rectangleShape);
                window.Draw(ball.circleShape);
                MoveBall();
                MovePaddle();
                window.DispatchEvents();
                window.Display();
            }
        }
        public void MovePaddle()
        {
            float delta = 0.15f;
            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                paddle1.ChangePosition(-delta);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                paddle1.ChangePosition(delta);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
            {
                paddle2.ChangePosition(-delta);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
            {
                paddle2.ChangePosition(delta);
            }
        }

        private void WindowClosed(object sender, EventArgs e)
        {
            RenderWindow w = (RenderWindow)sender;
            w.Close();
        }
        public void MoveBall()
        {
            float deltaX = 1f;
            float deltaY = 2f;
            if (collision.CheckForCollision(deltaX, deltaY))
            {
                ball.circleShape.Position = new Vector2f(ball.circleShape.Position.X+deltaX,ball.circleShape.Position.Y+deltaY);
            }
        }
        // moglo bi bit krasivo no vidimo net(((
        // private void Background()
        // {
        //     Texture t=new Texture("picture");
        //     Image image=new Image("picture.jpg");
        //     Sprite sprite = new Sprite();
        //     sprite.Texture = new Texture(t);
        //     window.Draw(sprite);
        // }
    }
}