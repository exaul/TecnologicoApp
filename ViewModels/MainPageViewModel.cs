using CommunityToolkit.Maui.Alerts;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using TecnologicoApp.Models;
using TecnologicoApp.Views;

namespace TecnologicoApp.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        #region "Properties"

        public UsuarioRegistro Usuario { get; set; }

        public Command LoginCommand { get; set; }

        #endregion

        public MainPageViewModel()
        {
            Usuario = new UsuarioRegistro();
            LoginCommand = new Command(LoginAsync);
        }

        #region "Logic"

        private async void LoginAsync()
        {
            if (string.IsNullOrEmpty(Usuario.Email) || !IsAValidEmail(Usuario.Email))
            {
                await ShowToastAsync("Ingrese un Email Válido");
                return;
            }

            if (string.IsNullOrEmpty(Usuario.Password))
            {
                await Util.ShowToastAsync("Ingrese una Contraseña Válida");
                return;
            }

            await Shell.Current.GoToAsync(nameof(WelcomePage));
        }

        private bool IsAValidEmail(string email)
        {
            return Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }

        private async Task ShowToastAsync(string message)
        {
            // implement your logic here
            var toast = Toast.Make(message);
            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await toast.Show(cts.Token);
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
