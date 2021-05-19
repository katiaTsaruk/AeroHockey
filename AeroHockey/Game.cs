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
        Paddle paddle1=new Paddle(true,40,90,windowWidth,windowHeight);
        Paddle paddle2=new Paddle(false,40,90,windowWidth,windowHeight);

        public void Start()
        {
            RenderWindow window = new RenderWindow(new VideoMode(windowWidth, windowHeight), "Game window");
            window.Closed += WindowClosed;

            while (window.IsOpen)
            {
                window.Clear();
                window.Draw(paddle1.paddle);
                window.Draw(paddle2.paddle);
                MovePaddle();
                window.DispatchEvents();
                window.Display();
            }
        }
        public void MovePaddle()
        {
            float delta = 0.1f;
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