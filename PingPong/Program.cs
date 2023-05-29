using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using OpenTK.Audio.OpenAL;
using System.IO;
using System.Drawing;
using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace PingPong
{
    public class Program : GameWindow
    {
        int xDaBola = 0;
        int yDaBola = 0;  
        int tamanhoDaBola = 18;
        int velocidadeDaBolaEmX = 10;
        int velocidadeDaBolaEmY = 10;

        int yDoJogador1 = 0;
        int yDoJogador2 = 0;

        int pontoJogador2 = 0;
        int pontoJogador1 = 0;

        bool iniciarJogo = false;

        int xDoJogador1()
        {
            return -ClientSize.Width / 2 + larguraDosJogadores() / 2;
        }

        int xDoJogador2()
        {
            return ClientSize.Width / 2 - larguraDosJogadores() / 2;

        }

        int larguraDosJogadores()
        {
            return tamanhoDaBola;
        }

        int alturaDosJogadores()
        {
            return 3 * tamanhoDaBola;
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            if (Keyboard.GetState().IsKeyDown(Key.Up) || Keyboard.GetState().IsKeyDown(Key.Down) || Keyboard.GetState().IsKeyDown(Key.W) || Keyboard.GetState().IsKeyDown(Key.S))
                iniciarJogo = true;

            if (Keyboard.GetState().IsKeyDown(Key.Escape))
                iniciarJogo = false;

            if (iniciarJogo)
            {
                xDaBola = xDaBola + velocidadeDaBolaEmX;
                yDaBola = yDaBola + velocidadeDaBolaEmY;

                if (xDaBola + tamanhoDaBola / 2 > xDoJogador2() - larguraDosJogadores() / 2
                    && yDaBola - tamanhoDaBola / 2 < yDoJogador2 + alturaDosJogadores() / 2
                    && yDaBola + tamanhoDaBola / 2 > yDoJogador2 - alturaDosJogadores() / 2)
                {
                    velocidadeDaBolaEmX = -velocidadeDaBolaEmX;
                }

                if (xDaBola - tamanhoDaBola / 2 < xDoJogador1() + larguraDosJogadores() / 2
                    && yDaBola - tamanhoDaBola / 2 < yDoJogador1 + alturaDosJogadores() / 2
                    && yDaBola + tamanhoDaBola / 2 > yDoJogador1 - alturaDosJogadores() / 2)
                {
                    velocidadeDaBolaEmX = -velocidadeDaBolaEmX;
                }

                if (yDaBola + tamanhoDaBola / 2 > ClientSize.Height / 2)
                {
                    velocidadeDaBolaEmY = -velocidadeDaBolaEmY;
                }

                if (yDaBola - tamanhoDaBola / 2 < -ClientSize.Height / 2)
                {
                    velocidadeDaBolaEmY = -velocidadeDaBolaEmY;
                }

                if (xDaBola > ClientSize.Width / 2)
                {
                    pontoJogador1++;
                    xDaBola = 0;
                    yDaBola = 0;
                    yDoJogador1 = 0;
                    yDoJogador2 = 0;
                    iniciarJogo = false;
                    Console.WriteLine("ponto do jogador 1   -" + pontoJogador1);
                }

                if (xDaBola < -ClientSize.Width / 2)
                {
                    pontoJogador2++;
                    xDaBola = 0;
                    yDaBola = 0;
                    yDoJogador1 = 0;
                    yDoJogador2 = 0;
                    iniciarJogo = false;
                    Console.WriteLine("ponto do jogador 2   -" + pontoJogador2);
                }

                if (pontoJogador1 == 10 || pontoJogador2 == 10)
                {
                    pontoJogador1 = 0;
                    pontoJogador2 = 0;
                    xDaBola = 0;
                    yDaBola = 0;
                    yDoJogador1 = 0;
                    yDoJogador2 = 0;
                    iniciarJogo = false;
                }

                if (Keyboard.GetState().IsKeyDown(Key.W))
                {
                    yDoJogador1 = yDoJogador1 + 5;
                }

                if (Keyboard.GetState().IsKeyDown(Key.S))
                {
                    yDoJogador1 = yDoJogador1 - 5;
                }

                if (Keyboard.GetState().IsKeyDown(Key.Up))
                {
                    yDoJogador2 = yDoJogador2 + 5;
                }

                if (Keyboard.GetState().IsKeyDown(Key.Down))
                {
                    yDoJogador2 = yDoJogador2 - 5;
                }
            }
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Viewport(0, 0, ClientSize.Width, ClientSize.Height);

            Matrix4 projection = Matrix4.CreateOrthographic(ClientSize.Width, ClientSize.Height, 0.0f, 1.0f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);

            GL.Clear(ClearBufferMask.ColorBufferBit);

            DesenharRetangulo(xDaBola, yDaBola, tamanhoDaBola, tamanhoDaBola, 192, 217, 217);
            DesenharRetangulo(xDoJogador1(), yDoJogador1, larguraDosJogadores(), alturaDosJogadores(), 0.0f, 0.0f, 1.0f);
            DesenharRetangulo(xDoJogador2(), yDoJogador2, larguraDosJogadores(), alturaDosJogadores(), 1.0f, 0.0f, 0.0f);

            GL.Color4(Color4.White);

            Color corDoTexto = Color.White;

            float x = -0.9f;
            float y = 0.9f;

            string placarJogador1 = pontoJogador1.ToString();

            string placarJogador2 = pontoJogador2.ToString();

            int tamanhoFonte = 40;

            using (Font fonte = new Font("Arial", tamanhoFonte))
            {
                // Cria um objeto Graphics a partir do contexto OpenGL
                using (Graphics graphics = Graphics.FromHwnd(this.WindowInfo.Handle))
                {
                    // Configurações adicionais do objeto Graphics
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                    // Mede o tamanho do texto
                    SizeF tamanhoTexto = graphics.MeasureString(placarJogador1, fonte);

                    // Calcula a posição do texto centralizado
                    float posX = x + (1.0f - tamanhoTexto.Width / Width) / 2.0f;
                    float posY = y;


                    // Desenha o texto
                    using (Brush brush = new SolidBrush(corDoTexto))
                    {
                        graphics.DrawString(placarJogador1, fonte, brush, posX + 920, posY);
                    }

                    using (Brush brush = new SolidBrush(corDoTexto))
                    {
                        graphics.DrawString(placarJogador2, fonte, brush, posX + ClientSize.Width / 1.9f, posY);
                    }
                }
            }

            SwapBuffers();

        }

        void DesenharRetangulo(int x, int y, int largura, int altura, float r, float g, float b)
        {
            GL.Color3(r, g, b);

            GL.Begin(PrimitiveType.Quads);
            GL.Vertex2(-0.5f * largura + x, -0.5f * altura + y);
            GL.Vertex2(0.5f * largura + x, -0.5f * altura + y);
            GL.Vertex2(0.5f * largura + x, 0.5f * altura + y);
            GL.Vertex2(-0.5f * largura + x, 0.5f * altura + y);
            GL.End();
        }

        static void Main()
        {
            new Program().Run(60.0);
        }
    }
}
