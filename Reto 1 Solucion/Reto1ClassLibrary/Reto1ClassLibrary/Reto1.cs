using System.Collections.Generic;
using System.Linq;

namespace Reto1ClassLibrary
{
    public class Reto1
    {
        public static List<Persona> OrdenarLista(List<Persona> personas)
        {
            if (personas == null)
            {
                return null;
            }

            return personas.OrderByDescending(p => p.Edad).ThenBy(p => p.Nombre).ToList();
        }
    }
}
