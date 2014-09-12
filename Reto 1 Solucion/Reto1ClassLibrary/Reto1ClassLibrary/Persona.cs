using System;

namespace Reto1ClassLibrary
{
    public class Persona
    {
        public string Nombre { get; set; }

        public uint Edad { get; set; }

        public override bool Equals(Object obj)
        {
            Persona otra = obj as Persona;
            return (otra != null) && (this.Edad == otra.Edad) && (this.Nombre == otra.Nombre);
        }

        public override int GetHashCode()
        {
            return this.Edad.GetHashCode() ^ this.Nombre.GetHashCode();
        }
    }
}
