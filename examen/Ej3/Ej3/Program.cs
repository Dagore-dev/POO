using System;

namespace Ej3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PixelDrawing pixelDrawing = new PixelDrawing();
            pixelDrawing.LoadFromFile("triangle.bin");

            pixelDrawing.Draw();
            Console.WriteLine();
            Console.WriteLine(pixelDrawing);

        }
    }
}
