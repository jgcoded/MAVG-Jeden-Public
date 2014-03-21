using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Jeden
{
    class Program
    {
        [STAThread]
        public static void Main()
        {
            using (var game = new GameWindow(1024,768))
            {
                game.Load += (sender, e) =>
                {
                    // setup settings, load textures, sounds
                    game.VSync = VSyncMode.On;
                };
 
                game.Resize += (sender, e) =>
                {
                    GL.Viewport(0, 0, game.Width, game.Height);
                };
 
                game.UpdateFrame += (sender, e) =>
                {
                    // add game logic, input handling
                    if (game.Keyboard[Key.Escape])
                    {
                        game.Exit();
                    }
                };
 
                game.RenderFrame += (sender, e) =>
                {
                    // render graphics
                    GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
 
                    GL.MatrixMode(MatrixMode.Projection);
                    GL.LoadIdentity();
                    GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);
 
                    GL.Begin(PrimitiveType.Quads);
 
                    GL.Color3(Color.MidnightBlue);  //We replace all this fixed function stuff with shaders later.
                    GL.Vertex2(-1f, -1f);
                    GL.Color3(Color.SpringGreen); // But for now it's something.
                    GL.Vertex2(1.0f, -1.0f);
                    GL.Color3(Color.Ivory);
                    GL.Vertex2(1f, 1f);
                    GL.Color3(Color.Red);
                    GL.Vertex2(-1f, 1f);
 
                    GL.End();
 
                    game.SwapBuffers();
                };
 
                // Run the game at 60 updates per second
                game.Run(60.0);
            }
        }
    }
}
