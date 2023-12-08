using System.ComponentModel;
using TecnologicoApp.Models;
using TecnologicoApp.Views;

namespace TecnologicoApp.ViewModels
{
    public class SignupPageViewModel : INotifyPropertyChanged

    {
        public UsuarioRegistro Usuario { get; set; }

        public string Password2 { get; set; }

        public Command SaveCommand { get; set; }

        public SignupPageViewModel()
        {
            Usuario = new UsuarioRegistro();
            SaveCommand = new Command(SaveAsync);
        }

        private async void SaveAsync()
        {
            if (string.IsNullOrEmpty(Usuario.Email) || Util.IsAValidEmail(Usuario.Email.ToLower()))
            {
                await Util.ShowToastAsync("Ingrese un Email Válido");
                return;
            }

            if (string.IsNullOrEmpty(Usuario.Password))
            {
                await Util.ShowToastAsync("Ingrese una Contraseña Válida");
                return;
            }
            if (string.IsNullOrEmpty(Password2))
            {
                await Util.ShowToastAsync("No se Aceptan Caracteres Nulos");
                return;
            }
            if (Usuario.Password != Password2)
            {
                await Util.ShowToastAsync("La Contraseña no coinciden");
                return;
            }
            Settings.EmailRegistro = Usuario.Email;
            Settings.PasswordRegistro = Usuario.Password;

            await Shell.Current.Navigation.PopAsync();
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
