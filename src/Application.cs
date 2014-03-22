using Project_Jeden.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Project_Jeden.src
{
    class Application
    {
        GameWindow window;
        InputHandler input;

        public Application()
        {
            window = new GameWindow();
            input = new InputHandler();

            window.Load += (sender, e) => Load();
            window.Resize += (sender, e) => Resize();
            window.UpdateFrame += (sender, e) => UpdateFrame();
            window.RenderFrame += (sender, e) => RenderFrame();
        }

        public static int Main(string[] args)
        {
            var game = new Application();
            var status = game.Run();

            return status;
        }

        public void Load()
        {
        }

        public void Resize()
        {
        }

        public void UpdateFrame()
        {
        }

        public void RenderFrame()
        {
            window.SwapBuffers();
        }

        public int Run()
        {
            window.Run(60.0);

            return 0;
        }
    }
}
