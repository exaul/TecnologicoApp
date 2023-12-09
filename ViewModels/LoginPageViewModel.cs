﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using TecnologicoApp.Models;
using TecnologicoApp.Service.Interface;
using TecnologicoApp.Views;
namespace TecnologicoApp.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        private readonly ISignupSigninService signupSigninService;

        #region "Properties"


        public UsuarioRegistro Usuario { get; set; }

        public Command LoginCommand { get; set; }

        public Command RegisterCommand { get; set; }

        #endregion

        public LoginPageViewModel(ISignupSigninService signupSigninService)
        {
            Usuario = new UsuarioRegistro();
            LoginCommand = new Command(LoginAsync);
            RegisterCommand = new Command(SignUpAsync);            
            //RegisterCommand = new Command(GoToSignupPageAsync);
            this.signupSigninService = signupSigninService;
        }

        #region "Logic"

        private async void SignUpAsync() 
        {
            var result = await signupSigninService.SignUpAsync(Usuario);
            
            if (!result)
            {
                await Util.ShowToastAsync("No se registro el usuario");
                return;
            }

            await Util.ShowToastAsync($"Usuario {Usuario.Email} registro exitosamente");
        }

        private async void LoginAsync()
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

            var loginData = GetLoginData();

            if (loginData != null && !loginData.Any())
            {
                await Util.ShowToastAsync("Configure usuarios");
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
            Settings.Email = Usuario.Email;
            Settings.EmailRegistro = Usuario.Email;
            Settings.PasswordRegistro = Usuario.Password;

            await Shell.Current.GoToAsync($"///{nameof(WelcomePage)}");
        }



        private async void GoToSignupPageAsync()
        {
            await Shell.Current.GoToAsync(nameof(SignupPage));
        }

        private List<KeyValuePair<string, string>> GetLoginData()
        {
            return new List<KeyValuePair<string, string>>
            {
                new("gustavo@istlc.com", "Mama1234"),
                new("betsabe@mail.com", "Papa1234"),
                new(Settings.EmailRegistro, Settings.PasswordRegistro)
            };
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
    }
}