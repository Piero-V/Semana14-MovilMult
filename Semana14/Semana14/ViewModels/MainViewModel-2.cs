using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Semana14.Models;
using Semana14.Services;

namespace Semana14.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Attributes
        private ObservableCollection<MenuItemViewModel> menu;
        #endregion Attributes

        #region Properties
        public ObservableCollection<MenuItemViewModel> Menu
        {
            get { return this.menu; }
            set { SetValue(ref this.menu, value); }
        }
        #endregion Properties

        #region Constructor
        public MainViewModel()
        {
            this.LoadMenu();

            this.SaveCursosList();
            //this.DeleArtistasList();
        }
        #endregion Constructor

        #region Methods
        private void LoadMenu()
        {
            this.Menu = new ObservableCollection<MenuItemViewModel>();

            this.Menu.Clear();
            this.Menu.Add(new MenuItemViewModel { Id = 1, Option = "Crear" });
            this.Menu.Add(new MenuItemViewModel { Id = 2, Option = "Lista de Registros" });
            this.Menu.Add(new MenuItemViewModel { Id = 3, Option = "Eliminar Registros" });
        }
        #endregion Methods

        DBDataAccess<Curso> dataService = new DBDataAccess<Curso>();
        private void SaveCursosList()
        {
            var cursos = new List<Curso>()
            {
                new Curso{ Nombre = "Arjona" },
                new Curso{ Nombre = "Luismi" },
                new Curso{ Nombre = "Kalimba" }
            };

            dataService.SaveList(cursos);
        }
        private void DeleCursosList()
        {
            var cursos = dataService.Get().ToList();
            dataService.DeleteList(cursos);
        }

    }
}
