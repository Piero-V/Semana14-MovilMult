using System;
using System.Collections.Generic;
using System.Text;

namespace Semana14.Models
{
    public class Curso
    {
        public int CursosID { get; set; }
        public int AlumnoID { get; set; }
        public Alumno Alumno { get; set; }

        public string Titulo { get; set; }
        public double Precio { get; set; }
        public int Anio { get; set; }
    }

}
