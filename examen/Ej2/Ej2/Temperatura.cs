using System;
using System.Collections.Generic;
using System.Text;

namespace Ej2
{
    public enum UnidadTemperatura
    {
        Celsius,
        Farenheit,
        Kelvin
    }
    class Temperatura
    {
        //Atributos
        private double valor;
        private UnidadTemperatura unidad;
        //Constructor
        public Temperatura (double valor, UnidadTemperatura unidad)
        {
            this.valor = valor;
            this.unidad = unidad;
        }
        //Propiedades
        public double Valor
        {
            get { return valor; }
            set { valor = value; }
        }
        public UnidadTemperatura Unidad
        {
            get { return unidad; }
        }
        //ToString
        private string Representation ()
        {
            return $"{valor} {GetSymbol(unidad)}";
        }
        private string GetSymbol (UnidadTemperatura unidad)
        {
            switch (unidad)
            {
                case UnidadTemperatura.Celsius:
                    return "ºC";
                case UnidadTemperatura.Farenheit:
                    return "ºF";
                case UnidadTemperatura.Kelvin:
                    return "K";
                default:
                    throw new Exception("Esa unidad no está incluida en el programa");
            }
        }
        public override string ToString()
        {
            return Representation();
        }
        //ConvierteEn
        public Temperatura ConvierteEn (UnidadTemperatura u)
        {
            switch (u)
            {
                case UnidadTemperatura.Celsius:
                    return new Temperatura(ToCelsius(valor), u);
                case UnidadTemperatura.Farenheit:
                    return new Temperatura(ToFarenheit(valor), u);
                case UnidadTemperatura.Kelvin:
                    return new Temperatura(ToKelvin(valor), u);
                default:
                    throw new NotImplementedException();
            }
        }
        private double ToCelsius (double d)
        {
            switch (unidad)
            {
                case UnidadTemperatura.Celsius:
                    return d;
                case UnidadTemperatura.Farenheit:
                    return (5 / 9.0) * (d - 32);
                case UnidadTemperatura.Kelvin:
                    return d - 273;
                default:
                    throw new NotImplementedException();
            }
        }
        private double ToFarenheit (double d)
        {
            switch (unidad)
            {
                case UnidadTemperatura.Celsius:
                    return (9 / 5.0) * d + 32;
                case UnidadTemperatura.Farenheit:
                    return d;
                case UnidadTemperatura.Kelvin:
                    return (9 / 5.0) * (d - 273) + 32;
                default:
                    throw new NotImplementedException();
            }
        }
        private double ToKelvin (double d)
        {
            switch (unidad)
            {
                case UnidadTemperatura.Celsius:
                    return d + 273;
                case UnidadTemperatura.Farenheit:
                    return (5 / 9.0) * (d - 32) + 273;
                case UnidadTemperatura.Kelvin:
                    return d;
                default:
                    throw new NotImplementedException();
            }
        }
        //Bienvenidos al maravilloso mundo de los operadores
        public static bool operator == (Temperatura t1, Temperatura t2)
        {
            if (t1.Unidad == t2.Unidad)
            {
                return t1.Valor == t2.Valor;
            }
            else
            {
                return t1.ConvierteEn(UnidadTemperatura.Celsius) == t2.ConvierteEn(UnidadTemperatura.Celsius);
            }
        }
        public static bool operator != (Temperatura t1, Temperatura t2)
        {
            return !(t1 == t2);
        }
        public static bool operator > (Temperatura t1, Temperatura t2)
        {
            if (t1.Unidad == t2.Unidad)
            {
                return t1.Valor > t2.Valor;
            }
            else
            {
                return t1.ConvierteEn(UnidadTemperatura.Celsius) > t2.ConvierteEn(UnidadTemperatura.Celsius);
            }
        }
        public static bool operator < (Temperatura t1, Temperatura t2)
        {
            if (t1.Unidad == t2.Unidad)
            {
                return t1.Valor < t2.Valor;
            }
            else
            {
                return t1.ConvierteEn(UnidadTemperatura.Celsius) < t2.ConvierteEn (UnidadTemperatura.Celsius);
            }
        }
        public static bool operator >= (Temperatura t1, Temperatura t2)
        {
            if (t1.Unidad == t2.Unidad)
            {
                return t1.Valor >= t2.Valor;
            }
            else
            {
                return t1.ConvierteEn(UnidadTemperatura.Celsius) >= t2.ConvierteEn(UnidadTemperatura.Celsius);
            }
        }
        public static bool operator <= (Temperatura t1, Temperatura t2)
        {
            if (t1.Unidad == t2.Unidad)
            {
                return t1.Valor <= t2.Valor;
            }
            else
            {
                return t1.ConvierteEn(UnidadTemperatura.Celsius) <= t2.ConvierteEn(UnidadTemperatura.Celsius);
            }
        }
    }
}
