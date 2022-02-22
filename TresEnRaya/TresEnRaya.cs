using System;
using System.Collections.Generic;
using System.Text;

namespace TresEnRaya
{
    struct Coordinate
    {
        public int row;
        public int col;

        public Coordinate(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }
    class TresEnRaya
    {
        /*ATRIBUTOS*/
        private int[,] tablero;

        /*CONSTRUCTORES*/
        public TresEnRaya ()
        {
            tablero = new int[3, 3];
        }

        /*MÉTODOS*/
        public void Iniciar ()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tablero[i, j] = 0;
                }
            }
        }
        public bool MovimientoValido (int position)
        {
            bool isValid = false;

            if (position > 0 && position < 10)
            {
                
                isValid = GetCoordinateValue(position) == 0;
            }

            return isValid;
        }
        public void MueveJugadorUno (int position)
        {
            Coordinate coordinate;

            if (MovimientoValido(position))
            {
                coordinate = GetCoordinate(position);    
                tablero[coordinate.row, coordinate.col] = 1;
            }
            else
            {
                throw new Exception("La posición ya está ocupada.");
            }
        }
        public void MueveJugadorDos (int position)
        {
            Coordinate coordinate;

            if (MovimientoValido(position))
            {
                coordinate = GetCoordinate(position);
                tablero[coordinate.row, coordinate.col] = 2;
            }
            else
            {
                throw new Exception("La posición ya está ocupada.");
            }
        }
        public void MueveOrdenadorUno ()
        {
            throw new NotImplementedException();
        }
        public void MueveOrdenadorDos ()
        {
            throw new NotImplementedException();
        }
        public bool QuedanMovimientos ()
        {
            bool quedanMovimientos = false;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (tablero[i,j] == 0)
                    {
                        quedanMovimientos = true;
                    }
                }
            }
            
            return quedanMovimientos;
        }
        public bool GanaJugadorUno ()
        {
            bool ganaJugadorUno = false;
            int i = 0, j = 0;

            while (!ganaJugadorUno && i < 3)
            {
                if (tablero[i, 0] == 1 && tablero[i, 1] == 1 && tablero[i, 2] == 1)
                {
                    ganaJugadorUno = true;
                }

                i++;
            }

            while (!ganaJugadorUno && j < 3)
            {
                if (tablero[0, j] == 1 && tablero[1, j] == 1 && tablero[2, j] == 1)
                {
                    ganaJugadorUno = true;
                }

                j++;
            }

            if (tablero[0, 0] == 1 && tablero[1, 1] == 1 && tablero[2, 2] == 1)
            {
                ganaJugadorUno = true;
            }

            if (tablero[0, 2] == 1 && tablero[1, 1] == 1 && tablero[2, 0] == 1)
            {
                ganaJugadorUno = true;
            }

            return ganaJugadorUno;
        }
        public bool GanaJugadorDos ()
        {
            bool ganaJugadorDos = false;
            int i = 0, j = 0;

            while (!ganaJugadorDos && i < 3)
            {
                if (tablero[i, 0] == 2 && tablero[i, 1] == 2 && tablero[i, 2] == 2)
                {
                    ganaJugadorDos = true;
                }

                i++;
            }

            while (!ganaJugadorDos && j < 3)
            {
                if (tablero[0, j] == 2 && tablero[1, j] == 2 && tablero[2, j] == 2)
                {
                    ganaJugadorDos = true;
                }

                j++;
            }

            if (tablero[0, 0] == 2 && tablero[1, 1] == 2 && tablero[2, 2] == 2)
            {
                ganaJugadorDos = true;
            }

            if (tablero[0, 2] == 2 && tablero[1, 1] == 2 && tablero[2, 0] == 2)
            {
                ganaJugadorDos = true;
            }

            return ganaJugadorDos;
        }
        public void DibujaTablero ()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{tablero[i,j]}\t");
                }
                Console.WriteLine();
            }
        }
        private Coordinate GetCoordinate (int position)
        {
            /*
            1 2 3  0,0 0,1 0,2
            4 5 6  1,0 1,1 1,2
            7 8 9  2,0 2,1 2,2

            1 = 0 0
            2 = 0 1
            3 = 0 2
            4 = 1 0
            5 = 1 1
            6 = 1 2
            7 = 2 0
            8 = 2 1
            9 = 2 2
            */
            int row, col;

            if (position < 4)
            {
                row = 0;
                col = position - 1;
            }
            else if (position < 7)
            {
                row = 1;
                col = position - 4;
            }
            else
            {
                row = 2;
                col = position - 7;
            }

            return new Coordinate(row, col);
        }
        private int GetCoordinateValue (int position)
        {
            Coordinate coordinate = GetCoordinate(position);

            return tablero[coordinate.row, coordinate.col];
        }
    }
}
