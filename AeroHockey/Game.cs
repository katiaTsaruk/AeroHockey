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
        public Paddle paddle1=new Paddle(true,windowWidth,windowHeight);
        public Paddle paddle2=new Paddle(false,windowWidth,windowHeight);
        public Ball ball =new Ball(windowWidth,windowHeight);

        private Physics physics;

        public Game()
        {
            physics = new Physics(ball, paddle1, paddle2,
                windowWidth, windowHeight);
        }

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
                EndRound();
                if (EndRound())
                {
                    ball.CreateBall();
                }
                physics.MoveBall();
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

        private bool EndRound()
        {
            if (ball.circleShape.Position.X > paddle1.rectangleShape.Position.X + paddle1.width / 2 &&
                ball.circleShape.Position.X < paddle2.rectangleShape.Position.X - paddle2.width / 2) 
                return false;
            else return true;
        }

        private void WindowClosed(object sender, EventArgs e)
        {
            RenderWindow w = (RenderWindow)sender;
            w.Close();
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