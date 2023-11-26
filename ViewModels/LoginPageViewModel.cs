using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using TecnologicoApp.Models;
using TecnologicoApp.Views;

namespace TecnologicoApp.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        #region "Properties"

        public UsuarioRegistro Usuario { get; set; }

        public Command LoginCommand { get; set; }

        #endregion

        public LoginPageViewModel()
        {
            Usuario = new UsuarioRegistro();
            LoginCommand = new Command(LoginAsync);
        }

        #region "Logic"

        private async void LoginAsync()
        {
            if (string.IsNullOrEmpty(Usuario.Email) || !IsAValidEmail(Usuario.Email.ToLower()))
            {
                await Util.ShowToastAsync("Ingrese un Email Válido");
                return;
            }

            if (string.IsNullOrEmpty(Usuario.Password))
            {
                await Util.ShowToastAsync("Ingrese una Contraseña Válida");
                return;
            }
            //if (Usuario.Email != "saul@istlcg.com" || Usuario.Password != "Mom1234")
            //{
            //    await Util.ShowToastAsync("Email o contraseña incorrectos");
            //    return;
            //}
            var loginData = GetLoginData();
            if (loginData != null && !loginData.Any())
            {
                await Util.ShowToastAsync("Configure Usuarios");
                return;
            }
            var loginDataEmail = loginData.FirstOrDefault(x => x.Key == Usuario.Email);
            if (loginDataEmail.Equals(default(KeyValuePair<string, string>)))
            {
                await Util.ShowToastAsync($"El correo {Usuario.Email} no existe");
                return;
            }
            if (loginDataEmail.Value != Usuario.Password)
            {
                await Util.ShowToastAsync($"Contraseña Incorrecta");
                return;
            }
            Settings.IsAuthenticated = true;
            Settings.Email =Usuario.Email;

            await Shell.Current.GoToAsync($"///{nameof(WelcomePage)}");
        }

        private bool IsAValidEmail(string email)
        {
            return Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            }

        private List<KeyValuePair<string, string>> GetLoginData()
        {
            return new List<KeyValuePair<string, string>>()
            {
                new("saul@istlcg.com", "Mom1234."),
                 new("gus@mail.com", "Guayaquil")
            };
            
        }

            public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
    }
}