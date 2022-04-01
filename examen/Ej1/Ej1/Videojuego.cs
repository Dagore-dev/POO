using System.Collections.Generic;

namespace Ej1
{
    public enum TipoPlataforma { Steam, Epic, GOG, Humble, Amazon }

    public class Videojuego
    {
        private string nombre;
        private List<TipoPlataforma> plataformas;
        private int anno;

        public Videojuego(string nombre, List<TipoPlataforma> plataformas, int anno)
        {
            this.nombre = nombre;
            this.plataformas = plataformas;
            this.anno = anno;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public int Anno { get => anno; set => anno = value; }
        public List<TipoPlataforma> Plataformas { get => plataformas; set => plataformas = value; }

        public override string ToString()
        {
            return nombre + " (" + anno + ")";
        }
    }
}
