using System;
using System.Collections.Generic;
using System.Text;

namespace EntregaDineroMoneda
{
    enum TipoMoneda
    {
        euro,
        dolar,
        libra
    }
    class Moneda
    {
        readonly private TipoMoneda tMoneda;
        readonly private int decimales;
        readonly private string simbolo;
        private decimal cambioEuro;

        /*CONSTRUCTOR*/
        public Moneda(TipoMoneda tMoneda, int decimales, string simbolo, decimal cambioEuro)
        {
            this.tMoneda = tMoneda;
            this.decimales = TrySetDecimales(decimales);
            this.simbolo = TrySetSimbolo(simbolo);
            CambioEuro = cambioEuro;
        }

        /*VALIDACIONES*/
        private int TrySetDecimales(int decimales)
        {
            if (decimales >= 0 && decimales < 5)
            {
                return decimales;
            }
            else
            {
                throw new Exception("Decimales debe ser un entero entre 0 y 4 (ambos incluidos).");
            }
        }
        private string TrySetSimbolo(string simbolo)
        {
            if (simbolo.Length != 0)
            {
                return simbolo;
            }
            else
            {
                throw new Exception("El símbolo no puede ser un string vacío.");
            }
        }

        /*PROPIEDADES*/
        public TipoMoneda TMoneda => tMoneda;
        public int Decimales => decimales;
        public string Simbolo => simbolo;
        public decimal CambioEuro
        {
            get => cambioEuro;
            set
            {
                if (value >= 0)
                {
                    cambioEuro = value;
                }
                else
                {
                    throw new Exception("El cambio no puede ser negativo.");
                }
            }
        }
    }
}
