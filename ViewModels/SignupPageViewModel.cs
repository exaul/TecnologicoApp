using System.ComponentModel;
using TecnologicoApp.Models;
using TecnologicoApp.Service.Interface;

namespace TecnologicoApp.ViewModels;

public class SignupPageViewModel : INotifyPropertyChanged

{
    private readonly ISignupSigninService signupSigninService;
    public UsuarioRegistro Usuario { get; set; }

    public string Password2 { get; set; }

    public Command SaveCommand { get; set; }
    public SignupPageViewModel(ISignupSigninService signupSigninService)
    {
        Usuario = new UsuarioRegistro();
        SaveCommand = new Command(SignUpAsync);
        //RegisterCommand = new Command(GoToSignupPageAsync);
        this.signupSigninService = signupSigninService;
    }

    private async void SignUpAsync()
    {
        var result = await signupSigninService.SignUpAsync(Usuario);

        if (!result)
        {
            await Util.ShowToastAsync("No se registro el usuario");
            return;
        }

        await Util.ShowToastAsync($"Usuario {Usuario.Email} registro exitosamente");
        await Shell.Current.Navigation.PopAsync();
    }


    public event PropertyChangedEventHandler PropertyChanged;
}