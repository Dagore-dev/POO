using System;

namespace EntregaProfesorTribunal
{
    class Program
    {
        static void Main(string[] args)
        {
            Tribunal tribunal = new Tribunal("./ficheros/profesores1csharp.bin");

            tribunal.EligeTribunalPro();
        }
    }
}
