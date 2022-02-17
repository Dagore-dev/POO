using System;
using System.Collections.Generic;
using System.Text;

namespace TresEnRaya
{
    class Position
    {
        private int row;
        private int col;

        public Position(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public int Row
        {
            get
            {
                return row;
            }
            set
            {
                if (value >= 1 && value <= 9)
                {
                    row = value;
                }
                else
                {
                    throw new Exception("La posición no existe.");
                }
            }
        }
        public int Col
        {
            get
            {
                return col;
            }
            set
            {
                if (value >= 1 && value <= 9)
                {
                    col = value;
                }
                else
                {
                    throw new Exception("La posición no existe.");
                }
            }
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
        public bool MovimientoValido (Position position)
        {
            return tablero[position.Row, position.Col] != 0;
        }
        public void MueveJugadorUno (Position position)
        {
            if (MovimientoValido(position))
            {
                tablero[position.Row, position.Col] = 1;
            }
            else
            {
                throw new Exception("La posición ya está ocupada.");
            }
        }
        public void MueveJugadorDos (Position position)
        {
            if (MovimientoValido(position))
            {
                tablero[position.Row, position.Col] = 2;
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
            throw new NotImplementedException();
        }
        public bool GanaJugadorDos ()
        {
            throw new NotImplementedException();
        }

    }
}
