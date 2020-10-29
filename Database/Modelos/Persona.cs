using System;
using System.ComponentModel;

namespace Database.Modelos
{

    [Serializable]
    public class Persona
    {
        [DisplayName("Código")]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
    }
}
