using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Semana14.Models;
using Semana14.Services;
using Semana14.Views;

namespace Semana14.ViewModels
{
    public class MenuItemViewModel
    {
        #region Attributes
        public int Id { get; set; }
        public string Option { get; set; }
        public string Icon { get; set; }
        #endregion Attributes

        #region Commands
        public ICommand SelectMenuItemCommand
        {
            get
            {
                return new Command(SelectMenuItemExecute);
            }
        }
        #endregion Commands

        #region Methods
        private void SelectMenuItemExecute()
        {
            if (this.Id == 1)
                Application.Current.MainPage.Navigation.PushAsync(new AlumnoPage());
            if (this.Id == 2)
                Application.Current.MainPage.Navigation.PushAsync(new AlumnosPage());
            if (this.Id == 3)
                DeleAlbumList();

        }
        DBDataAccess<Alumno> dataService = new DBDataAccess<Alumno>();
        private void DeleAlbumList()
        {
            var Albunes = dataService.Get().ToList();
            dataService.DeleteList(Albunes);
        }
        #endregion Methods

    }
}
