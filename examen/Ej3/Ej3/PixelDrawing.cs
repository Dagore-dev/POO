using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Ej3
{
    class PixelDrawing
    {
        //Atributos
        private List<Pixel> pixels = new List<Pixel>();
        //Propiedades
        public Pixel this[int index]
        {
            get
            {
                return pixels[index];
            }

            set
            {
                pixels[index] = value;
            }
        }
        //LoadFromFile
        public void LoadFromFile (string path)
        {
            if (File.Exists(path))
            {
                pixels.Clear();
                int x, y;
                FileStream fs = new FileStream(path, FileMode.Open);
                BinaryReader br = new BinaryReader(fs);
                Pixel pixel;

                while (fs.Position < fs.Length)
                {
                    x = br.ReadInt32();
                    y = br.ReadInt32();
                    pixel = new Pixel(x, y);
                    pixels.Add(pixel);

                }

                br.Close();
                fs.Close();
            }
            else
            {
                throw new Exception($"No se encuentra el fichero {path}");
            }

        }
        //SaveToFile
        public void SaveToFile (string path)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);

            foreach (Pixel pixel in pixels)
            {
                bw.Write(pixel.X);
                bw.Write(pixel.Y);
            }

            bw.Close();
            fs.Close();
        }
        //Draw
        public void Draw ()
        {
            foreach (Pixel pixel in pixels)
            {
                Console.SetCursorPosition(pixel.X, pixel.Y);
                Console.WriteLine('█');
            }
        }
        //ToString
        private string Representation ()
        {
            StringBuilder sb = new StringBuilder();
            bool[,] matrix = ToMatrix();
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i,j])
                    {
                        sb.Append('█');
                    }
                    else
                    {
                        sb.Append(' ');
                    }
                }
                sb.Append("\n");
            }

            return sb.ToString();
        }
        private bool[,] ToMatrix ()
        {
            bool[,] matrix = new bool[10, 10];

            foreach (Pixel pixel in pixels)
            {
                matrix[pixel.Y, pixel.X] = true;
            }

            return matrix;
        }
        public override string ToString()
        {
            return Representation();
        }
    }
}
