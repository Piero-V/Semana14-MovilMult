using System;
using System.Collections.Generic;
using System.Text;

namespace Semana14.Models
{
    public class Alumno
    {
        public int AlumnoID { get; set; }
        public int CursoID { get; set; }
        public Curso Curso { get; set; }

        public string Titulo { get; set; }
        public double Precio { get; set; }
        public int Anio { get; set; }
    }
}
