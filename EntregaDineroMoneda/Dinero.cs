using System;
using System.Collections.Generic;
using System.Net;

namespace EntregaDineroMoneda
{
    class Dinero
    {
        /*ATRIBUTOS*/
        private static List<Moneda> listaMonedas;
        private decimal cantidad;
        private TipoMoneda tMoneda;

        /*CONSTRUCTOR ESTÁTICO*/
        static Dinero()
        {
            string apiResponse = DownloadHTML("https://api.exchangerate.host/base=EUR");
            decimal cambioEuroDolar = GetValue(apiResponse, "USD");
            decimal cambioEuroLibra = GetValue(apiResponse, "GBP");
            
            listaMonedas = new List<Moneda>();
            listaMonedas.Add(new Moneda(TipoMoneda.euro, 2, "€", 1m));
            listaMonedas.Add(new Moneda(TipoMoneda.dolar, 2, "$", cambioEuroDolar));
            listaMonedas.Add(new Moneda(TipoMoneda.libra, 4, "£", cambioEuroLibra));
        }

        /*CONSTRUCTORES*/
        public Dinero(decimal cantidad, TipoMoneda t)
        {
            Cantidad = cantidad;
            TMoneda = t;
        }
        public Dinero(double cantidad, TipoMoneda t)
        {
            Cantidad = (decimal) cantidad;
            TMoneda = t;
        }
        public Dinero(int cantidad, TipoMoneda t)
        {
            Cantidad = (decimal)cantidad;
            TMoneda = t;
        }

        /*PROPIEDADES*/
        public decimal Cantidad { get => cantidad; set => cantidad = value; }
        public TipoMoneda TMoneda { get => tMoneda; set => tMoneda = value; }

        /*MÉTODOS ESTÁTICOS*/
        private static decimal GetValue(string apiResponse, string abbr)
        {
            int start = apiResponse.IndexOf(abbr);
            string firstCut = apiResponse.Substring(start);
            int end = firstCut.IndexOf(',');
            string secondCut = firstCut.Substring(0, end);
            string value = secondCut.Substring(5);

            return decimal.Parse(value);
        }
        private static string DownloadHTML (string url)
        {
            WebClient wc = new WebClient();
            try
            {
                return wc.DownloadString(url);
            }
            catch (Exception)
            {

                throw new Exception("No se puede obtener el HTML del servicio web");
            }
        }
        private static Moneda BuscaMoneda (TipoMoneda t)
        {
            if (listaMonedas.Count > 0)
            {
                Moneda moneda = listaMonedas[0];

                for (int i = 0; i < listaMonedas.Count; i++)
                {
                    if (listaMonedas[i].TMoneda == t)
                    {
                        moneda = listaMonedas[i];
                    }
                }
                
                return moneda;
            }
            else
            {
                throw new Exception("La lista de monedas está vacía.");
            }
        }
        public static void ActualizaCambio (TipoMoneda t, decimal cambio)
        {
            Moneda moneda = BuscaMoneda(t);
            moneda.CambioEuro = cambio;
        }

        /*MÉTODOS*/
        private string StringValue ()
        {
            Moneda moneda = BuscaMoneda(TMoneda);
            int decimales = moneda.Decimales;
            string simbolo = moneda.Simbolo;
            string format = $"{{0:0.{new String('0', decimales)}}}";
            return $"{String.Format(format, Cantidad)} {simbolo}";
        }
        public decimal ValorEn (TipoMoneda t)
        {
            Moneda monedaActual = BuscaMoneda(TMoneda), monedaDestino = BuscaMoneda(t);
            decimal valor = Cantidad;

            if (TMoneda != t)
            {
                valor /= monedaActual.CambioEuro;
                valor *= monedaDestino.CambioEuro;
            }

            return valor;
        }
        public Dinero ConvierteEn (TipoMoneda t)
        {
            return new Dinero(this.ValorEn(t), t);
        }
        public override string ToString()
        {
            return this.StringValue();
        }
        public string ToString(TipoMoneda t)
        {
            Dinero dinero = this.ConvierteEn(t);
            return dinero.ToString();
        }

        /*OPERADORES ARITMÉTICOS*/
        public static Dinero operator + (Dinero d1, Dinero d2)
        {
            if (d1.TMoneda == d2.TMoneda)
            {
                return new Dinero(d1.Cantidad + d2.Cantidad, d1.TMoneda);
            }
            else
            {
                Dinero dinero = d2.ConvierteEn(d1.TMoneda);

                return d1 + dinero;
            }
        }
        public static Dinero operator - (Dinero d)
        {
            return new Dinero(-d.Cantidad, d.TMoneda);
        }
        public static Dinero operator - (Dinero d1, Dinero d2)
        {
            return d1 + (-d2);
        }
        public static Dinero operator * (Dinero d, int n)
        {
            return new Dinero(d.Cantidad * n, d.TMoneda);
        }
        public static Dinero operator * (Dinero d, double n)
        {
            return new Dinero(d.Cantidad * (decimal) n, d.TMoneda);
        }
        public static Dinero operator * (Dinero d, decimal n)
        {
            return new Dinero(d.Cantidad * n, d.TMoneda);
        }
        public static Dinero operator * (int n, Dinero d)
        {
            return new Dinero(d.Cantidad * n, d.TMoneda);
        }
        public static Dinero operator * (double n, Dinero d)
        {
            return new Dinero(d.Cantidad * (decimal) n, d.TMoneda);
        }
        public static Dinero operator * (decimal n, Dinero d)
        {
            return new Dinero(d.Cantidad * n, d.TMoneda);
        }
        public static Dinero operator / (Dinero d, int n)
        {
            return new Dinero(d.Cantidad / n, d.TMoneda);
        }
        public static Dinero operator / (Dinero d, double n)
        {
            return new Dinero(d.Cantidad / (decimal) n, d.TMoneda);
        }
        public static Dinero operator / (Dinero d, decimal n)
        {
            return new Dinero(d.Cantidad / n, d.TMoneda);
        }

        /*OPERADORES COMPARACIÓN*/
        public static bool operator == (Dinero d1, Dinero d2)
        {
            if (d1.TMoneda != d2.TMoneda)
            {
                d2 = d2.ConvierteEn(d1.TMoneda);
            }

            return d1.Cantidad == d2.Cantidad;
        }
        public static bool operator != (Dinero d1, Dinero d2)
        {
            return !(d1 == d2);
        }
        public static bool operator > (Dinero d1, Dinero d2)
        {
            if (d1.TMoneda != d2.TMoneda)
            {
                d2 = d2.ConvierteEn(d1.TMoneda);
            }

            return d1.Cantidad > d2.Cantidad;
        }
        public static bool operator < (Dinero d1, Dinero d2)
        {
            if (d1.TMoneda != d2.TMoneda)
            {
                d2 = d2.ConvierteEn(d1.TMoneda);
            }

            return d1.Cantidad < d2.Cantidad;
        }
        public static bool operator >= (Dinero d1, Dinero d2)
        {
            if (d1.TMoneda != d2.TMoneda)
            {
                d2 = d2.ConvierteEn(d1.TMoneda);
            }

            return d1.Cantidad >= d2.Cantidad;
        }
        public static bool operator <= (Dinero d1, Dinero d2)
        {
            if (d1.TMoneda != d2.TMoneda)
            {
                d2 = d2.ConvierteEn(d1.TMoneda);
            }

            return d1.Cantidad <= d2.Cantidad;
        }
    }
}
