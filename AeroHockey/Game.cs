using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.Window;

namespace AeroHockey
{
    public class Game
    {
        private RenderWindow window;
        Paddle paddle1=new Paddle(true,40,90);
        Paddle paddle2=new Paddle(false,40,90);

        public void Start()
        {
            RenderWindow window = new RenderWindow(new VideoMode(1280, 720), "Game window");
            window.Closed += WindowClosed;

            while (window.IsOpen)
            {
                window.Clear();
                window.Draw(paddle1.paddle);
                window.Draw(paddle2.paddle);
                window.DispatchEvents();
                window.Display();
            }
        }

        private void WindowClosed(object sender, EventArgs e)
        {
            RenderWindow w = (RenderWindow)sender;
            w.Close();
        }

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