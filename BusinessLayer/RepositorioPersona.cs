using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Modelos;

namespace BusinessLayer
{
    public sealed class RepositorioPersona
    {

        public List<Persona> Personas { get; set; } = new List<Persona>();
        public static RepositorioPersona Instacia { get; } = new RepositorioPersona();
        private RepositorioPersona()
        {

        }

    }
}
