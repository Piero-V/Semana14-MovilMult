using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Semana14.Models;
using Semana14.Services;

namespace Semana14.ViewModels
{
    public class AlumnosViewModel : BaseViewModel
    {
        #region Services
        private readonly DBDataAccess<Curso> dataServiceCursos;
        private readonly DBDataAccess<Alumno> dataServiceAlumnos;
        #endregion Services

        #region Attributes
        private ObservableCollection<Curso> cursos;
        private ObservableCollection<Alumno> alumnos;
        private Curso selectedCurso;
        private string titulo;
        private double precio;
        private int anio;
        #endregion Attributes

        #region Properties
        public ObservableCollection<Curso> Cursos
        {
            get { return this.cursos; }
            set { SetValue(ref this.cursos, value); }
        }

        public ObservableCollection<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { SetValue(ref this.alumnos, value); }
        }

        public Curso SelectedCurso
        {
            get { return this.selectedCurso; }
            set { SetValue(ref this.selectedCurso, value); }
        }

        public string Titulo
        {
            get { return this.titulo; }
            set { SetValue(ref this.titulo, value); }
        }

        public double Precio
        {
            get { return this.precio; }
            set { SetValue(ref this.precio, value); }
        }

        public int Anio
        {
            get { return this.anio; }
            set { SetValue(ref this.anio, value); }
        }
        #endregion Properties

        #region Constructor
        public AlumnosViewModel()
        {
            this.dataServiceCursos = new DBDataAccess<Curso>();
            this.dataServiceAlumnos = new DBDataAccess<Alumno>();

            //this.CreateCursos();

            this.LoadCursos();
            this.LoadAlumnos();

            this.Anio = DateTime.Now.Year;
        }
        #endregion Constructor

        #region Commands
        public ICommand CreateCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var newAlumno = new Alumno()
                    {
                        CursoID = this.SelectedCurso.CursoID,
                        Titulo = this.Titulo,
                        Precio = this.Precio,
                        Anio = this.Anio
                    };

                    var alumno = this.dataServiceAlumnos.Get(x => x.Titulo == newAlumno.Titulo).FirstOrDefault();

                    if (alumno == null)
                    {
                        if (newAlumno != null)
                        {
                            if (this.dataServiceAlumnos.Create(newAlumno))
                            {
                                await Application.Current.MainPage.DisplayAlert("Operación Exitosa",
                                                                                $"Albúm del artista: {this.SelectedCurso.Nombre} " +
                                                                                $"creado correctamente en la base de datos",
                                                                                "Ok");

                                this.SelectedCurso = null;
                                this.Titulo = string.Empty;
                                this.Precio = 0;
                                this.Anio = DateTime.Now.Year;
                            }

                            else
                                await Application.Current.MainPage.DisplayAlert("Operación Fallida",
                                                                                $"Error al crear el Albúm en la base de datos",
                                                                                "Ok");
                        }
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Validación",
                                                                              $"Título Repetido",
                                                                              "Ok");
                    }


                });
            }
        }
        #endregion Commands

        #region Methods
        private void LoadCursos()
        {
            var cursosDB = this.dataServiceCursos.Get().ToList() as List<Curso>;
            this.Cursos = new ObservableCollection<Curso>(cursosDB);
        }

        private void LoadAlumnos()
        {
            var albumesDB = this.dataServiceAlumnos.Get(null, null, "Curso").ToList() as List<Alumno>;
            this.Alumnos = new ObservableCollection<Alumno>(albumesDB);
        }

        private void CreateCursos()
        {
            var cursos = new List<Curso>()
            {
                new Curso { Nombre = "Multiplataforma" },
                new Curso { Nombre = "Soluciones en la nube" },
                new Curso { Nombre = "Phyton" }
            };

            this.dataServiceCursos.SaveList(cursos);
        }
        #endregion Methods
    }
}
